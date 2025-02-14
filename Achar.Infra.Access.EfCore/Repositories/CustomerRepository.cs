using Achar.Infra.Db.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Dtos;
using AcharDomainCore.Entites;
using AcharDomainCore.Dtos.CommentDto;
using Microsoft.EntityFrameworkCore;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateCustomer(Customer customer, CancellationToken cancellationToken)
        {
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return customer.Id;
        }

        public async Task<bool> UpdateCustomer(Customer customer, CancellationToken cancellationToken)
        {
            var customr = await _context.Customers.FindAsync(customer.Id, cancellationToken);
            if (customr is null) return false;
            customr.Gender = customer.Gender;
            customr.City= customer.City;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Customer> GetCustomerById(int id, CancellationToken cancellationToken)
        {
            return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }

        public async Task<List<Customer>> GetCustomers(CancellationToken cancellationToken)
        {
            return await _context.Customers.AsNoTracking().ToListAsync(cancellationToken);

        }

        public async Task<bool> DeleteCustomer(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(active.Id, cancellationToken);
            if (customer is null) return false;
            customer.ApplicationUser.IsDelete = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.FindAsync(id, cancellationToken);
            if (customer is null) return false;
            customer.ApplicationUser.Balance=balance;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
