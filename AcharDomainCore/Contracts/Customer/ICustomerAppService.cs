using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Customer
{
    public interface ICustomerAppService
    {
        Task<bool> UpdateCustomer(CustomerProfDto customer, CancellationToken cancellationToken);
        Task<int> CoustomerCount(CancellationToken cancellationToken);
        Task<decimal> GetBalanceCustomerById(int CustomerId, CancellationToken cancellationToken);
        Task<CustomerProfDto> GetCustomerById(int id, CancellationToken cancellationToken);
        Task<List<CustomerGetAll>> GetCustomers(CancellationToken cancellationToken);
        Task<bool> DeleteCustomer(int delete, CancellationToken cancellationToken);
        Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken);
    }
}
