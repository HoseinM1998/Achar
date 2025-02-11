using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Expert
{
    public interface ICityRepository
    {
        Task<int> CreateCity(Entites.City city, CancellationToken cancellationToken);
        Task<bool> UpdateCity(Entites.City city, CancellationToken cancellationToken);
        Task<Entites.City> GetCityById(int id, CancellationToken cancellationToken);
        Task<List<Entites.City>> GetCities(CancellationToken cancellationToken);
        Task<bool> IsActiveCity(int id, bool active, CancellationToken cancellationToken);
    }
}
