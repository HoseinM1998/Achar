using AcharDomainCore.Dtos.AdminDto;
using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Admin
{
    public interface IAdminAppService
    {
        Task<int> AdminCount(CancellationToken cancellationToken);
        Task<AdminProfDto> GetAdminById(int adminID, CancellationToken cancellationToken);
        Task<decimal> GetBalanceAdminById(int adminID, CancellationToken cancellationToken);
        Task<List<Entites.Admin>> GetAllAmin(CancellationToken cancellationToken);
        Task<bool> UpdateAdmin(AdminProfDto admin, CancellationToken cancellationToken);
        Task<bool> DeleteAdmin(SoftDeleteDto delete, CancellationToken cancellationToken);
        Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken);
    }
}
