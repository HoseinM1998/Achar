using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.AdminDto;
using AcharDomainCore.Entites;

namespace AcharDomainAppService
{
    public class AdminAppService:IAdminAppService
    {
        public Task<int> AdminCount(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Admin> GetAdminById(int adminID, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetBalanceAdminById(int adminID, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Admin>> GetAllAmin(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAdmin(AdminDto admin, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAdmin(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
