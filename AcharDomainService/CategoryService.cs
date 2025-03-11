using AcharDomainCore.Contracts.Bid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.Dapper;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CategoryDto;
using AcharDomainCore.Entites;
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IDapper _dapper;


        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository repository, ILogger<CategoryService> logger, IDapper dapper)
        {
            _repository = repository;
            _logger = logger;
            _dapper = dapper;
        }

        public async Task<int> CreateCategory(CategoryDto category, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: ایجاد دسته بندی با عنوان: {Title} زمان {Time}", category.Title, DateTime.UtcNow.ToLongTimeString());
            var categoryId = await _repository.CreateCategory(category, cancellationToken);
            _logger.LogInformation("لایه سرویس: دسته بندی ایجاد شد با شناسه: {CategoryId} زمان {Time}", categoryId, DateTime.UtcNow.ToLongTimeString());
            return categoryId;
        }

        public async Task<bool> UpdateCategory(CategoryDto category, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: بروزرسانی دسته بندی با شناسه: {CategoryId} زمان {Time}", category.Id, DateTime.UtcNow.ToLongTimeString());
            var result = await _repository.UpdateCategory(category, cancellationToken);
            if (!result)
            {
                _logger.LogWarning("لایه سرویس: بروزرسانی دسته بندی با شناسه: {CategoryId} ناموفق بود زمان {Time}", category.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            _logger.LogInformation("لایه سرویس: دسته بندی با شناسه: {CategoryId} با موفقیت بروزرسانی شد زمان {Time}", category.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<int> CategoryCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت تعداد دسته بندی‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var count = await _repository.CategoryCount(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد دسته بندی‌های دریافت شده: {Count} زمان {Time}", count, DateTime.UtcNow.ToLongTimeString());
            return count;
        }

        public async Task<Category> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت دسته بندی با شناسه: {CategoryId} زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            var category = await _repository.GetCategoryById(id, cancellationToken);
            if (category is null)
            {
                _logger.LogWarning("لایه سرویس: دسته بندی با شناسه: {CategoryId} پیدا نشد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
                throw new Exception("دسته بندی پیدا نشد.");
            }
            _logger.LogInformation("لایه سرویس: دسته بندی با شناسه: {CategoryId} با موفقیت دریافت شد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            return category;
        }

        public async Task<List<Category>> GetAllCategory(CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت تمامی دسته بندی‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var categories = await _dapper.GetAllCategoryDapper(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد دسته بندی‌های دریافت شده: {Count} زمان {Time}", categories.Count, DateTime.UtcNow.ToLongTimeString());
            return categories;
        }

        public async Task<List<Category>> GetSubCategory(CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: دریافت تمامی زیر دسته بندی‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var subCategories = await _repository.GetSubCategory(cancellationToken);
            _logger.LogInformation("لایه سرویس: تعداد زیر دسته بندی‌های دریافت شده: {Count} زمان {Time}", subCategories.Count, DateTime.UtcNow.ToLongTimeString());
            return subCategories;
        }

        public async Task<bool> DeleteCategory(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            _logger.LogInformation("لایه سرویس: حذف دسته بندی با شناسه: {CategoryId} زمان {Time}", delete.Id, DateTime.UtcNow.ToLongTimeString());
            var result = await _repository.DeleteCategory(delete, cancellationToken);
            if (!result)
            {
                _logger.LogWarning("لایه سرویس: حذف دسته بندی با شناسه: {CategoryId} ناموفق بود زمان {Time}", delete.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            _logger.LogInformation("لایه سرویس: دسته بندی با شناسه: {CategoryId} با موفقیت حذف شد زمان {Time}", delete.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }


    }
}
