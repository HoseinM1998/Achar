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
using AcharDomainCore.Contracts.Image;
using AcharDomainCore.Dtos.SubCategoryDto;

namespace AcharDomainAppService
{
    public class HomeServiceAppService : IHomeServiceAppService
    {
        private readonly IHomeServiceService _service;
        private readonly IImageService _imageService;

        public HomeServiceAppService(IHomeServiceService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        public async Task<int> CreateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken)
        {
            try
            {
                if (homeService.ImageFile is not null)
                {
                    homeService.ImageSrc = await _imageService.UploadImage(homeService.ImageFile!, "category", cancellationToken);
                }
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
                if (homeService.ImageFile is not null)
                {
                    homeService.ImageSrc = await _imageService.UploadImage(homeService.ImageFile!, "category", cancellationToken);
                }
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

        public async Task<HomeServiceDto> GetHomeServiceById(int id, CancellationToken cancellationToken)
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

        public async Task<List<HomeServiceDto>> GetHomeServices(CancellationToken cancellationToken)
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
