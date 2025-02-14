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

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class BidRepository : IBidRepository
    {
        private readonly AppDbContext _context;
        public BidRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateBid(Bid bid, CancellationToken cancellationToken)
        {
            await _context.Bids.AddAsync(bid, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return bid.Id;
        }

        public async Task<bool> UpdateBid(BidUpdateDto updatebid, CancellationToken cancellationToken)
        {
            var updateBid = await _context.Bids.FindAsync(updatebid.Id, cancellationToken);
            if (updateBid != null)
            {
                updateBid.Description=updatebid.Description;
                updateBid.BidPrice = updatebid.BidPrice;
                updateBid.BidDate = updatebid.BidDate;
                
                return true;
            }
            return false;
        }

        public async Task<Bid> GetBidById(int id, CancellationToken cancellationToken)
        {
            return await _context.Bids.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        }

        public async Task<List<Bid>> GetBids(CancellationToken cancellationToken)
        {
            return await _context.Bids.AsNoTracking().ToListAsync(cancellationToken);

        }

        public async Task<bool> DeleteBid(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            var bid = await _context.Bids.FindAsync(active.Id, cancellationToken);
            if (bid is null) return false;
            bid.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }


        public async Task<bool> ChangebidStatus(BidStatusDto status, CancellationToken cancellationToken)
        {
            var bid = await _context.Bids.FindAsync(status.Id, cancellationToken);
            if (bid is null) return false;
            bid.Status = status.Status;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
