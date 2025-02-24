using Achar.Infra.Db.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.HomeServiceDto;
using AcharDomainCore.Dtos.CityDto;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using AcharDomainCore.Dtos.SubCategoryDto;
using AcharDomainCore.Dtos.ExpertDto;
using Microsoft.Extensions.Logging;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class HomeServiceRepository:IHomeServiceRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<HomeServiceRepository> _logger;

        public HomeServiceRepository(AppDbContext context,ILogger<HomeServiceRepository> logger)
        {
            _context = context;
            _logger = logger;
            
        }


        public async Task<int> CreateHomeService(HomeServiceDto homeServiceDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ایجاد خدمت خانگی با عنوان: {Title} زمان {Time}", homeServiceDto.Title, DateTime.Now.ToLongTimeString());
            var homeService = new AcharDomainCore.Entites.HomeService()
            {
                CreateAt = DateTime.Now,
                Title = homeServiceDto.Title,
                ImageSrc = homeServiceDto.ImageSrc,
                BasePrice = homeServiceDto.BasePrice,
                ShortDescription = homeServiceDto.ShortDescription,
                Description = homeServiceDto.Description,
                SubCategoryId = homeServiceDto.SubCategoryId
            };
            await _context.HomeServices.AddAsync(homeService, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("خدمات  ایجاد شد با شناسه: {HomeServiceId} زمان {Time}", homeService.Id, DateTime.Now.ToLongTimeString());
            return homeService.Id;
        }

        public async Task<bool> UpdateHomeService(HomeServiceDto homeServiceDto, CancellationToken cancellationToken)
        {
            var homeService = await _context.HomeServices.FirstOrDefaultAsync(x => x.Id == homeServiceDto.Id, cancellationToken);
            if (homeService is null)
            {
                _logger.LogWarning("خدمات  با شناسه: {HomeServiceId} پیدا نشد زمان {Time}", homeServiceDto.Id, DateTime.Now.ToLongTimeString());
                return false;
            }
            homeService.Title = homeServiceDto.Title;
            homeService.ImageSrc = homeServiceDto.ImageSrc ?? homeService.ImageSrc;
            homeService.BasePrice = homeServiceDto.BasePrice;
            homeService.ShortDescription = homeServiceDto.ShortDescription;
            homeService.Description = homeServiceDto.Description;
            homeService.SubCategoryId = homeServiceDto.SubCategoryId;
            _context.HomeServices.Update(homeService);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("خدمات  با شناسه: {HomeServiceId} با موفقیت بروزرسانی شد زمان {Time}", homeServiceDto.Id, DateTime.Now.ToLongTimeString());
            return true;
        }

        public async Task<int> HomeServiceCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تعداد خدمات  زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var count = await _context.HomeServices
                .AsNoTracking()
                .Where(homeService => homeService.IsDeleted == false)
                .CountAsync(cancellationToken);
            _logger.LogInformation("تعداد  خانگی: {Count} زمان {Time}", count, DateTime.UtcNow.ToLongTimeString());
            return count;
        }

        public async Task<HomeServiceDto> GetHomeServiceById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت خدمات  با شناسه: {HomeServiceId} زمان {Time}", id, DateTime.Now.ToLongTimeString());
            var homeService = await _context.HomeServices.Include(x=>x.SubCategory).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
            if (homeService is null)
            {
                _logger.LogWarning("خدمات  با شناسه: {HomeServiceId} پیدا نشد زمان {Time}", id, DateTime.Now.ToLongTimeString());
                throw new Exception("خدمات  پیدا نشد.");
            }
            _logger.LogInformation("خدمات  با شناسه: {HomeServiceId} با موفقیت دریافت شد زمان {Time}", id, DateTime.Now.ToLongTimeString());
            return new HomeServiceDto
            {
                Id = homeService.Id,
                Title = homeService.Title,
                ImageSrc = homeService.ImageSrc,
                BasePrice = homeService.BasePrice,
                Description = homeService.Description,
                ShortDescription = homeService.ShortDescription,
                SubCategoryId = homeService.SubCategoryId,
                CreateAt = homeService.CreateAt,
                CategoryName = homeService.SubCategory.Title
            };
        }

        public async Task<List<HomeServiceGetDto>> GetHomeServiceRequest( CancellationToken cancellationToken)
        {
            var homeServices = await _context.HomeServices
                .Select(e => new HomeServiceGetDto()
                {
                    Id = e.Id,
                    Title = e.Title,
                    BasePrice = e.BasePrice}).AsNoTracking().ToListAsync(cancellationToken);
            return homeServices;
        }

        public async Task<List<HomeServiceDto>> GetHomeServices(CancellationToken cancellationToken)
        {
            var homeServices = await _context.HomeServices
                .Select(e => new HomeServiceDto()
                {
                    Id = e.Id,
                    Title = e.Title,
                    ImageSrc = e.ImageSrc,
                    Description = e.Description,
                    ShortDescription = e.ShortDescription,
                    BasePrice = e.BasePrice,
                    SubCategoryId = e.SubCategoryId,
                    CategoryName = e.SubCategory.Title,
                    CreateAt = e.CreateAt
                }).AsNoTracking().ToListAsync(cancellationToken);
            return homeServices;
        }

        public async Task<List<HomeServiceDto?>> GetAllGetHomeServicesBySubCategory(int subCategory, CancellationToken cancellationToken)
        {
            var homeServices = await _context.HomeServices
                .Where(e => e.SubCategoryId == subCategory)
                .Select(e => new HomeServiceDto()
                {
                    Id = e.Id,
                    Title = e.Title,
                    ImageSrc = e.ImageSrc,
                    Description = e.Description,
                    ShortDescription = e.ShortDescription,
                    BasePrice = e.BasePrice,
                    SubCategoryId = e.SubCategoryId,
                    CategoryName = e.SubCategory.Title,
                    CreateAt = e.CreateAt
                }).AsNoTracking().ToListAsync(cancellationToken);
            return homeServices;
        }



        public async Task<bool> DeleteHomeService(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            _logger.LogInformation("حذف خدمات  با شناسه: {HomeServiceId} زمان {Time}", active.Id, DateTime.Now.ToLongTimeString());
            var homeService = await _context.HomeServices.FirstOrDefaultAsync(x => x.Id == active.Id, cancellationToken);
            if (homeService is null)
            {
                _logger.LogWarning("خدمات  با شناسه: {HomeServiceId} پیدا نشد زمان {Time}", active.Id, DateTime.Now.ToLongTimeString());
                return false;
            }
            homeService.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("خدمات  با شناسه: {HomeServiceId} به حالت حذف شده تغییر یافت زمان {Time}", active.Id, DateTime.Now.ToLongTimeString());
            return true;
        }

    }
}
