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

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AppDbContext _context;

        public AdminRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAdmin(Admin admin, CancellationToken cancellationToken)
        {

            await _context.Admins.AddAsync(admin, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return admin.Id;
        }

        public async Task<int> AdminCount(CancellationToken cancellationToken)
        {
            return await _context.Admins.AsNoTracking().CountAsync(cancellationToken);
        }

        public async Task<AdminProfDto> GetAdminById(int adminID, CancellationToken cancellationToken)
        {
            var admin = await _context.Admins
                .Include(e => e.ApplicationUser)
                .FirstOrDefaultAsync(e => e.Id == adminID, cancellationToken);

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
            var admin = await _context.Admins
                .FirstOrDefaultAsync(a => a.Id == adminID, cancellationToken);
            if (admin == null)
            {
                throw new KeyNotFoundException("Admin not found.");
            }
            return admin.ApplicationUser.Balance;
        }

        public async Task<List<Admin?>> GetAllAmin(CancellationToken cancellationToken)
        {
            return await _context.Admins.Include(x=>x.ApplicationUser).AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateAdmin(AdminProfDto admin, CancellationToken cancellationToken)
        {
            var updateAdmin = await _context.Admins.FirstOrDefaultAsync(x=>x.Id== admin.Id, cancellationToken);
            if (updateAdmin != null)
            {
                updateAdmin.ApplicationUser.UserName = admin.UserName;
                updateAdmin.ApplicationUser.Email = admin.Email;
                updateAdmin.ApplicationUser.PhoneNumber = admin.PhoneNumber;
                updateAdmin.ApplicationUser.FirstName = admin.FirstName;
                updateAdmin.ApplicationUser.LastName= admin.LastName;
                updateAdmin.ApplicationUser.ProfileImageUrl= admin.ProfileImageUrl;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAdmin(int id, CancellationToken cancellationToken)
        {
            var admin = await _context.Admins.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (admin is null) return false;
            admin.ApplicationUser.IsDelete= true;  
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            var updateBalance= await _context.Admins.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (updateBalance != null)
            {
                updateBalance.ApplicationUser.Balance= balance;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
