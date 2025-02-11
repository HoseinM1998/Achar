using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.Category
{
    public interface ICategoryRepository
    {
         Task<int> CreateCategory(Entites.Category category,CancellationToken cancellationToken);
         Task<bool> UpdateCategory(Entites.Category category,CancellationToken cancellationToken);
         Task<Entites.Category> GetCategoryById(int id,CancellationToken cancellation);
         Task<List<Entites.Category>> GetAllCategory(CancellationToken cancellationToken);
        Task<List<Entites.Category>> GetSubCategory(CancellationToken  cancellationToken);
         Task<bool> IsActiveCategory(int id, bool delete, CancellationToken cancellationToken);
    }
}
