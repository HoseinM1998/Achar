using AcharDomainCore.Contracts.BaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Bid;
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

        public BidService(IBidRepository repository)
        {
            _repository = repository;
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
            if (bid == null)
            {
                return false;
            }

            var request = bid.Request;
            if (request == null)
            {
                return false;
            }

            if (request.AcceptedExpertId == null)
            {
                status.Status = StatusBidEnum.WaitingForCustomerConfirmation;
            }
            else if (request.AcceptedExpertId == bid.ExpertId)
            {
                if (request.DoneAt != null)
                {
                    status.Status = StatusBidEnum.Success;
                }
                else if (request.Status == StatusRequestEnum.CancelledByCustomer)
                {
                    status.Status = StatusBidEnum.CancelledByCustomer;
                }
                else if (request.Status == StatusRequestEnum.CancelledByExpert)
                {
                    status.Status = StatusBidEnum.CancelledByExpert;
                }
                else
                {
                    status.Status = StatusBidEnum.WaitingForExpert;
                }
            }
            else
            {
                status.Status = StatusBidEnum.Rejected;
            }

            await _repository.ChangebidStatus(status, cancellationToken);
            return true;
        }

        public async Task<bool> CancellBid(int bidId, int expertId, CancellationToken cancellationToken)
            => await _repository.CancellBid(bidId,expertId, cancellationToken);

    }
}
