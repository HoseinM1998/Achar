using Achar.Infra.Db.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CategoryDto;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Caching.Memory;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<CategoryRepository> _logger;
        private readonly IMemoryCache _memoryCache;


        public CategoryRepository(AppDbContext context, ILogger<CategoryRepository> logger, IMemoryCache memoryCache)
        {
            _context = context;
            _logger = logger;
            _memoryCache = memoryCache;
        }

        public async Task<int> CreateCategory(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ایجاد دسته با عنوان: {Title} زمان {Time}", categoryDto.Title, DateTime.UtcNow.ToLongTimeString());
            var category = new Category
            {
                CreatedAt = DateTime.Now,
                Title = categoryDto.Title,
                Image = categoryDto.Image
            };

            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _memoryCache.Remove("categories");
            _logger.LogInformation("دسته ایجاد شد با شناسه: {CategoryId} زمان {Time}", category.Id, DateTime.UtcNow.ToLongTimeString());
            return category.Id;
        }

        public async Task<bool> UpdateCategory(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("بروزرسانی دسته با شناسه: {CategoryId} زمان {Time}", categoryDto.Id, DateTime.UtcNow.ToLongTimeString());
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == categoryDto.Id, cancellationToken);
            if (category is null)
            {
                _logger.LogWarning("دسته با شناسه: {CategoryId} پیدا نشد زمان {Time}", categoryDto.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            category.Title = categoryDto.Title;
            category.Image = categoryDto.Image is null ? category.Image:categoryDto.Image;
            _context.Categories.Update(category);
            await _context.SaveChangesAsync(cancellationToken);
            _memoryCache.Remove("categories");
            _logger.LogInformation("دسته با شناسه: {CategoryId} با موفقیت بروزرسانی شد زمان {Time}", categoryDto.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<int> CategoryCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تعداد دسته‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var count = await _context.Categories
                .AsNoTracking()
                .Where(category => category.IsDeleted == false)
                .CountAsync(cancellationToken);
            _logger.LogInformation("تعداد دسته‌ها: {Count} زمان {Time}", count, DateTime.UtcNow.ToLongTimeString());
            return count;
        }

        public async Task<Category> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت دسته با شناسه: {CategoryId} زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            var category = await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (category is null)
            {
                _logger.LogWarning("دسته با شناسه: {CategoryId} پیدا نشد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
                throw new KeyNotFoundException("دسته پیدا نشد.");
            }
            _logger.LogInformation("دسته با شناسه: {CategoryId} با موفقیت دریافت شد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            return category;
        }

        public async Task<List<Category>> GetAllCategory(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی دسته‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());

            if (_memoryCache.TryGetValue("categories", out List<Category> cachedCategories))
            {
                _logger.LogInformation("دریافت دسته‌ها از کش، تعداد: {Count} زمان {Time}", cachedCategories.Count, DateTime.UtcNow.ToLongTimeString());
                return cachedCategories;
            }

            var categories = await _context.Categories
                .Include(x => x.SubCategories)
                .OrderByDescending(x => x.CreatedAt)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            _memoryCache.Set("categories", categories, new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(15) 
            });

            _logger.LogInformation("تعداد دسته‌های دریافت شده از دیتابیس: {Count} زمان {Time}", categories.Count, DateTime.UtcNow.ToLongTimeString());

            return categories;
        }

        public async Task<List<Category>> GetSubCategory(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت زیردسته‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var subCategories = await _context.Categories.AsNoTracking().Include(c => c.SubCategories).ToListAsync(cancellationToken);
            _logger.LogInformation("تعداد زیردسته‌های دریافت شده: {Count} زمان {Time}", subCategories.Count, DateTime.UtcNow.ToLongTimeString());
            return subCategories;
        }

        public async Task<bool> DeleteCategory(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            _logger.LogInformation("حذف دسته با شناسه: {CategoryId} زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == active.Id, cancellationToken);
            if (category is null)
            {
                _logger.LogWarning("دسته با شناسه: {CategoryId} پیدا نشد زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            category.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("دسته با شناسه: {CategoryId} به حالت حذف شده تغییر یافت زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }
    }
}
