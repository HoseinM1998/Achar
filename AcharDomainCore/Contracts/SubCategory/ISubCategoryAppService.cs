using AcharDomainCore.Dtos.SubCategoryDto;
using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.SubCategory
{
    public interface ISubCategoryAppService
    {
        Task<int> CreateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken);
        Task<bool> UpdateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken);
        Task<int> SubCategoryCount(CancellationToken cancellationToken);
        Task<Entites.SubCategory> GetSubCategoryById(int id, CancellationToken cancellationToken);
        Task<List<SubCategoryDto?>> GetAllSubCategory(CancellationToken cancellationToken);
        Task<List<SubCategoryDto?>> GetAllSubCategoryByCategory(int category, CancellationToken cancellationToken);
        Task<bool> DeleteCategory(SoftDeleteDto delete, CancellationToken cancellationToken);
    }
}
