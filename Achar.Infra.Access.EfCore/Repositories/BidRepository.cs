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

        public async Task<int> CreateBid(Bid bid, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ایجاد پیشنهاد با شناسه: {BidId} زمان {Time}", bid.Id, DateTime.UtcNow.ToLongTimeString());
            bid.CreateAt = DateTime.Now;
            await _context.Bids.AddAsync(bid, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("پیشنهاد ایجاد شد با شناسه: {BidId} زمان {Time}", bid.Id, DateTime.UtcNow.ToLongTimeString());
            return bid.Id;
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
                .Include(b => b.Expert)
                .ThenInclude(x => x.ApplicationUser)
                .Include(b => b.Request)
                .ThenInclude(x => x.Customer)
                .ThenInclude(x => x.ApplicationUser)
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
            var bids = await _context.Bids
                .Include(b => b.Expert)
                .ThenInclude(x => x.ApplicationUser)
                .Include(b => b.Request)
                .ThenInclude(x => x.Customer)
                .ThenInclude(x => x.ApplicationUser)
                .Where(b => b.ExpertId == expertId)
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
            _logger.LogInformation("پیشنهادهای با شناسه کارشناس: {ExpertId} دریافت شدند زمان {Time}", expertId, DateTime.UtcNow.ToLongTimeString());
            return bids;
        }

        public async Task<List<Bid?>> GetBids(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی پیشنهادها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var bids = await _context.Bids.AsNoTracking().ToListAsync(cancellationToken);
            _logger.LogInformation("تعداد پیشنهادهای دریافت شده: {Count} زمان {Time}", bids.Count, DateTime.UtcNow.ToLongTimeString());
            return bids;
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
    }
}
