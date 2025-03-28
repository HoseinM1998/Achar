using AcharDomainCore.Contracts.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Entites;
using AcharDomainCore.Enums;
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class BidService : IBidService
    {
        private readonly IBidRepository _repository;
        private readonly ILogger<BidService> _logger;
        private readonly IRequestRepository _requestRepository;
        private readonly IBaseRepository _repositoryBalance;
        private readonly IHomeServiceRepository _homeServiceRepository;




        public BidService(IBidRepository repository,
            IRequestRepository requestRepository,
            IBaseRepository repositoryBalance,
            IHomeServiceRepository homeServiceRepository)
        {
            _repository = repository;
            _requestRepository = requestRepository;
            _repositoryBalance = repositoryBalance;
            _homeServiceRepository = homeServiceRepository;
        }

        public async Task<int> CreateBid(BidAddDto bid, CancellationToken cancellationToken)
        {
            var request = await _requestRepository.GetRequestById(bid.RequestId, cancellationToken);
            if (request is null)
            {
                throw new Exception("درخواست مورد نظر یافت نشد");
            }

            var service = await _homeServiceRepository.GetHomeServiceById(request.ServiceId, cancellationToken);
            if (service is null)
            {
                throw new Exception("خدمات مورد نظر یافت نشد");
            }

            if (bid.BidDate > request.RequesteForTime || bid.BidDate < DateTime.Now)
            {
                throw new Exception("تاریخ باید از تاریخ پیشنهادی مشتری کمتر باشد یا تاریخ روز باشه");
            }

            if (bid.BidPrice < service.BasePrice)
            {
                throw new Exception($"مبلغ پیشنهادی باید از مبلغ پایه بزرگتر باشد ({service.BasePrice})");
            }

            bid.Status = StatusBidEnum.WaitingForCustomerConfirmation;
            return await _repository.CreateBid(bid, cancellationToken);
        }

        public async Task<bool> UpdateBid(BidUpdateDto bid, CancellationToken cancellationToken)
            => await _repository.UpdateBid(bid, cancellationToken);

        public async Task<int> BidCount(CancellationToken cancellationToken)
            => await _repository.BidCount(cancellationToken);

        public async Task<List<GetBidDto>>? GetBidsByRequestId(int id, CancellationToken cancellationToken)
        {
            var bids= await _repository.GetBidsByRequestId(id, cancellationToken);
            foreach (var bid in bids)
            {
                await ChangebidStatus(new BidStatusDto { Id = bid.Id }, cancellationToken);
            }

            return bids;
        }



        public async Task<List<GetBidDto>>? GetBidsByExpertId(int expertId, CancellationToken cancellationToken)
        {

            var bids= await _repository.GetBidsByExpertId(expertId, cancellationToken);
            foreach (var bid in bids)
            {
                await ChangebidStatus(new BidStatusDto { Id = bid.Id }, cancellationToken);
            }

            return bids;
        }


        public async Task<List<GetBidDto>> GetBids(CancellationToken cancellationToken)
        {
            var bids = await _repository.GetBids(cancellationToken);

            foreach (var bid in bids)
            {
                await ChangebidStatus(new BidStatusDto { Id = bid.Id }, cancellationToken);
            }

            return bids;
        }

        public async Task<bool> DeleteBid(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteBid(delete, cancellationToken);

        public async Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken)
        {
            var bid = await _repository.GetBidById(status.Id, cancellationToken);
            if (bid.RequestId == null) return false;

            var request = bid.Request;
            if (request.Status == StatusRequestEnum.AwaitingCustomerConfirmation|| request.Status == StatusRequestEnum.AwaitingSuggestionExperts)
            {
                status.Status = StatusBidEnum.WaitingForCustomerConfirmation;
            }
            if (request.AcceptedExpertId == bid.ExpertId)
            {
                if (request.Status == StatusRequestEnum.WaitingForExpert)
                    status.Status = StatusBidEnum.WaitingForExpert;

                else if (request.Status == StatusRequestEnum.CancelledByExpert)
                    status.Status = StatusBidEnum.CancelledByExpert;

                else if (request.Status == StatusRequestEnum.CancelledByCustomer)
                    status.Status = StatusBidEnum.CancelledByCustomer;

                else if (request.Status == StatusRequestEnum.Success)
                    status.Status = StatusBidEnum.Success;

            }
            if(request.AcceptedExpertId!=null&&request.AcceptedExpertId != bid.ExpertId)
            {
                status.Status = StatusBidEnum.Rejected;
            }

            await _repository.ChangebidStatus(status, cancellationToken);
            return true;
        }



        public async Task<bool> CancellBid(int bidId, int expertId, CancellationToken cancellationToken)
        {
            var bid = await _repository.GetBidById(bidId, cancellationToken);
            if (bid == null) throw new Exception("Bid not found");

            var requestDto = await _requestRepository.GetRequestById(bid.RequestId, cancellationToken);
            if (requestDto == null) throw new Exception("Request not found");
            if (requestDto.ExpertId==bid.ExpertId)
            {
                await _repositoryBalance.ChangeBalanceAdmin(bid.BidPrice, cancellationToken);
                await _repositoryBalance.ChangeAddBalanceCustomer(requestDto.CustomerId, bid.BidPrice, cancellationToken);

            }

            await _repository.CancellBid(bidId, expertId, cancellationToken);
            StatusRequestDto status = new();
            status.Id = bid.RequestId;
            status.Status = StatusRequestEnum.CancelledByExpert;
            await _requestRepository.ChangeRequestStatus(status, cancellationToken);

            return true;
        }


    }
}
