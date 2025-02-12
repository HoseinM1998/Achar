using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Expert
{
    public interface IExpertRepository
    {
        Task<int> CreateCustomer(Entites.Expert expert, CancellationToken cancellationToken);
        Task<bool> UpdateCustomer(Entites.Expert expert, CancellationToken cancellationToken);
        Task<Entites.Expert> GetCustomerById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Expert>> GetCustomers(CancellationToken cancellationToken);
        Task<bool> IsActiveCustomer(int id, bool active, CancellationToken cancellationToken);
        Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken);
    }
}
