using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Dtos;

namespace AcharDomainCore.Contracts.Bid
{
    public interface IBidService
    {
        Task<int> CreateBid(Entites.Bid bid, CancellationToken cancellationToken);
        Task<bool> UpdateBid(BidUpdateDto bid, CancellationToken cancellationToken);
        Task<int> BidCount(CancellationToken cancellationToken);
        Task<Entites.Bid> GetBidById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Bid?>> GetBids(CancellationToken cancellationToken);
        Task<bool> DeleteBid(SoftDeleteDto delete, CancellationToken cancellationToken);
        public Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken);
    }
}
