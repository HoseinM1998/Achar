using Achar.Infra.Db.Sql;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CityDto;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CityRepository> _logger;
        private readonly IMemoryCache _memoryCache;


        public CityRepository(AppDbContext context, ILogger<CityRepository> logger, IMemoryCache memoryCache)
        {
            _context = context;
            _logger = logger;
            _memoryCache=memoryCache;
        }

        public async Task<int> CreateCity(CityDto cityDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ایجاد شهر با عنوان: {Title} زمان {Time}", cityDto.Title, DateTime.UtcNow.ToLongTimeString());
            var city = new City()
            {
                CreateAt = DateTime.Now,
                Title = cityDto.Title
            };

            await _context.Cities.AddAsync(city, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("شهر ایجاد شد با شناسه: {CityId} زمان {Time}", city.Id, DateTime.UtcNow.ToLongTimeString());
            return city.Id;
        }

        public async Task<bool> UpdateCity(CityDto cityDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("بروزرسانی شهر با شناسه: {CityId} زمان {Time}", cityDto.Id, DateTime.UtcNow.ToLongTimeString());
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == cityDto.Id, cancellationToken);
            if (city is null)
            {
                _logger.LogWarning("شهر با شناسه: {CityId} پیدا نشد زمان {Time}", cityDto.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            city.Title = cityDto.Title;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("شهر با شناسه: {CityId} با موفقیت بروزرسانی شد زمان {Time}", cityDto.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<City> GetCityById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت شهر با شناسه: {CityId} زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            var city = await _context.Cities.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (city is null)
            {
                _logger.LogWarning("شهر با شناسه: {CityId} پیدا نشد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
                throw new Exception("شهر پیدا نشد.");
            }
            _logger.LogInformation("شهر با شناسه: {CityId} با موفقیت دریافت شد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            return city;
        }
        public async Task<List<City>> GetAllCity(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی شهرها زمان {Time}", DateTime.UtcNow.ToLongTimeString());

            if (_memoryCache.TryGetValue("cities", out List<City> cachedCities))
            {
                _logger.LogInformation("دریافت شهرها از کش، تعداد: {Count} زمان {Time}", cachedCities.Count, DateTime.UtcNow.ToLongTimeString());
                return cachedCities;
            }

            var cities = await _context.Cities.AsNoTracking().ToListAsync(cancellationToken);

            _memoryCache.Set("cities", cities, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(15)
            });

            _logger.LogInformation("تعداد شهرهای دریافت شده: {Count} زمان {Time}", cities.Count, DateTime.UtcNow.ToLongTimeString());

            return cities;
        }


        public async Task<bool> DeleteCity(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            _logger.LogInformation("حذف شهر با شناسه: {CityId} زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            var city = await _context.Cities.FirstOrDefaultAsync(x => x.Id == active.Id, cancellationToken);
            if (city is null)
            {
                _logger.LogWarning("شهر با شناسه: {CityId} پیدا نشد زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            city.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("شهر با شناسه: {CityId} به حالت حذف شده تغییر یافت زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }
    }
}
