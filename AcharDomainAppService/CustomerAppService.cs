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

namespace AcharDomainAppService
{
    public class CustomerAppService : ICustomerAppService
    {
        private readonly ICustomerService _service;
        public CustomerAppService(ICustomerService service)
        {
            _service = service;
        }

        public async Task<bool> UpdateCustomer(CustomerDto customer, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UpdateCustomer(customer, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateCustomer: {ex.Message}");
            }
        }

        public async Task<int> CoustomerCount(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.CoustomerCount(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CoustomerCount: {ex.Message}");
            }
        }

        public async Task<decimal> GetBalanceCustomerById(int customerId, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetBalanceCustomerById(customerId, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetBalanceCustomerById: {ex.Message}");
            }
        }

        public async Task<CustomerProfDto> GetCustomerById(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetCustomerById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetCustomerById: {ex.Message}");
            }
        }

        public async Task<List<Customer>> GetCustomers(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetCustomers(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetCustomers: {ex.Message}");
            }
        }

        public async Task<bool> DeleteCustomer(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteCustomer(delete, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DeleteCustomer: {ex.Message}");
            }
        }

        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UpdateBalance(id, balance, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateBalance: {ex.Message}");
            }
        }
    }
}
