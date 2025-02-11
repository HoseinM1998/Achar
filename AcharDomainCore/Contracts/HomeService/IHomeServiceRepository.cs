using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.HomeService
{
    public interface IHomeServiceRepository
    {
        Task<int> CreateHomeService(Entites.HomeService homeService, CancellationToken cancellationToken);
        Task<bool> UpdateHomeService(Entites.HomeService homeService, CancellationToken cancellationToken);
        Task<Entites.HomeService> GetHomeServiceById(int id, CancellationToken cancellationToken);
        Task<List<Entites.HomeService>> GetHomeServices(CancellationToken cancellationToken);
        Task<bool> IsActiveHomeService(int id, bool active, CancellationToken cancellationToken);
    }
}
