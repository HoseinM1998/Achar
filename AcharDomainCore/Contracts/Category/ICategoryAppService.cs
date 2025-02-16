using AcharDomainCore.Dtos.CategoryDto;
using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Category
{
    public interface ICategoryAppService
    {
        Task<int> CreateCategory(CategoryDto category, CancellationToken cancellationToken);
        Task<bool> UpdateCategory(CategoryDto category, CancellationToken cancellationToken);
        Task<int> CategoryCount(CancellationToken cancellationToken);
        Task<Entites.Category> GetCategoryById(int id, CancellationToken cancellationToken);
        Task<List<Entites.Category>> GetAllCategory(CancellationToken cancellationToken);
        Task<List<Entites.Category>> GetSubCategory(CancellationToken cancellationToken);
        Task<bool> DeleteCategory(SoftDeleteDto delete, CancellationToken cancellationToken);
    }
}
