using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos.HomeServiceDto;

namespace AcharDomainCore.Contracts.HomeService
{
    public interface IHomeServiceRepository
    {
        Task<int> CreateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken);
        Task<bool> UpdateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken);
        Task<int> HomeServiceCount(CancellationToken cancellationToken);
        Task<HomeServiceDto> GetHomeServiceById(int id, CancellationToken cancellationToken);
        Task<List<HomeServiceDto>> GetHomeServices(CancellationToken cancellationToken);
        Task<bool> DeleteHomeService(SoftDeleteDto delete, CancellationToken cancellationToken);
    }
}
