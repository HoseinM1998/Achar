using Achar.Infra.Db.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.AdminDto;
using Microsoft.Extensions.Logging;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<AdminRepository> _logger;

        public AdminRepository(AppDbContext context, ILogger<AdminRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> CreateAdmin(Admin admin, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ایجاد ادمین با شناسه: {AdminId}زمان{Time}", admin.Id, DateTime.UtcNow.ToLongTimeString());
            await _context.Admins.AddAsync(admin, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("ادمین ایجاد شد با شناسه: {AdminId}زمان{Time} ", admin.Id, DateTime.UtcNow.ToLongTimeString());
            return admin.Id;
        }

        public async Task<int> AdminCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه ریپازیتوری دریافت تعداد ادمین‌هازمان{Time} ", DateTime.UtcNow.ToLongTimeString());
            var count = await _context.Admins.AsNoTracking().CountAsync(cancellationToken);
            _logger.LogInformation("لایه ریپازیتوری تعداد ادمین‌ها: {Count}", count, DateTime.UtcNow.ToLongTimeString());
            return count;
        }

        public async Task<AdminProfDto> GetAdminById(int adminID, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت ادمین با شناسه: {AdminID}زمان{Time} ", adminID, DateTime.UtcNow.ToLongTimeString());
            var admin = await _context.Admins
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(e => e.Id == adminID, cancellationToken);
            if (admin == null)
            {
                _logger.LogWarning("ادمین با شناسه: {AdminID} زمان{Time} پیدا نشد لایه ریپازیتوری", adminID, DateTime.UtcNow.ToLongTimeString());
                throw new Exception("ادمین پیدا نشد.");
            }
            _logger.LogInformation("ادمین با شناسه: {AdminID} زمان{Time} با موفقیت دریافت شد لایه ریپازیتوری", adminID, DateTime.UtcNow.ToLongTimeString());
            return new AdminProfDto()
            {
                Id = admin.Id,
                FirstName = admin.ApplicationUser.FirstName,
                LastName = admin.ApplicationUser.LastName,
                UserName = admin.ApplicationUser.UserName,
                Email = admin.ApplicationUser.Email,
                ProfileImageUrl = admin.ApplicationUser.ProfileImageUrl,
                PhoneNumber = admin.ApplicationUser.PhoneNumber,
                Balance = admin.ApplicationUser.Balance,
            };
        }

        public async Task<decimal> GetBalanceAdminById(int adminID, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت موجودی ادمین با شناسه: {AdminID} لایه ریپازیتوری زمان{Time} ", adminID, DateTime.UtcNow.ToLongTimeString());
            var admin = await _context.Admins.FirstOrDefaultAsync(a => a.Id == adminID, cancellationToken);
            if (admin == null)
            {
                _logger.LogWarning("ادمین با شناسه: {AdminID} زمان{Time} پیدا نشد", adminID, DateTime.UtcNow.ToLongTimeString());
                throw new Exception("ادمین پیدا نشد.");
            }
            _logger.LogInformation("موجودی ادمین با شناسه: {AdminID} برابر است با {Balance}  زمان{Time} لایه ریپازیتوری", adminID, admin.ApplicationUser.Balance);
            return admin.ApplicationUser.Balance;
        }

        public async Task<List<Admin?>> GetAllAmin(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی ادمین‌ها لایه ریپازیتوری زمان{Time} ", DateTime.UtcNow.ToLongTimeString());
            var admins = await _context.Admins.Include(x => x.ApplicationUser).AsNoTracking().ToListAsync(cancellationToken);
            _logger.LogInformation(" لایه ریپازیتوری تعداد ادمین‌های دریافت شده زمان{Time} : {Count}", admins.Count, DateTime.UtcNow.ToLongTimeString());
            return admins;
        }

        public async Task<bool> UpdateAdmin(AdminProfDto admin, CancellationToken cancellationToken)
        {
            _logger.LogInformation(" لایه ریپازیتوری بروزرسانی ادمین با شناسه: {AdminID} زمان{Time} ", admin.Id);
            var updateAdmin = await _context.Admins.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == admin.Id, cancellationToken);
            if (updateAdmin != null)
            {
                updateAdmin.ApplicationUser.UserName = admin.UserName;
                updateAdmin.ApplicationUser.Email = admin.Email;
                updateAdmin.ApplicationUser.PhoneNumber = admin.PhoneNumber;
                updateAdmin.ApplicationUser.FirstName = admin.FirstName;
                updateAdmin.ApplicationUser.LastName = admin.LastName;
                updateAdmin.ApplicationUser.ProfileImageUrl = admin.ProfileImageUrl;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("ادمین با شناسه: {AdminID}  لایه ریپازیتوری با موفقیت بروزرسانی شدزمان{Time} ", admin.Id);
                return true;
            }
            _logger.LogWarning("ادمین با شناسه: {AdminID} زمان{Time} پیدا نشد", admin.Id, DateTime.UtcNow.ToLongTimeString());
            return false;
        }

        public async Task<bool> DeleteAdmin(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation(" لایه ریپازیتوری حذف ادمین با شناسه: {AdminID}", id);
            var admin = await _context.Admins.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (admin is null)
            {
                _logger.LogWarning("ادمین با شناسه: {AdminID}  لایه ریپازیتوری پیدا نشدزمان{Time}", id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            admin.ApplicationUser.IsDelete = true;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("ادمین با شناسه: {AdminID}  زمان{Time}لایه ریپازیتوری به حالت حذف شده تغییر یافت", id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            _logger.LogInformation(" لایه ریپازیتوری بروزرسانی موجودی ادمین با شناسه: {AdminID} زمان{Time}", id);
            var updateBalance = await _context.Admins.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (updateBalance != null)
            {
                updateBalance.ApplicationUser.Balance = balance;
                await _context.SaveChangesAsync(cancellationToken);
                _logger.LogInformation("موجودی ادمین با شناسه: {AdminID} به {Balance} بروزرسانی شد لایه ریپازیتوریزمان{Time}", id, balance, DateTime.UtcNow.ToLongTimeString());
                return true;
            }
            _logger.LogWarning("ادمین با شناسه: {AdminID} پیدا نشد لایه ریپازیتوریزمان{Time}", id, DateTime.UtcNow.ToLongTimeString());
            return false;
        }
    }
}
