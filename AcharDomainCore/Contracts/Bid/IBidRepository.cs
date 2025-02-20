using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.BidDto;

namespace AcharDomainCore.Contracts.Bid
{
    public interface IBidRepository
    {
        Task<int> CreateBid(Entites.Bid bid, CancellationToken cancellationToken);
        Task<bool> UpdateBid(BidUpdateDto bid, CancellationToken cancellationToken);
        Task<int> BidCount(CancellationToken cancellationToken);
        Task<List<GetBidDto>>? GetBidsByRequestId(int id, CancellationToken cancellationToken);
        Task<List<GetBidDto>>? GetBidsByExpertId(int expertId, CancellationToken cancellationToken);
        Task<List<GetBidDto?>> GetBids(CancellationToken cancellationToken);
        Task<bool> DeleteBid(SoftDeleteDto delete, CancellationToken cancellationToken);
        Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken);
        Task<Entites.Bid?> GetBidById(int id, CancellationToken cancellationToken);

    }
}
