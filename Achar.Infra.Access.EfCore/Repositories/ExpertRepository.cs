using Achar.Infra.Db.Sql;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using AcharDomainCore.Dtos.ExpertDto;
using Microsoft.Extensions.Logging;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class ExpertRepository : IExpertRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<ExpertRepository> _logger;

        public ExpertRepository(AppDbContext context, ILogger<ExpertRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> CreateExpert(Expert expert, CancellationToken cancellationToken)
        {

            _logger.LogInformation("ایجاد کارشناس با شناسه: {ExpertId} زمان {Time}", expert.Id, DateTime.UtcNow.ToLongTimeString());
            expert.ApplicationUser.CreateAt = DateTime.Now;
            await _context.Experts.AddAsync(expert, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("کارشناس ایجاد شد با شناسه: {ExpertId} زمان {Time}", expert.Id, DateTime.UtcNow.ToLongTimeString());
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
            existingExpert.ApplicationUser.ProfileImageUrl = expert.ProfileImageUrl is null ? existingExpert.ApplicationUser.ProfileImageUrl:expert.ProfileImageUrl;
            existingExpert.ApplicationUser.FirstName = expert.FirstName;
            existingExpert.ApplicationUser.LastName = expert.LastName;

            if (existingExpert.Skills == null)
            {
                existingExpert.Skills = new List<AcharDomainCore.Entites.HomeService>();
            }

            existingExpert.Skills.Clear();

            if (expert.ServiceIds != null)
            {
                foreach (var serviceId in expert.ServiceIds)
                {
                    var service = await _context.HomeServices
                        .FirstOrDefaultAsync(x => x.Id == serviceId, cancellationToken);

                    if (service != null)
                    {
                        existingExpert.Skills.Add(service);
                    }
                }
            }

            _context.Experts.Update(existingExpert);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("کارشناس با موفقیا اپدیت شد با شناسه: {ExpertId} زمان {Time}", expert.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }


        public async Task<int> ExpertCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تعداد متخصص‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var count = await _context.Experts
                .AsNoTracking()
                .Where(expert => expert.ApplicationUser.IsDelete == false)
                .CountAsync(cancellationToken);
            _logger.LogInformation("تعداد متخصص‌ها: {Count} زمان {Time}", count, DateTime.UtcNow.ToLongTimeString());
            return count;
        }

        public async Task<ExpertProfDto?> GetExpertById(int id, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts
                .AsNoTracking()
                .Include(e => e.ApplicationUser)
                .Include(e => e.Comments)
                .Include(e => e.City)
                .Include(e => e.Skills)
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

            if (expert == null)
                return null;

            var acceptComments = expert.Comments.Where(c => c.IsAccept).ToList();

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
                Balance = expert.ApplicationUser.Balance,
                Score = acceptComments.Any() ? (int?)acceptComments.Average(c => c.Score) : null,
                NameCity = expert.City.Title,
                CityId = expert.CityId,
                Street = expert.ApplicationUser.Street,
                Skills = expert.Skills?.ToList() ?? new List<AcharDomainCore.Entites.HomeService>()
            };
        }


        public async Task<decimal> GetBalanceExpertById(int expertId, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts.AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == expertId, cancellationToken);
            if (expert == null)
            {
                throw new KeyNotFoundException("Admin not found.");
            }
            _logger.LogInformation("موجودی کارشناس  با شناسه: {ExpertId},{Balance} زمان {Time}", expert.Id,expert.ApplicationUser.Balance, DateTime.UtcNow.ToLongTimeString());

            return expert.ApplicationUser.Balance;
        }

        public async Task<List<ExpertProfDto>> GetExperts(CancellationToken cancellationToken)
        {
            var experts = await _context.Experts
                .AsNoTracking()
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
                    Score = e.Comments.Any(c => c.IsAccept)
                        ? (int?)e.Comments.Where(c => c.IsAccept).Average(c => c.Score)
                        : null,
                    NameCity = e.City.Title,
                    Skills = e.Skills.ToList(),
                    IsActive = e.IsActive,
                    Balance = e.ApplicationUser.Balance
                })
                .ToListAsync(cancellationToken);

            _logger.LogInformation("لیست کارشناسان دریافت شد. زمان: {Time}", DateTime.UtcNow.ToLongTimeString());

            return experts;
        }




        public async Task<bool> DeleteExpert(int id, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (expert is null) return false;
            expert.ApplicationUser.IsDelete = true;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("کارشناس با موفقیا حذف شد با شناسه: {ExpertId} زمان {Time}", expert.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<bool> IActiveExpert(SoftActiveDto activeDto, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == activeDto.Id, cancellationToken);
            if (expert is null) return false;
            expert.IsActive = activeDto.IsActive;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("وضعیت کارشناس باموفقیت تغییر کرد با شناسه: {ExpertId} زمان {Time}", expert.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<List<ExpertProfDto?>> GetTopExpertsByScore(CancellationToken cancellationToken)
        {
            var topExperts = await _context.Experts
                .AsNoTracking()
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
            var expert = await _context.Experts.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (expert is null) return false;
            expert.ApplicationUser.Balance += balance;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("موجودی کارشناس با موفقیا اپدیت شد با شناسه:{Ba;ance} {ExpertId} زمان {Time}",expert.ApplicationUser.Balance, expert.Id, DateTime.UtcNow.ToLongTimeString());

            return true;
        }
    }
}
