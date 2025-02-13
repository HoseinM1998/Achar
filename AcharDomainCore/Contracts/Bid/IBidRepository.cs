using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.BidDto;

namespace AcharDomainCore.Contracts.Bid
{
    public interface IBidRepository
    {
        Task<int> CreateBid(Entites.Bid bid, CancellationToken cancellationToken);
        Task<bool> UpdateBid(BidUpdateDto bid, CancellationToken cancellationToken);
        Task<Entites.Bid> GetBidById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Bid>> GetBids(CancellationToken cancellationToken);
        Task<bool> IsActiveBid(SoftDeleteDto active, CancellationToken cancellationToken);
        public Task<bool> AcceptBid(int bidId, CancellationToken cancellationToken);
        public Task<bool> RejectBid(int bidId, CancellationToken cancellationToken);
        public Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken);

    }
}
