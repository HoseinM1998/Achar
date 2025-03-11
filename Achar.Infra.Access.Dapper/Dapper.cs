
using AcharDomainCore.Entites.Config;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System.Data;
using AcharDomainCore.Contracts.Dapper;
using Dapper;
using AcharDomainCore.Entites;
using AcharDomainCore.Dtos.SubCategoryDto;
using AcharDomainCore.Dtos.HomeServiceDto;


namespace Achar.Infra.Access.Dapper
{
    public class Dapper : IDapper
    {
        private readonly SiteSetting _siteSettings;
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<Dapper> _logger;

        public Dapper(SiteSetting siteSettings, IMemoryCache memoryCache, ILogger<Dapper> logger)
        {
            _siteSettings = siteSettings;
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public async Task<List<City>> GetAllCityDapper(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی شهرها از دپر");
            var cities = _memoryCache.Get<List<City>>("cities");

            if (cities is not null)
            {
                _logger.LogInformation("دریافت شهرها از کش، تعداد: {Count}", cities.Count);
                return cities;
            }

            using IDbConnection db = new SqlConnection(_siteSettings.ConnectionString.SqlConnection);
            cities = (List<City>)await db.QueryAsync<City>("SELECT * FROM Cities");

            _memoryCache.Set("cities", cities, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromDays(1)
            });

            _logger.LogInformation("تعداد شهرهای دریافت شده از دیتابیس: {Count}", cities.Count);

            return cities;
        }

     

        public async Task<List<Category>> GetAllCategoryDapper(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی دسته‌بندی‌ها و زیرمجموعه‌ها و خدمات خانه از دپر");

            var categories = _memoryCache.Get<List<Category>>("categories");
            if (categories is not null)
            {
                _logger.LogInformation("دریافت دسته‌ها از کش، تعداد: {Count}", categories.Count);
                return categories;
            }

            using IDbConnection db = new SqlConnection(_siteSettings.ConnectionString.SqlConnection);

            var categoryDictionary = new Dictionary<int, Category>();


            string query = @"
        SELECT c.*, s.*, hs.*
        FROM Categories c
        LEFT JOIN SubCategory s ON c.Id = s.CategoryId
        LEFT JOIN HomeServices hs ON s.Id = hs.SubCategoryId
        ORDER BY c.CreatedAt, s.CreateAt, hs.CreateAt";

            var categoryList = await db.QueryAsync<Category, SubCategory, HomeService, Category>(
                query,
                (category, subCategory, homeService) =>
                {

                    if (!categoryDictionary.TryGetValue(category.Id, out var categoryEntry))
                    {
                        categoryEntry = category;
                        categoryEntry.SubCategories = new List<SubCategory>();
                        categoryDictionary.Add(category.Id, categoryEntry);
                    }

                    if (subCategory != null)
                    {
                        subCategory.HomeServices = new List<HomeService>(); 
                        categoryEntry.SubCategories.Add(subCategory);
                    }

    
                    if (homeService != null)
                    {
                        subCategory?.HomeServices?.Add(homeService);
                    }

                    return categoryEntry;
                },
                splitOn: "Id,Id");

            categories = categoryDictionary.Values.ToList();

            _memoryCache.Set("categories", categories, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromDays(1)
            });

            _logger.LogInformation("تعداد دسته‌بندی‌های دریافت شده از دیتابیس: {Count}", categories.Count);

            return categories;
        }





        public async Task<List<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی زیردسته‌بندی‌ها از دپر ");
            if (_memoryCache.TryGetValue("subCategories", out List<SubCategoryDto> cachedSubCategories))
            {
                _logger.LogInformation("دریافت زیر دسته‌ها از کش، تعداد: {Count} زمان {Time}", cachedSubCategories.Count, DateTime.UtcNow.ToLongTimeString());
                return cachedSubCategories;
            }

            const string query = @"
        SELECT s.Id, s.Title, s.Image, s.CategoryId, s.CreateAt, c.Title AS CategoryName
        FROM SubCategory s
        INNER JOIN Categories c ON s.CategoryId = c.Id
        ORDER BY s.CreateAt DESC";

            await using var db = new SqlConnection(_siteSettings.ConnectionString.SqlConnection);
            var subCategories = (await db.QueryAsync<SubCategoryDto>(query)).ToList();

            _memoryCache.Set("subCategories", subCategories, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(15)
            });

            _logger.LogInformation("تعداد زیر دسته‌بندی‌های دریافت شده از دیتابیس: {Count} زمان {Time}", subCategories.Count, DateTime.UtcNow.ToLongTimeString());

            return subCategories;
        }




        public async Task<List<HomeServiceDto>> GetAllHomeServiceDapper(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت خدمات صفحه اصلی از دپر");
            var homeServices = _memoryCache.Get<List<HomeServiceDto>>("homeServices");

            if (homeServices is not null)
            {
                _logger.LogInformation("دریافت خدمات از کش، تعداد: {Count}", homeServices.Count);
                return homeServices;
            }

            using IDbConnection db = new SqlConnection(_siteSettings.ConnectionString.SqlConnection);
            homeServices = (List<HomeServiceDto>)await db.QueryAsync<HomeServiceDto>(
                @"SELECT h.Id, h.Title, h.ImageSrc, h.Description, h.ShortDescription, h.BasePrice, h.SubCategoryId, s.Title AS CategoryName, h.CreateAt
                FROM HomeServices h
                JOIN SubCategory s ON h.SubCategoryId = s.Id
                ORDER BY h.CreateAt DESC"
            );

            _memoryCache.Set("homeServices", homeServices, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromDays(1)
            });

            _logger.LogInformation("تعداد خدمات صفحه اصلی دریافت شده از دیتابیس: {Count}", homeServices.Count);

            return homeServices;
        }
    }
}