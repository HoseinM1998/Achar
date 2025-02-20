
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CategoryDto;
using AcharDomainCore.Entites;
using System.Security.Cryptography;
using AcharDomainCore.Contracts.Image;
using Microsoft.Extensions.Logging;

namespace AcharDomainAppService
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryService _service;
        private readonly IImageService _imageService;
        private readonly ILogger<CategoryAppService> _logger;

        public CategoryAppService(ICategoryService service, IImageService imageService, ILogger<CategoryAppService> logger)
        {
            _service = service;
            _imageService = imageService;
            _logger = logger;
        }

        public async Task<int> CreateCategory(CategoryDto category, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: ایجاد دسته‌بندی زمان {Time}", DateTime.Now.ToLongTimeString());
                if (category.ImageFile is not null)
                {
                    category.Image = await _imageService.UploadImage(category.ImageFile!, "category", cancellationToken);
                }
                var result = await _service.CreateCategory(category, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: ایجاد دسته‌بندی با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در عملیات ایجاد دسته‌بندی: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error CreateCategory: {ex.Message}");
            }
        }

        public async Task<bool> UpdateCategory(CategoryDto category, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی دسته‌بندی با شناسه: {CategoryId} زمان {Time}", category.Id, DateTime.Now.ToLongTimeString());
                if (category.ImageFile is not null)
                {
                    category.Image = await _imageService.UploadImage(category.ImageFile!, "category", cancellationToken);
                }

                var result = await _service.UpdateCategory(category, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: به‌روزرسانی دسته‌بندی با موفقیت انجام شد با شناسه: {CategoryId} زمان {Time}", category.Id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در به‌روزرسانی دسته‌بندی: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error UpdateCategory: {ex.Message}");
            }
        }

        public async Task<int> CategoryCount(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات شمارش دسته‌بندی زمان {Time}", DateTime.Now.ToLongTimeString());
                var result = await _service.CategoryCount(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات شمارش دسته‌بندی با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در عملیات شمارش دسته‌بندی: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error CategoryCount: {ex.Message}");
            }
        }

        public async Task<Category> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: دریافت دسته‌بندی با شناسه: {Id} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                var result = await _service.GetCategoryById(id, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: دریافت دسته‌بندی با موفقیت انجام شد برای شناسه: {Id} زمان {Time}", id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت دسته‌بندی: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error GetCategoryById: {ex.Message}");
            }
        }

        public async Task<List<Category>> GetAllCategory(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات دریافت همه دسته‌بندی‌ها زمان {Time}", DateTime.Now.ToLongTimeString());
                var result = await _service.GetAllCategory(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات دریافت همه دسته‌بندی‌ها با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت همه دسته‌بندی‌ها: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error GetAllCategory: {ex.Message}");
            }
        }

        public async Task<List<Category>> GetSubCategory(CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات دریافت زیر دسته‌بندی‌ها زمان {Time}", DateTime.Now.ToLongTimeString());
                var result = await _service.GetSubCategory(cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات دریافت زیر دسته‌بندی‌ها با موفقیت انجام شد زمان {Time}", DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در دریافت زیر دسته‌بندی‌ها: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error GetSubCategory: {ex.Message}");
            }
        }

        public async Task<bool> DeleteCategory(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("لایه اپ سرویس: شروع عملیات حذف دسته‌بندی با شناسه: {Id} زمان {Time}", delete.Id, DateTime.Now.ToLongTimeString());
                var result = await _service.DeleteCategory(delete, cancellationToken);
                _logger.LogInformation("لایه اپ سرویس: عملیات حذف دسته‌بندی با موفقیت انجام شد برای شناسه: {Id} زمان {Time}", delete.Id, DateTime.Now.ToLongTimeString());
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "لایه اپ سرویس: خطا در حذف دسته‌بندی: {Message} زمان {Time}", ex.Message, DateTime.Now.ToLongTimeString());
                throw new Exception($"Error DeleteCategory: {ex.Message}");
            }
        }
    }
}
