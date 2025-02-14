using AcharDomainCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos.CategoryDto;

namespace AcharDomainCore.Contracts.Category
{
    public interface ICategoryRepository
    {
         Task<int> CreateCategory(CategoryDto category,CancellationToken cancellationToken);
         Task<bool> UpdateCategory(CategoryDto category,CancellationToken cancellationToken);
         Task<Entites.Category> GetCategoryById(int id,CancellationToken cancellationToken);
         Task<List<Entites.Category>> GetAllCategory(CancellationToken cancellationToken);
        Task<List<Entites.Category>> GetSubCategory(CancellationToken  cancellationToken);
         Task<bool> DeleteCategory(SoftDeleteDto delete, CancellationToken cancellationToken);
    }
}
