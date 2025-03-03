using AcharDomainCore.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.BaseData;
using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Entites;
using AcharDomainCore.Enums;
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;
        private readonly IBaseRepository _repositoryBalance;
        private readonly IBidRepository _bidRepository;



        private readonly ILogger<RequestService> _logger;

        public RequestService(IRequestRepository repository, IBaseRepository repositoryBalance, IBidRepository bidRepository)
        {
            _repository = repository;
            _repositoryBalance = repositoryBalance;
            _bidRepository = bidRepository;
        }

        public async Task<int> CreateRequest(RequestDto requestDto, CancellationToken cancellationToken)
        {
            if (requestDto.RequesteForTime < DateTime.Now)
            {
                throw new ArgumentException("تاریخ باید ب روز باشد");

            }

            return await _repository.CreateRequest(requestDto, cancellationToken);
        }

        public async Task<bool> UpdateRequest(RequestUpDto request, CancellationToken cancellationToken)
            => await _repository.UpdateRequest(request, cancellationToken);


        public async Task<int> RequestCount(CancellationToken cancellationToken)
            => await _repository.RequestCount(cancellationToken);


        public async Task<RequestGetDto> GetRequestById(int id, CancellationToken cancellationToken)
            => await _repository.GetRequestById(id, cancellationToken);

        public async Task<List<RequestGetDto?>> GetRequests(CancellationToken cancellationToken)
            => await _repository.GetRequests(cancellationToken);

        public async Task<List<RequestGetDto?>> GetCustomerRequests(int customerId, CancellationToken cancellationToken)
            => await _repository.GetCustomerRequests(customerId, cancellationToken);

        public async Task<List<RequestGetDto?>> GetRequestsByExpert(int expertId, CancellationToken cancellationToken)
            => await _repository.GetRequestsByExpert(expertId, cancellationToken);


        public async Task<bool> DeleteRequest(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteRequest(delete, cancellationToken);


        public async Task<bool> ChangeRequestStatus(StatusRequestDto newStatus, CancellationToken cancellationToken)
        {
            var request = await _repository.GetRequestById(newStatus.Id, cancellationToken);
            if (request == null) return false;

            if (newStatus.Status == StatusRequestEnum.AwaitingSuggestionExperts &&
                request.ExpertId == null && request.DoneAt == null && request.Bids == null && request.Status != StatusRequestEnum.CancelledByCustomer &&
                request.Status != StatusRequestEnum.CancelledByExpert)
            {
                await _repository.ChangeRequestStatus(newStatus, cancellationToken);
                return true;
            }

            if (newStatus.Status == StatusRequestEnum.AwaitingCustomerConfirmation &&
                request.Bids != null && request.DoneAt == null && request.Status != StatusRequestEnum.CancelledByCustomer &&
                request.Status != StatusRequestEnum.CancelledByExpert)
            {
                await _repository.ChangeRequestStatus(newStatus, cancellationToken);
                return true;
            }

            if (newStatus.Status == StatusRequestEnum.Success &&
                  request.ExpertId != null && request.Status != StatusRequestEnum.CancelledByCustomer &&
                  request.Status != StatusRequestEnum.CancelledByExpert)
            {
                request.DoneAt = DateTime.Now;
                await _repository.ChangeRequestStatus(newStatus, cancellationToken);
                return true;
            }

            if (newStatus.Status == StatusRequestEnum.CancelledByCustomer &&
                request.DoneAt == null && request.Status != StatusRequestEnum.CancelledByCustomer &&
                request.Status != StatusRequestEnum.CancelledByExpert)
            {
                await _repository.ChangeRequestStatus(newStatus, cancellationToken);
                return true;
            }

            if (newStatus.Status == StatusRequestEnum.CancelledByExpert &&
                request.DoneAt == null && request.Status != StatusRequestEnum.CancelledByCustomer &&
                request.Status != StatusRequestEnum.CancelledByExpert)
            {
                await _repository.ChangeRequestStatus(newStatus, cancellationToken);
                return true;
            }

            if (newStatus.Status == StatusRequestEnum.WaitingForExpert &&
                request.Bids == null && request.DoneAt == null && request.ExpertId != null && request.Status != StatusRequestEnum.CancelledByCustomer &&
                request.Status != StatusRequestEnum.CancelledByExpert)
            {
                await _repository.ChangeRequestStatus(newStatus, cancellationToken);
                return true;
            }

            return false;
        }


        public async Task<bool> AcceptExpert(int id, int bidId, decimal bidPrice, CancellationToken cancellationToken)
        {
            try
            {
                var requestDto = await _repository.GetRequestById(id, cancellationToken);
                var balanceCustomer = await _repositoryBalance.GetBalanceCustomer(requestDto.CustomerId, cancellationToken);
                var bid = await _bidRepository.GetBidById(bidId, cancellationToken);

                if (balanceCustomer < bidPrice)
                {
                    throw new Exception("موجودی کافی نیست");
                }

                await _repositoryBalance.ChangeBalanceCustomer(requestDto.CustomerId, bidPrice, cancellationToken);
                await _repositoryBalance.ChangeBalanceAdmin(bidPrice, cancellationToken);
                await _repository.AcceptExpert(id, bidId, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"ارور تایید کارشناس: {ex.Message}");
            }
        }


        public async Task<bool> DoneRequest(int requestId, int bidId, CancellationToken cancellationToken)
        {
            try
            {
                var requestDto = await _repository.GetRequestById(requestId, cancellationToken);
                var balanceCustomer = await _repositoryBalance.GetBalanceCustomer(requestDto.CustomerId, cancellationToken);
                var bid = await _bidRepository.GetBidById(bidId, cancellationToken);

                decimal tenPercent = bid.BidPrice * 0.1m;
                decimal remainingAmount = bid.BidPrice - tenPercent;

                await _repositoryBalance.ChangeBalanceAdminExpert(remainingAmount, cancellationToken);
                await _repositoryBalance.ChangeBalanceExpert(requestDto.ExpertId.Value, remainingAmount, cancellationToken);
                await _repository.DoneRequest(requestId, cancellationToken);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("خطا در انجام تراکنش ");

            }
        }


        public async Task<bool> CancellRequest(int requestId, int bidId, CancellationToken cancellationToken)
        {
            try
            {
                var requestDto = await _repository.GetRequestById(requestId, cancellationToken);
                var bid = await _bidRepository.GetBidById(bidId, cancellationToken);

                if (requestDto == null)
                    throw new Exception("درخواست مورد نظر یافت نشد.");

                if (requestDto.ExpertId.HasValue)
                {
                    await _repositoryBalance.ChangeBalanceAdmin(bid.BidPrice, cancellationToken);
                    await _repositoryBalance.ChangeAddBalanceCustomer(requestDto.CustomerId, bid.BidPrice, cancellationToken);
                }

                await _repository.CancellRequest(requestId, cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"خطا در لغو درخواست: {ex.Message}");
            }
        }

    }
}
