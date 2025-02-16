using AcharDomainCore.Contracts.Expert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.HomeServiceDto;
using AcharDomainCore.Entites;

namespace AcharDomainAppService
{
    public class HomeServiceAppService : IHomeServiceAppService
    {
        private readonly IHomeServiceService _service;
        public HomeServiceAppService(IHomeServiceService service)
        {
            _service = service;
        }

        public async Task<int> CreateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.CreateHomeService(homeService, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateHomeService: {ex.Message}");
            }
        }

        public async Task<bool> UpdateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.UpdateHomeService(homeService, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateHomeService: {ex.Message}");
            }
        }

        public async Task<int> HomeServiceCount(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.HomeServiceCount( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error HomeServiceCount: {ex.Message}");
            }
        }

        public async Task<AcharDomainCore.Entites.HomeService> GetHomeServiceById(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetHomeServiceById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetHomeServiceById: {ex.Message}");
            }
        }

        public async Task<List<AcharDomainCore.Entites.HomeService>> GetHomeServices(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetHomeServices( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetHomeServices: {ex.Message}");
            }
        }

        public async Task<bool> DeleteHomeService(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteHomeService(delete, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DeleteHomeService: {ex.Message}");
            }
        }
    }
}
