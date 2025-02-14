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

        public async Task<Admin> GetAdminById(int adminID, CancellationToken cancellationToken)
        {
            return await _context.Admins.AsNoTracking().FirstOrDefaultAsync(p => p.Id == adminID, cancellationToken);
        }

        public async Task<List<Admin>> GetAllAmin(CancellationToken cancellationToken)
        {
            return await _context.Admins.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateAdmin(AdminDto admin, CancellationToken cancellationToken)
        {
            var updateAdmin = await _context.Admins.FindAsync(admin.Id, cancellationToken);
            if (updateAdmin != null)
            {
                updateAdmin.ApplicationUser.FirstName = admin.FirstName;
                updateAdmin.ApplicationUser.LastName= admin.LastName;
                updateAdmin.ApplicationUser.ProfileImageUrl= admin.ProfileImageUrl;
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAdmin(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            var admin = await _context.Admins.FindAsync(delete.Id, cancellationToken);
            if (admin is null) return false;
            admin.ApplicationUser.IsDelete= delete.IsDeleted;  
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            var updateBalance= await _context.Admins.FindAsync(id, cancellationToken);
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
