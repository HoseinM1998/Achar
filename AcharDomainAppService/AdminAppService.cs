using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.AdminDto;
using AcharDomainCore.Entites;

namespace AcharDomainAppService
{
    public class AdminAppService:IAdminAppService
    {
        private readonly IAdminService _service;
        public AdminAppService(IAdminService service)
        {
            _service = service;
        }
        public async Task<int> AdminCount(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.AdminCount( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateBid: {ex.Message}");
            }
        }

        public Task<Admin> GetAdminById(int adminID, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetBalanceAdminById(int adminID, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Admin>> GetAllAmin(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetAllAmin(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateBid: {ex.Message}");
            }
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
