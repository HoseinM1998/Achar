using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Admin
{
    public interface IAdminRepository
    {
         Task<int> CreateAdmin(Entites.Admin admin, CancellationToken cancellationToken);
         Task<Entites.Admin> GetAdminById(int adminID,CancellationToken cancellationToken);
         Task<List<Entites.Admin>> GetAllAmin(CancellationToken cancellationToken);
         Task<bool> UpdateAdmin(Entites.Admin admin, CancellationToken cancellationToken);
         Task<bool> IsActiveAdmin(int id, bool delete, CancellationToken  cancellationToken);
    }
}
