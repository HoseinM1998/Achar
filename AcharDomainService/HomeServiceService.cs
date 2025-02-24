using AcharDomainCore.Contracts.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.HomeServiceDto;
using AcharDomainCore.Dtos.SubCategoryDto;
using Microsoft.Extensions.Logging;
using AcharDomainCore.Entites;

namespace AcharDomainService
{
    public class HomeServiceService : IHomeServiceService
    {
        private readonly IHomeServiceRepository _repository;
        private readonly ILogger<HomeServiceService> _logger;

        public HomeServiceService(IHomeServiceRepository repository, ILogger<HomeServiceService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<int> CreateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken)
        {
            var homeServiceId = await _repository.CreateHomeService(homeService, cancellationToken);
            _logger.LogInformation("لایه سرویس: خدمات ایجاد شد با شناسه: {HomeServiceId} زمان {Time}", homeServiceId, DateTime.Now.ToLongTimeString());
            return homeServiceId;
        }

        public async Task<bool> UpdateHomeService(HomeServiceDto homeService, CancellationToken cancellationToken)
        {
            var result = await _repository.UpdateHomeService(homeService, cancellationToken);
            if (!result)
            {
                return false;
            }
            return true;
        }

        public async Task<int> HomeServiceCount(CancellationToken cancellationToken)
        {
            var count = await _repository.HomeServiceCount(cancellationToken);
            return count;
        }

        public async Task<HomeServiceDto> GetHomeServiceById(int id, CancellationToken cancellationToken)
        {
            var homeService = await _repository.GetHomeServiceById(id, cancellationToken);
            if (homeService is null)
            {
                _logger.LogError("لایه سرویس: خدمات با شناسه: {HomeServiceId} پیدا نشد زمان {Time}", id, DateTime.Now.ToLongTimeString());
                throw new Exception("خدمات پیدا نشد.");
            }
            _logger.LogInformation("لایه سرویس: خدمات با شناسه: {HomeServiceId} با موفقیت دریافت شد زمان {Time}", id, DateTime.Now.ToLongTimeString());
            return homeService;
        }

        public async Task<List<HomeServiceDto>> GetHomeServices(CancellationToken cancellationToken)
        {
            var homeServices = await _repository.GetHomeServices(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد خدمات دریافت شده: {Count} زمان {Time}", homeServices.Count, DateTime.Now.ToLongTimeString());
            return homeServices;
        }

        public async Task<List<HomeServiceDto?>> GetAllGetHomeServicesBySubCategory(int subCategory, CancellationToken cancellationToken)
        {
            var homeServices = await _repository.GetAllGetHomeServicesBySubCategory(subCategory, cancellationToken);
            return homeServices;
        }


        public async Task<bool> DeleteHomeService(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteHomeService(delete, cancellationToken);
            if (!result)
            {
                _logger.LogError("لایه سرویس: حذف خدمات با شناسه: {HomeServiceId} ناموفق بود زمان {Time}", delete.Id, DateTime.Now.ToLongTimeString());
                return false;
            }
            _logger.LogInformation("لایه سرویس: خدمات با شناسه: {HomeServiceId} با موفقیت حذف شد زمان {Time}", delete.Id, DateTime.Now.ToLongTimeString());
            return true;
        }

        public async Task<List<HomeServiceGetDto>> GetHomeServiceRequest(CancellationToken cancellationToken)
        {
            var homeServices = await _repository.GetHomeServiceRequest(cancellationToken);
            return homeServices;
        }
    }
}
