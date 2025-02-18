using AcharDomainCore.Contracts.Bid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.AdminDto;
using AcharDomainCore.Entites;

namespace AcharDomainService
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _repository;
        public AdminService(IAdminRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AdminCount(CancellationToken cancellationToken)
            => await _repository.AdminCount( cancellationToken);


        public async Task<AdminProfDto> GetAdminById(int adminID, CancellationToken cancellationToken)
            => await _repository.GetAdminById(adminID, cancellationToken);


        public async Task<decimal> GetBalanceAdminById(int adminID, CancellationToken cancellationToken)
            => await _repository.GetBalanceAdminById(adminID, cancellationToken);


        public async Task<List<Admin>> GetAllAmin(CancellationToken cancellationToken)
            => await _repository.GetAllAmin(cancellationToken);


        public async Task<bool> UpdateAdmin(AdminProfDto admin, CancellationToken cancellationToken)
            => await _repository.UpdateAdmin(admin, cancellationToken);


        public async Task<bool> DeleteAdmin(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteAdmin(delete, cancellationToken);


        public async Task<bool> UpdateBalance(int id, decimal balance, CancellationToken cancellationToken)
            => await _repository.UpdateBalance(id,balance, cancellationToken);

    }
}
