﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Customer
{
    public interface ICustomerRepository
    {
        Task<int> CreateCustomer(Entites.Customer customer, CancellationToken cancellationToken);
        Task<bool> UpdateCustomer(Entites.Customer customer, CancellationToken cancellationToken);
        Task<Entites.Customer> GetCustomerById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Customer>> GetCustomers(CancellationToken cancellationToken);
        Task<bool> IsActiveCustomer(int id, bool active,CancellationToken cancellationToken);
        Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken);



    }
}
