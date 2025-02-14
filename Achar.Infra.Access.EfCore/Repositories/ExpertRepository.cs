using Achar.Infra.Db.Sql;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using System;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class ExpertRepository : IExpertRepository
    {
        private readonly AppDbContext _context;
        public ExpertRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateExpert(Expert expert, CancellationToken cancellationToken)
        {
            await _context.Experts.AddAsync(expert, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return expert.Id;
        }

        public async Task<bool> UpdateExpert(Expert expert, CancellationToken cancellationToken)
        {
            var customr = await _context.Experts.FindAsync(expert.Id, cancellationToken);
            if (customr is null) return false;
            customr.Gender = expert.Gender;
            customr.City = expert.City;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Expert> GetExpertById(int id, CancellationToken cancellationToken)
        {
            return await _context.Experts.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<List<Expert>> GetExperts(CancellationToken cancellationToken)
        {
            return await _context.Experts.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<bool> DeleteExpert(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts.FindAsync(active.Id, cancellationToken);
            if (expert is null) return false;
            expert.ApplicationUser.IsDelete = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> IActiveExpert(SoftActiveDto activeDto, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts.FindAsync(activeDto.Id, cancellationToken);
            if (expert is null) return false;
            expert.IsActive = activeDto.IsActive;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts.FindAsync(id, cancellationToken);
            if (expert is null) return false;
            expert.ApplicationUser.Balance = balance;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
