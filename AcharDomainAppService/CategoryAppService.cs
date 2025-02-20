using AcharDomainCore.Contracts.Bid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CategoryDto;
using AcharDomainCore.Entites;
using System.Security.Cryptography;
using AcharDomainCore.Contracts.Image;
using Microsoft.Extensions.Logging;

namespace AcharDomainAppService
{
    public class CategoryAppService:ICategoryAppService
    {
        private readonly ICategoryService _service;
        private readonly IImageService _imageService;
        private readonly ILogger<CategoryAppService> _logger;

        public CategoryAppService(ICategoryService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        public async Task<int> CreateCategory(CategoryDto category, CancellationToken cancellationToken)
        {
            try
            {
                //if (category.ImageFile is not null)
                //{
                //    category.Image = await _imageService.UploadImage(category.ImageFile!, "category", cancellationToken);
                //}
                return await _service.CreateCategory(category, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateCategory: {ex.Message}");
            }
        }

        public async Task<bool> UpdateCategory(CategoryDto category, CancellationToken cancellationToken)
        {
            try
            {
                if (category.ImageFile is not null)
                {
                    category.Image = await _imageService.UploadImage(category.ImageFile!, "category", cancellationToken);
                }

                return await _service.UpdateCategory(category, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateCategory: {ex.Message}");
            }
        }

        public async Task<int> CategoryCount(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.CategoryCount(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CategoryCount: {ex.Message}");
            }
        }

        public async Task<Category> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetCategoryById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetCategoryById: {ex.Message}");
            }
        }

        public async  Task<List<Category>> GetAllCategory(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetAllCategory( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetAllCategory: {ex.Message}");
            }
        }

        public async Task<List<Category>> GetSubCategory(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetSubCategory(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetSubCategory: {ex.Message}");
            }
        }

        public async Task<bool> DeleteCategory(SoftDeleteDto delete, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.DeleteCategory(delete, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error DeleteCategory: {ex.Message}");
            }
        }
    }
}
