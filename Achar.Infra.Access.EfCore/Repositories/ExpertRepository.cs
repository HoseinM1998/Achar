using Achar.Infra.Db.Sql;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using AcharDomainCore.Dtos.ExpertDto;

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
            expert.ApplicationUser.CreateAt = DateTime.Now;
            await _context.Experts.AddAsync(expert, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return expert.Id;
        }

        public async Task<bool> UpdateExpert(ExpertProfDto expert, CancellationToken cancellationToken)
        {
            var existingExpert = await _context.Experts
                .Include(e => e.ApplicationUser)
                .Include(e => e.Skills)
                .FirstOrDefaultAsync(e => e.Id == expert.Id, cancellationToken);

            if (existingExpert == null)
            {
                return false;
            }
            existingExpert.Gender = expert.Gender;
            existingExpert.CityId = expert.CityId;
            existingExpert.ApplicationUser.UserName = expert.UserName;
            existingExpert.ApplicationUser.Email = expert.Email;
            existingExpert.ApplicationUser.PhoneNumber = expert.PhoneNumber;
            existingExpert.ApplicationUser.Street = expert.Street;
            existingExpert.ApplicationUser.ProfileImageUrl = expert.ProfileImageUrl;
            existingExpert.ApplicationUser.FirstName = expert.FirstName;
            existingExpert.ApplicationUser.LastName = expert.LastName;
            foreach (var skill in expert.Skills)
            {
                var existingSkill = await _context.HomeServices.FindAsync(skill.Id, cancellationToken);
                if (existingSkill != null)
                {
                    existingExpert.Skills.Add(existingSkill);
                }
            }
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        

        public async Task<int> ExpertCount(CancellationToken cancellationToken)
        {
            return await _context.Experts.AsNoTracking().CountAsync(cancellationToken);
        }

        public async Task<ExpertProfDto?> GetExpertById(int id, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts
                .Include(e => e.ApplicationUser) 
                .Include(e => e.City)
                .Include(e => e.Skills)
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            return new ExpertProfDto
            {
                Id = expert.Id,
                FirstName = expert.ApplicationUser.FirstName,
                LastName = expert.ApplicationUser.LastName,
                UserName = expert.ApplicationUser.UserName,
                Email = expert.ApplicationUser.Email,
                ProfileImageUrl = expert.ApplicationUser.ProfileImageUrl,
                PhoneNumber = expert.ApplicationUser.PhoneNumber,
                Gender = expert.Gender,
                NameCity = expert.City.Title,
                Skills = expert.Skills?.ToList() ?? new List<AcharDomainCore.Entites.HomeService>()
            };
        }

        public async Task<decimal> GetBalanceExpertById(int expertId, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts
                .FirstOrDefaultAsync(a => a.Id == expertId, cancellationToken);
            if (expert == null)
            {
                throw new KeyNotFoundException("Admin not found.");
            }
            return expert.ApplicationUser.Balance;
        }

        public async Task<List<ExpertProfDto?>>? GetExperts(CancellationToken cancellationToken)
        {
            var experts = await _context.Experts
                .Include(e => e.ApplicationUser)
                .Include(e => e.City)
                .Include(e => e.Skills)
                .Select(e => new ExpertProfDto
                {
                    Id = e.Id,
                    FirstName = e.ApplicationUser.FirstName,
                    LastName = e.ApplicationUser.LastName,
                    UserName = e.ApplicationUser.UserName,
                    Email = e.ApplicationUser.Email,
                    ProfileImageUrl = e.ApplicationUser.ProfileImageUrl,
                    PhoneNumber = e.ApplicationUser.PhoneNumber,
                    Gender = e.Gender,
                    NameCity = e.City.Title,
                    Skills = e.Skills.ToList(),
                    IsActive = e.IsActive,
                    Balance = e.ApplicationUser.Balance

                })
                .ToListAsync(cancellationToken);
            return experts;

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

        public async Task<List<ExpertProfDto?>> GetTopExpertsByScore(CancellationToken cancellationToken)
        {
            var topExperts = await _context.Experts
                .Include(e=>e.ApplicationUser)
                .Include(e => e.City)
                .Where(e => e.IsActive)
                .OrderByDescending(e => e.Score)
                .Take(10) 
                .Select(e => new ExpertProfDto
                {
                    Id = e.Id,
                    FirstName = e.ApplicationUser.FirstName,
                    LastName = e.ApplicationUser.LastName,
                    UserName = e.ApplicationUser.UserName,
                    Email = e.ApplicationUser.Email,
                    ProfileImageUrl = e.ApplicationUser.ProfileImageUrl,
                    PhoneNumber = e.ApplicationUser.PhoneNumber,
                    Gender = e.Gender,
                    NameCity = e.City.Title,
                    Skills = e.Skills,
                    IsActive = e.IsActive
                })
                .ToListAsync(cancellationToken);

            return topExperts;
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
