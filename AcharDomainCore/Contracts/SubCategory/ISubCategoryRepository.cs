using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.SubCategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.SubCategory
{
    public interface ISubCategoryRepository
    {
        Task<int> CreateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken);
        Task<bool> UpdateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken);
        Task<int> SubCategoryCount(CancellationToken cancellationToken);
        Task<Entites.SubCategory> GetSubCategoryById(int id, CancellationToken cancellationToken);
        Task<List<Entites.SubCategory>> GetAllSubCategory(CancellationToken cancellationToken);
        Task<bool> DeleteCategory(SoftDeleteDto delete, CancellationToken cancellationToken);
    }
}
