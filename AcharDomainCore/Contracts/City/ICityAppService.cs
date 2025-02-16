using AcharDomainCore.Dtos.CityDto;
using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.City
{
    public interface ICityAppService
    {
        Task<int> CreateCity(CityDto city, CancellationToken cancellationToken);
        Task<bool> UpdateCity(CityDto city, CancellationToken cancellationToken);
        Task<Entites.City> GetCityById(int id, CancellationToken cancellationToken);
        Task<List<Entites.City>> GetAllCity(CancellationToken cancellationToken);
        Task<bool> DeleteCity(SoftDeleteDto delete, CancellationToken cancellationToken);
    }
}
