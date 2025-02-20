using AcharDomainCore.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Entites;
using System.Security.Cryptography;
using Microsoft.Extensions.Logging;

namespace AcharDomainAppService
{
    public class BidAppService:IBidAppService
    {
        private readonly IBidService _service;
        private readonly ILogger<BidAppService> _logger;

        public BidAppService(IBidService service)
        {
            _service = service;
        }

        public async Task<int> CreateBid(Bid bid, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.CreateBid(bid, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateBid: {ex.Message}");
            }

        }

        public async Task<bool> UpdateBid(BidUpdateDto bid, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UpdateBid(bid, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateBid: {ex.Message}");
            }
        }

        public async Task<int> BidCount(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.BidCount( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error BidCount: {ex.Message}");
            }
        }

        public async Task<List<GetBidDto>>? GetBidsByRequestId(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetBidsByRequestId(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetBidsByRequestId: {ex.Message}");
            }
        }

        public async Task<List<GetBidDto>>? GetBidsByExpertId(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetBidsByExpertId(expertId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetBidsByExpertId: {ex.Message}");
            }

        }

        public async Task<List<Bid?>> GetBids(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetBids( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetBids: {ex.Message}");
            }
        }

        public async Task<bool> DeleteBid(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteBid(delete, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DeleteBid: {ex.Message}");
            }
        }

        public async Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.ChangebidStatus(status, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error ChangebidStatus: {ex.Message}");
            }
        }
    }
}
