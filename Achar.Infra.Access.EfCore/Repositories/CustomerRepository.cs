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
using AcharDomainCore.Dtos.CustomerDto;
using Microsoft.EntityFrameworkCore;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> CreateCustomer(Customer customer, CancellationToken cancellationToken)
        {
            customer.ApplicationUser.CreateAt = DateTime.Now;
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return customer.Id;
        }

        public async Task<bool> UpdateCustomer(CustomerDto customer, CancellationToken cancellationToken)
        {
            var customr = await _context.Customers.Include(c => c.ApplicationUser) // لود کردن ApplicationUser
                .FirstOrDefaultAsync(x => x.Id == customer.Id, cancellationToken);
            if (customr is null) return false;
            customr.Gender = customer.Gender;
            customr.CityId = customer.CityId;
            customr.ApplicationUser.UserName = customer.UserName;
            customr.ApplicationUser.Email = customer.Email;
            customr.ApplicationUser.PhoneNumber = customer.PhoneNumber;
            customr.ApplicationUser.Street = customer.Street;
            customr.ApplicationUser.ProfileImageUrl = customer.ProfileImageUrl;
            customr.ApplicationUser.FirstName = customer.FirstName;
            customr.ApplicationUser.LastName = customer.LastName;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<int> CoustomerCount(CancellationToken cancellationToken)
        {
            return await _context.Customers.AsNoTracking().CountAsync(cancellationToken);
        }

        public async Task<decimal> GetBalanceCustomerById(int CustomerId, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(a => a.Id == CustomerId, cancellationToken);

            return customer.ApplicationUser.Balance;
        }


        public async Task<CustomerProfDto> GetCustomerById(int id, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers
                .Include(c => c.ApplicationUser) // لود کردن ApplicationUser
                .Include(c => c.City) // لود کردن City (اگر نیاز است)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken); // پیدا کردن مشتری بر اساس id

            return new CustomerProfDto
            {
                Id = customer.Id,
                FirstName = customer.ApplicationUser.FirstName,
                LastName = customer.ApplicationUser.LastName,
                UserName = customer.ApplicationUser.UserName,
                Email = customer.ApplicationUser.Email,
                ProfileImageUrl = customer.ApplicationUser.ProfileImageUrl,
                PhoneNumber = customer.ApplicationUser.PhoneNumber,
                Gender = customer.Gender,
                Namecity = customer.City.Title
            };

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
            customer.ApplicationUser.Balance = balance;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
