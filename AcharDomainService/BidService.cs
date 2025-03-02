using AcharDomainCore.Contracts.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.BidDto;
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


        public BidService(IBidRepository repository, IRequestRepository requestRepository)
        {
            _repository = repository;
            _requestRepository = requestRepository;
        }

        public async Task<int> CreateBid(BidAddDto bid, CancellationToken cancellationToken)
            => await _repository.CreateBid(bid, cancellationToken);

        public async Task<bool> UpdateBid(BidUpdateDto bid, CancellationToken cancellationToken)
            => await _repository.UpdateBid(bid, cancellationToken);

        public async Task<int> BidCount(CancellationToken cancellationToken)
            => await _repository.BidCount(cancellationToken);

        public async Task<List<GetBidDto>>? GetBidsByRequestId(int id, CancellationToken cancellationToken)
            => await _repository.GetBidsByRequestId(id, cancellationToken);



        public async Task<List<GetBidDto>>? GetBidsByExpertId(int expertId, CancellationToken cancellationToken)
            => await _repository.GetBidsByExpertId(expertId, cancellationToken);


        public async Task<List<GetBidDto?>> GetBids(CancellationToken cancellationToken)
            => await _repository.GetBids(cancellationToken);

        public async Task<bool> DeleteBid(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteBid(delete, cancellationToken);

        public async Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken)
        {
            var bid = await _repository.GetBidById(status.Id, cancellationToken);
            if (bid == null || bid.Request == null) return false;

            var request = bid.Request;

            if (status.Status == StatusBidEnum.WaitingForCustomerConfirmation)
            {
                return request.AcceptedExpertId == null;
            }

            if (request.AcceptedExpertId == bid.ExpertId)
            {
                if (status.Status == StatusBidEnum.Success && request.DoneAt != null)
                {
                    await _repository.ChangebidStatus(status, cancellationToken);
                    return true;
                }

                if (status.Status == StatusBidEnum.CancelledByCustomer && request.Status == StatusRequestEnum.CancelledByCustomer && request.DoneAt == null)
                {
                    await _repository.ChangebidStatus(status, cancellationToken);
                    return true;
                }

                if (status.Status == StatusBidEnum.CancelledByExpert && request.DoneAt == null)
                {
                    await _repository.ChangebidStatus(status, cancellationToken);
                    return true;
                }

                if (status.Status == StatusBidEnum.WaitingForExpert && request.Status == StatusRequestEnum.WaitingForExpert && request.DoneAt == null)
                {
                    await _repository.ChangebidStatus(status, cancellationToken);
                    return true;
                }
            }

            if (status.Status == StatusBidEnum.Rejected && request.AcceptedExpertId != bid.ExpertId)
            {
                await _repository.ChangebidStatus(status, cancellationToken);
                return true;
            }

            return false;
        }


        public async Task<bool> CancellBid(int bidId, int expertId, CancellationToken cancellationToken)
            => await _repository.CancellBid(bidId, expertId, cancellationToken);

    }
}
