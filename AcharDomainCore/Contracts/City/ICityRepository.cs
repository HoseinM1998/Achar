using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.City
{
    public interface ICityRepository
    {
        Task<int> CreateCity(Entites.City city, CancellationToken cancellationToken);
        Task<bool> UpdateCity(Entites.City city,CancellationToken cancellationToken);
        Task<Entites.City> GetCityById(int id,CancellationToken cancellationToken);
        Task<List<Entites.City>> GetAllCity(CancellationToken cancellationToken);
        Task<bool> IsActiveCity(int cityId, CancellationToken cancellationToken);


    }
}
