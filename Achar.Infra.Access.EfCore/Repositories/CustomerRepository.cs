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
using Microsoft.Extensions.Logging;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(AppDbContext context, ILogger<CustomerRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> CreateCustomer(Customer customer, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ایجاد مشتری با شناسه: {CustomerId} زمان {Time}", customer.Id, DateTime.UtcNow.ToLongTimeString());
            customer.ApplicationUser.CreateAt = DateTime.Now;
            await _context.Customers.AddAsync(customer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("مشتری ایجاد شد با شناسه: {CustomerId} زمان {Time}", customer.Id, DateTime.UtcNow.ToLongTimeString());
            return customer.Id;
        }

        public async Task<bool> UpdateCustomer(CustomerProfDto customer, CancellationToken cancellationToken)
        {
            _logger.LogInformation("بروزرسانی مشتری با شناسه: {CustomerId} زمان {Time}", customer.Id, DateTime.UtcNow.ToLongTimeString());
            var customr = await _context.Customers.Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(x => x.Id == customer.Id, cancellationToken);
            if (customr is null)
            {
                _logger.LogWarning("مشتری با شناسه: {CustomerId} پیدا نشد زمان {Time}", customer.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            customr.Gender = customer.Gender;
            customr.CityId = customer.CityId;
            customr.ApplicationUser.UserName = customer.UserName;
            customr.ApplicationUser.Email = customer.Email;
            customr.ApplicationUser.Balance = customer.Balance;
            customr.ApplicationUser.PhoneNumber = customer.PhoneNumber;
            customr.ApplicationUser.Street = customer.Street;
            customr.ApplicationUser.ProfileImageUrl = customer.ProfileImageUrl is null ? customr.ApplicationUser.ProfileImageUrl: customer.ProfileImageUrl;
            customr.ApplicationUser.FirstName = customer.FirstName;
            customr.ApplicationUser.LastName = customer.LastName;
            _context.Customers.Update(customr);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("مشتری با شناسه: {CustomerId} با موفقیت بروزرسانی شد زمان {Time}", customer.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }


        public async Task<int> CoustomerCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تعداد مشتری‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var count = await _context.Customers
                .AsNoTracking()
                .Include(customer => customer.ApplicationUser)
                .Where(customer => customer.ApplicationUser.IsDelete == false)
                .CountAsync(cancellationToken);
            _logger.LogInformation("تعداد مشتری‌ها: {Count} زمان {Time}", count, DateTime.UtcNow.ToLongTimeString());
            return count;
        }



        public async Task<decimal> GetBalanceCustomerById(int CustomerId, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت موجودی مشتری با شناسه: {CustomerId} زمان {Time}", CustomerId, DateTime.UtcNow.ToLongTimeString());
            var customer = await _context.Customers
                .Include(c => c.ApplicationUser)
                .FirstOrDefaultAsync(a => a.Id == CustomerId, cancellationToken);
            if (customer is null)
            {
                _logger.LogWarning("مشتری با شناسه: {CustomerId} پیدا نشد زمان {Time}", CustomerId, DateTime.UtcNow.ToLongTimeString());
                throw new Exception("مشتری پیدا نشد.");
            }
            _logger.LogInformation("موجودی مشتری با شناسه: {CustomerId} برابر است با {Balance} زمان {Time}", CustomerId, customer.ApplicationUser.Balance, DateTime.UtcNow.ToLongTimeString());
            return customer.ApplicationUser.Balance;
        }

        public async Task<CustomerProfDto> GetCustomerById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت مشتری با شناسه: {CustomerId} زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            var customer = await _context.Customers.AsNoTracking()
                .Include(c => c.ApplicationUser)
                .Include(c => c.City)
                .FirstOrDefaultAsync(c => c.Id == id, cancellationToken);
            if (customer is null)
            {
                _logger.LogWarning("مشتری با شناسه: {CustomerId} پیدا نشد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
                throw new Exception("مشتری پیدا نشد.");
            }
            _logger.LogInformation("مشتری با شناسه: {CustomerId} با موفقیت دریافت شد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
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
                Namecity = customer.City.Title,
                CityId = customer.CityId,
                Street = customer.ApplicationUser.Street,
                ApplictaionUserId = customer.ApplicationUserId,
                Balance = customer.ApplicationUser.Balance
            };
        }

        public async Task<List<CustomerGetAll?>> GetCustomers(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی مشتری‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var customer = await _context.Customers
              .AsNoTracking()
                .Select(e => new CustomerGetAll()
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
                    Balance = e.ApplicationUser.Balance
                }).AsNoTracking()
                .ToListAsync(cancellationToken);
            _logger.LogInformation("تعداد مشتری‌های دریافت شده: {Count} زمان {Time}", customer.Count, DateTime.UtcNow.ToLongTimeString());
            return customer;
        }

        public async Task<bool> DeleteCustomer(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("حذف مشتری با شناسه: {CustomerId} زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            var customer = await _context.Customers.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (customer is null)
            {
                _logger.LogWarning("مشتری با شناسه: {CustomerId} پیدا نشد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            customer.ApplicationUser.IsDelete = true;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("مشتری با شناسه: {CustomerId} به حالت حذف شده تغییر یافت زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            _logger.LogInformation("بروزرسانی موجودی مشتری با شناسه: {CustomerId} زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            var customer = await _context.Customers.Include(x => x.ApplicationUser).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (customer is null)
            {
                _logger.LogWarning("مشتری با شناسه: {CustomerId} پیدا نشد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            customer.ApplicationUser.Balance += balance;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("موجودی مشتری با شناسه: {CustomerId} به {Balance} بروزرسانی شد زمان {Time}", id, balance, DateTime.UtcNow.ToLongTimeString());
            return true;
        }
    }
}
