﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.AdminDto;

namespace AcharDomainCore.Contracts.Admin
{
    public interface IAdminRepository
    {
         Task<int> CreateAdmin(Entites.Admin admin, CancellationToken cancellationToken);
         Task<int> AdminCount(CancellationToken cancellationToken);
        Task<AdminProfDto> GetAdminById(int adminID,CancellationToken cancellationToken);
        Task<decimal> GetBalanceAdminById(int adminID, CancellationToken cancellationToken);
        Task<List<Entites.Admin?>> GetAllAmin(CancellationToken cancellationToken);
         Task<bool> UpdateAdmin(AdminProfDto admin, CancellationToken cancellationToken);
         Task<bool> DeleteAdmin(int id, CancellationToken  cancellationToken);
         Task<bool> UpdateBalance(int id,decimal  balance, CancellationToken cancellationToken);

    }
}
