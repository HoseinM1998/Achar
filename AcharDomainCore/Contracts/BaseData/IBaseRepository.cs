using AcharDomainCore.Dtos.BidDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.BaseData
{
    public interface IBaseRepository
    {
        Task<bool> ChangeBalanceAdmin(decimal balance, CancellationToken cancellationToken);
        Task<bool> ChangeBalanceAdminExpert(decimal balance, CancellationToken cancellationToken);
        Task<bool> ChangeBalanceExpert(int expertId,decimal balance, CancellationToken cancellationToken);
        Task<bool> ChangeBalanceCustomer(int CustomerId,decimal balance, CancellationToken cancellationToken);
        Task<bool> ChangeAddBalanceCustomer(int CustomerId, decimal balance, CancellationToken cancellationToken);
        Task<decimal> GetPriceHomeService(int homeServiceId, CancellationToken cancellationToken);
        Task<decimal> GetBalanceCustomer(int customerId, CancellationToken cancellationToken);




    }
}
