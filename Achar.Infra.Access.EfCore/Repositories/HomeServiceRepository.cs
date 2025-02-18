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

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class HomeServiceRepository:IHomeServiceRepository
    {
        private readonly AppDbContext _context;
        public HomeServiceRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<int> CreateHomeService(HomeServiceDto homeServiceDto, CancellationToken cancellationToken)
        {
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
            return homeService.Id;
        }

        public async Task<bool> UpdateHomeService(HomeServiceDto homeServiceDto, CancellationToken cancellationToken)
        {
            var homeService = await _context.HomeServices.FindAsync(homeServiceDto.Id, cancellationToken);
            if (homeService is null) return false;
            homeService.Title = homeServiceDto.Title;
            homeService.ImageSrc = homeServiceDto.ImageSrc;
            homeService.BasePrice = homeServiceDto.BasePrice;
            homeService.ShortDescription = homeServiceDto.ShortDescription;
            homeService.Description = homeServiceDto.Description;
            homeService.SubCategoryId = homeServiceDto.SubCategoryId;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<int> HomeServiceCount(CancellationToken cancellationToken)
        {
            return await _context.HomeServices.AsNoTracking().CountAsync(cancellationToken);
        }

        public async Task<HomeServiceDto> GetHomeServiceById(int id, CancellationToken cancellationToken)
        {
            var homeService = await _context.HomeServices
                .FirstOrDefaultAsync(e => e.Id == id, cancellationToken);

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

        public async Task<List<HomeServiceDto>> GetHomeServices(CancellationToken cancellationToken)
        {
            return await _context.HomeServices

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
                }).AsNoTracking()
                .ToListAsync(cancellationToken);

        }

        public async Task<bool> DeleteHomeService(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            var homeService = await _context.HomeServices.FirstOrDefaultAsync(x=>x.Id==active.Id, cancellationToken);
            if (homeService is null) return false;
            homeService.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
