using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Achar.Infra.Db.Sql;
using AcharDomainCore.Contracts.BaseData;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDbContext _context;


        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ChangeBalanceAdmin(decimal balance, CancellationToken cancellationToken)
        {
           var admin = await _context.Admins.Include(x=>x.ApplicationUser).FirstOrDefaultAsync(x=>x.Id==1,cancellationToken);
           admin.ApplicationUser.Balance += balance;
           await _context.SaveChangesAsync(cancellationToken);
           return true;

        }

        public async Task<bool> ChangeBalanceAdminExpert(decimal balance, CancellationToken cancellationToken)
        {
            var admin = await _context.Admins.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == 1, cancellationToken);
            admin.ApplicationUser.Balance -= balance;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ChangeBalanceExpert(int expertId, decimal balance, CancellationToken cancellationToken)
        {
            var expert = await _context.Experts.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == expertId, cancellationToken);
            expert.ApplicationUser.Balance += balance;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ChangeBalanceCustomer(int customerId, decimal balance, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == customerId, cancellationToken);
            customer.ApplicationUser.Balance -= balance;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ChangeAddBalanceCustomer(int customerId, decimal balance, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == customerId, cancellationToken);
            customer.ApplicationUser.Balance += balance;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }


        public async Task<decimal> GetBalanceCustomer(int customerId, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Include(x=>x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == customerId, cancellationToken);
            return customer.ApplicationUser.Balance;
        }

        public async Task<decimal> GetPriceHomeService(int homeServiceId, CancellationToken cancellationToken)
        {
            var service = await _context.HomeServices.FirstOrDefaultAsync(x => x.Id == homeServiceId, cancellationToken);
            return service.BasePrice;
        }
    }
}
