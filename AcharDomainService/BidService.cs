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

        public async Task<int> CreateBid(Bid bid, CancellationToken cancellationToken)
        {
            var addBid = new Bid();
            addBid.CreateAt = DateTime.Now;
            addBid.Description = bid.Description;
            addBid.BidPrice = bid.BidPrice;
            addBid.ExpertId = bid.ExpertId;
            addBid.RequestId = bid.RequestId;
            addBid.Status = StatusBidEnum.WaitingForCustomerConfirmation;
            return await _repository.CreateBid(addBid, cancellationToken);
        }

        public async Task<bool> UpdateBid(BidUpdateDto bid, CancellationToken cancellationToken)
            => await _repository.UpdateBid(bid, cancellationToken);

        public async Task<int> BidCount(CancellationToken cancellationToken)
            => await _repository.BidCount(cancellationToken);

        public async Task<List<GetBidDto>>? GetBidsByRequestId(int id, CancellationToken cancellationToken)
            => await _repository.GetBidsByRequestId(id, cancellationToken);

        

        public async Task<List<GetBidDto>>? GetBidsByExpertId(int expertId, CancellationToken cancellationToken)
            => await _repository.GetBidsByExpertId(expertId, cancellationToken);


        public async Task<List<Bid?>> GetBids(CancellationToken cancellationToken)
            => await _repository.GetBids(cancellationToken);

        public async Task<bool> DeleteBid(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteBid(delete, cancellationToken);

        public async Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken)
            => await _repository.ChangebidStatus(status, cancellationToken);
    }
}
