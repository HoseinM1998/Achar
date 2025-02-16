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

namespace AcharDomainService
{
    public class CustomerService:ICustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> UpdateCustomer(CustomerDto customer, CancellationToken cancellationToken)
            => await _repository.UpdateCustomer(customer, cancellationToken);

        

        public async Task<int> CoustomerCount(CancellationToken cancellationToken)
            => await _repository.CoustomerCount( cancellationToken);


        public async Task<decimal> GetBalanceCustomerById(int customerId, CancellationToken cancellationToken)
            => await _repository.GetBalanceCustomerById(customerId, cancellationToken);

        public async Task<CustomerProfDto> GetCustomerById(int id, CancellationToken cancellationToken)
            => await _repository.GetCustomerById(id, cancellationToken);


        public async Task<List<Customer>> GetCustomers(CancellationToken cancellationToken)
            => await _repository.GetCustomers(cancellationToken);


        public async Task<bool> DeleteCustomer(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteCustomer(delete, cancellationToken);


        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
            => await _repository.UpdateBalance(id,balance, cancellationToken);

    }
}
