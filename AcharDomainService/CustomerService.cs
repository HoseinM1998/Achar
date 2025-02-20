using AcharDomainCore.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Entites;
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository repository, ILogger<CustomerService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> UpdateCustomer(CustomerProfDto customer, CancellationToken cancellationToken)
        {
            var result = await _repository.UpdateCustomer(customer, cancellationToken);
            _logger.LogInformation("لایه سرویس: بروزرسانی مشتری با شناسه: {CustomerId} زمان {Time}", customer.Id, DateTime.Now.ToLongTimeString());
            return result;
        }

        public async Task<int> CoustomerCount(CancellationToken cancellationToken)
        {
            var count = await _repository.CoustomerCount(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد مشتریان دریافت شده: {Count} زمان {Time}", count, DateTime.Now.ToLongTimeString());
            return count;
        }

        public async Task<decimal> GetBalanceCustomerById(int customerId, CancellationToken cancellationToken)
        {
            var balance = await _repository.GetBalanceCustomerById(customerId, cancellationToken);
            _logger.LogInformation("لایه سرویس: دریافت موجودی مشتری با شناسه: {CustomerId} زمان {Time}", customerId, DateTime.Now.ToLongTimeString());
            return balance;
        }

        public async Task<CustomerProfDto> GetCustomerById(int id, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetCustomerById(id, cancellationToken);
            _logger.LogInformation("لایه سرویس: دریافت مشتری با شناسه: {CustomerId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
            return customer;
        }

        public async Task<List<CustomerGetAll>> GetCustomers(CancellationToken cancellationToken)
        {
            var customers = await _repository.GetCustomers(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد مشتریان دریافت شده: {Count} زمان {Time}", customers.Count, DateTime.Now.ToLongTimeString());
            return customers;
        }

        public async Task<bool> DeleteCustomer(int delete, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteCustomer(delete, cancellationToken);
            _logger.LogInformation("لایه سرویس: حذف مشتری با شناسه: {CustomerId} زمان {Time}", delete, DateTime.Now.ToLongTimeString());
            return result;
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            var result = await _repository.UpdateBalance(id, balance, cancellationToken);
            _logger.LogInformation("لایه سرویس: بروزرسانی موجودی مشتری با شناسه: {CustomerId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
            return result;
        }
    }
}
