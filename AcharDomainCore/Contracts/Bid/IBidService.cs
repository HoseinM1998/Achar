using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Dtos;

namespace AcharDomainCore.Contracts.Bid
{
    public interface IBidService
    {
        Task<int> CreateBid(BidAddDto bid, CancellationToken cancellationToken);
        Task<bool> UpdateBid(BidUpdateDto bid, CancellationToken cancellationToken);
        Task<int> BidCount(CancellationToken cancellationToken);
        Task<List<GetBidDto>>? GetBidsByRequestId(int id, CancellationToken cancellationToken);
        Task<List<GetBidDto>>? GetBidsByExpertId(int expertId, CancellationToken cancellationToken);
        Task<List<GetBidDto?>> GetBids(CancellationToken cancellationToken);
        Task<bool> DeleteBid(SoftDeleteDto delete, CancellationToken cancellationToken);
        public Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken);
        Task<bool> CancellBid(int bidId, int expertId, CancellationToken cancellationToken);

    }
}
