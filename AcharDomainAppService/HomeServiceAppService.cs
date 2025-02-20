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
using Microsoft.Extensions.Logging;

namespace AcharDomainAppService
{
    public class HomeServiceAppService : IHomeServiceAppService
    {
        private readonly IHomeServiceService _service;
        private readonly IImageService _imageService;
        private readonly ILogger<HomeServiceAppService> _logger;

        public HomeServiceAppService(IHomeServiceService service, IImageService imageService, ILogger<HomeServiceAppService> logger)
        {
            _service = service;
            _imageService = imageService;
            _logger = logger;
        }

        public async Task<int> CreateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: ایجاد خدمات زمان {Time}", DateTime.Now.ToLongTimeString());
                if (homeService.ImageFile is not null)
                {
                    homeService.ImageSrc = await _imageService.UploadImage(homeService.ImageFile!, "category", cancellationToken);
                }
                var result = await _service.CreateHomeService(homeService, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: ایجادخدمات با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در عملیات ایجادخدمات: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error CreateHomeService: {ex.Message}");
            }
        }

        public async Task<bool> UpdateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی خدمات با شناسه: {HomeServiceId} زمان {Time}", homeService.Id, DateTime.Now.ToLongTimeString());
                if (homeService.ImageFile is not null)
                {
                    homeService.ImageSrc = await _imageService.UploadImage(homeService.ImageFile!, "category", cancellationToken);
                }
                var result = await _service.UpdateHomeService(homeService, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی خدمات با موفقیت انجام شد با شناسه: {HomeServiceId} زمان {Time}", homeService.Id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در به‌روزرسانی خدمات: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error UpdateHomeService: {ex.Message}");
            }
        }

        public async Task<int> HomeServiceCount(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات شمارش خدمات زمان {Time}", DateTime.Now.ToLongTimeString());
                var result = await _service.HomeServiceCount(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات شمارشخدمات با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در عملیات شمارشخدمات: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error HomeServiceCount: {ex.Message}");
            }
        }

        public async Task<HomeServiceDto> GetHomeServiceById(int id, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: دریافت خدمات با شناسه: {Id} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                var result = await _service.GetHomeServiceById(id, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: دریافت خدمات با موفقیت انجام شد برای شناسه: {Id} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت خدمات: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error GetHomeServiceById: {ex.Message}");
            }
        }

        public async Task<List<HomeServiceDto>> GetHomeServices(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات دریافت همه خدمات زمان {Time}", DateTime.Now.ToLongTimeString());
                var result = await _service.GetHomeServices(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات دریافت همه خدمات با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت همه خدمات: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error GetHomeServices: {ex.Message}");
            }
        }

        public async Task<bool> DeleteHomeService(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات حذف خدمات با شناسه: {Id} زمان {Time}", delete.Id, DateTime.Now.ToLongTimeString());
                var result = await _service.DeleteHomeService(delete, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات حذف خدمات با موفقیت انجام شد برای شناسه: {Id} زمان {Time}", delete.Id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در حذف خدمات: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error DeleteHomeService: {ex.Message}");
            }
        }
    }
}
