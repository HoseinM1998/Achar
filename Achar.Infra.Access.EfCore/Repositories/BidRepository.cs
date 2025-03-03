using Achar.Infra.Db.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using AcharDomainCore.Enums;
using Microsoft.Extensions.Logging;
using System.Net.NetworkInformation;
using AcharDomainCore.Dtos.Request;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<BidRepository> _logger;

        public BidRepository(AppDbContext context, ILogger<BidRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> CreateBid(BidAddDto bid, CancellationToken cancellationToken)
        {
            var biid = new Bid()
            {
                CreateAt = DateTime.Now,
                IsDeleted = false,
                Status = StatusBidEnum.WaitingForCustomerConfirmation,
                Description = bid.Description,
                BidPrice = bid.BidPrice,
                BidDate = bid.BidDate,
                ExpertId = bid.ExpertId,
                RequestId = bid.RequestId

            };
            await _context.Bids.AddAsync(biid, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return biid.Id;
        }

        public async Task<bool> UpdateBid(BidUpdateDto updatebid, CancellationToken cancellationToken)
        {
            _logger.LogInformation("بروزرسانی پیشنهاد با شناسه: {BidId} زمان {Time}", updatebid.Id, DateTime.UtcNow.ToLongTimeString());
            var updateBid = await _context.Bids.FirstOrDefaultAsync(x => x.Id == updatebid.Id, cancellationToken);
            if (updateBid != null)
            {
                updateBid.Description = updatebid.Description;
                updateBid.BidPrice = updatebid.BidPrice;
                updateBid.BidDate = updatebid.BidDate;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("پیشنهاد با شناسه: {BidId} با موفقیت بروزرسانی شد زمان {Time}", updatebid.Id, DateTime.UtcNow.ToLongTimeString());
                return true;
            }
            _logger.LogWarning("پیشنهاد با شناسه: {BidId} پیدا نشد زمان {Time}", updatebid.Id, DateTime.UtcNow.ToLongTimeString());
            return false;
        }

        public async Task<int> BidCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تعداد پیشنهادها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var count = await _context.Bids.AsNoTracking().CountAsync(cancellationToken);
            _logger.LogInformation("تعداد پیشنهادها: {Count} زمان {Time}", count, DateTime.UtcNow.ToLongTimeString());
            return count;
        }

        public async Task<List<GetBidDto>> GetBidsByRequestId(int requestId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت پیشنهادها با شناسه درخواست: {RequestId} زمان {Time}", requestId, DateTime.UtcNow.ToLongTimeString());
            var bids = await _context.Bids
                .OrderByDescending(x => x.CreateAt)

              .AsNoTracking()
                .Where(b => b.RequestId == requestId && b.Status == StatusBidEnum.WaitingForCustomerConfirmation)
                .Select(b => new GetBidDto
                {
                    Id = b.Id,
                    Description = b.Description,
                    BidPrice = b.BidPrice,
                    BidDate = b.BidDate,
                    Status = b.Status,
                    ExpertName = b.Expert.ApplicationUser.FirstName + " " + b.Expert.ApplicationUser.LastName,
                    RequestName = b.Request.Customer.ApplicationUser.FirstName + " " + b.Request.Customer.ApplicationUser.LastName
                })
                .ToListAsync(cancellationToken);
            _logger.LogInformation("پیشنهادهای با شناسه درخواست: {RequestId} دریافت شدند زمان {Time}", requestId, DateTime.UtcNow.ToLongTimeString());
            return bids;
        }

        public async Task<List<GetBidDto>>? GetBidsByExpertId(int expertId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت پیشنهادها با شناسه کارشناس: {ExpertId} زمان {Time}", expertId, DateTime.UtcNow.ToLongTimeString());
            var bids = await _context.Bids.OrderByDescending(x => x.CreateAt).AsNoTracking()
                .Where(b => b.ExpertId == expertId)
                .Select(b => new GetBidDto
                {
                    Id = b.Id,
                    ExpertId = expertId,
                    RequestId = b.RequestId,
                    Description = b.Description,
                    BidPrice = b.BidPrice,
                    BidDate = b.BidDate,
                    RequestDate = b.Request.RequesteForTime,
                    Status = b.Status,
                    RequestName = b.Request.Title,
                    ExpertName = b.Expert.ApplicationUser.FirstName + " " + b.Expert.ApplicationUser.LastName,
                    CustomerName = b.Request.Customer.ApplicationUser.FirstName + " " + b.Request.Customer.ApplicationUser.LastName
                })
                .ToListAsync(cancellationToken);

            _logger.LogInformation("پیشنهادهای با شناسه کارشناس: {ExpertId} دریافت شدند زمان {Time}", expertId, DateTime.UtcNow.ToLongTimeString());
            return bids;
        }

        public async Task<List<GetBidDto>> GetBids(CancellationToken cancellationToken)
        {
            var result = await _context.Bids.OrderByDescending(x => x.CreateAt).AsNoTracking()
                .Select(b => new GetBidDto
                {
                    Id = b.Id,
                    Description = b.Description,
                    BidPrice = b.BidPrice,
                    BidDate = b.BidDate,
                    Status = b.Status,
                    ExpertName = b.Expert.ApplicationUser.LastName,
                    CustomerName = b.Request.Customer.ApplicationUser.LastName,
                    RequestName = b.Request.Title,
                    ExpertId = b.ExpertId,
                    RequestId = b.RequestId
                })
                .ToListAsync(cancellationToken);

            return result;
        }

        public async Task<bool> DeleteBid(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            _logger.LogInformation("حذف پیشنهاد با شناسه: {BidId} زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            var bid = await _context.Bids.FirstOrDefaultAsync(x => x.Id == active.Id, cancellationToken);
            if (bid is null)
            {
                _logger.LogWarning("پیشنهاد با شناسه: {BidId} پیدا نشد زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            bid.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("پیشنهاد با شناسه: {BidId} به حالت حذف شده تغییر یافت زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken)
        {
            _logger.LogInformation("تغییر وضعیت پیشنهاد با شناسه: {BidId} زمان {Time}", status.Id, DateTime.UtcNow.ToLongTimeString());
            var bid = await _context.Bids.FirstOrDefaultAsync(x => x.Id == status.Id, cancellationToken);
            if (bid is null)
            {
                _logger.LogWarning("پیشنهاد با شناسه: {BidId} پیدا نشد زمان {Time}", status.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            bid.Status = status.Status;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("وضعیت پیشنهاد با شناسه: {BidId} به {Status} تغییر یافت زمان {Time}", status.Id, status.Status, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<bool> CancellBid(int bidId, int expertId, CancellationToken cancellationToken)
        {
            var bid = await _context.Bids
                .FirstOrDefaultAsync(x => x.Id == bidId && x.ExpertId == expertId && x.Status != StatusBidEnum.Success, cancellationToken);

            if (bid == null)
            {
                return false;
            }
            bid.Status = StatusBidEnum.CancelledByExpert;
            var request = await _context.Requests.FirstOrDefaultAsync(x => x.Id == bid.RequestId);
            request.Status = StatusRequestEnum.CancelledByExpert;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }


        public async Task<Bid?> GetBidById(int id, CancellationToken cancellationToken)
        {
            var bid = await _context.Bids
                .Include(x => x.Request)
                .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (bid == null)
            {
                _logger.LogError("پیشنهاد یافت نشد: {BidId} {Time}", id, DateTime.UtcNow.ToLongTimeString());
                return null;
            }
            return bid;
        }
    }
}
