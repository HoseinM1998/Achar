using AcharDomainCore.Contracts.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CityDto;
using AcharDomainCore.Entites;

namespace AcharDomainAppService
{
    public class CityAppService :ICityAppService
    {
        private readonly ICityService _service;
        public CityAppService(ICityService service)
        {
            _service = service;
        }

        public async Task<int> CreateCity(CityDto city, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.CreateCity(city, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateCity: {ex.Message}");
            }
        }

        public async Task<bool> UpdateCity(CityDto city, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UpdateCity(city, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateCity: {ex.Message}");
            }
        }

        public async Task<City> GetCityById(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetCityById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetCityById: {ex.Message}");
            }
        }

        public async Task<List<City>> GetAllCity(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetAllCity(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetAllCity: {ex.Message}");
            }
        }

        public async Task<bool> DeleteCity(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteCity(delete, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DeleteCity: {ex.Message}");
            }
        }
    }
}
