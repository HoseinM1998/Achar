using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos.CityDto;

namespace AcharDomainCore.Contracts.City
{
    public interface ICityRepository
    {
        Task<int> CreateCity(CityDto city, CancellationToken cancellationToken);
        Task<bool> UpdateCity(CityDto city,CancellationToken cancellationToken);
        Task<Entites.City> GetCityById(int id,CancellationToken cancellationToken);
        Task<List<Entites.City>> GetAllCity(CancellationToken cancellationToken);
        Task<bool> IsActiveCity(SoftDeleteDto active, CancellationToken cancellationToken);


    }
}
