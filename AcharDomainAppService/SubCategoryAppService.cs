using AcharDomainCore.Contracts.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.SubCategoryDto;
using AcharDomainCore.Entites;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Contracts.Image;
using Microsoft.Extensions.Logging;

namespace AcharDomainAppService
{
    public class SubCategoryAppService : ISubCategoryAppService
    {
        private readonly ISubCategoryService _service;
        private readonly IImageService _imageService;
        private readonly ILogger<SubCategoryAppService> _logger;


        public SubCategoryAppService(ISubCategoryService service, IImageService imageService)
        {
            _service = service;
            _imageService = imageService;
        }

        public async Task<int> CreateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
        {
            try
            {
                if (subCategoryDto.ImageFile is not null)
                {
                    subCategoryDto.Image = await _imageService.UploadImage(subCategoryDto.ImageFile!, "category", cancellationToken);
                }
                return await _service.CreateSubCategory(subCategoryDto, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error CreateSubCategory: {ex.Message}");
            }
        }

        public async Task<bool> UpdateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
        {
            try
            {
                if (subCategoryDto.ImageFile is not null)
                {
                    subCategoryDto.Image = await _imageService.UploadImage(subCategoryDto.ImageFile!, "category", cancellationToken);
                }
                return await _service.UpdateSubCategory(subCategoryDto, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error UpdateSubCategory: {ex.Message}");
            }
        }

        public async Task<int> SubCategoryCount(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.SubCategoryCount( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error SubCategoryCount: {ex.Message}");
            }
        }

        public async Task<SubCategory> GetSubCategoryById(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetSubCategoryById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetSubCategoryById: {ex.Message}");
            }
        }

        public async Task<List<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellationToken)
        {
            try
            {
                return await _service.GetAllSubCategory( cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error GetAllSubCategory: {ex.Message}");
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
