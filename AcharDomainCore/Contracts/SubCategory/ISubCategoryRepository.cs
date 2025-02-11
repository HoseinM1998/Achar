using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Contracts.SubCategory
{
    public interface ISubCategoryRepository
    {
        Task<int> CreateSubCategory(Entites.SubCategory subcategory, CancellationToken cancellationToken);
        Task<bool> UpdateSubCategory(Entites.SubCategory subcategory, CancellationToken cancellationToken);
        Task<Entites.SubCategory> GetSubCategoryById(int id, CancellationToken cancellation);
        Task<List<Entites.SubCategory>> GetAllSubCategory(CancellationToken cancellationToken);
        Task<bool> IsActiveCategory(int id, bool delete, CancellationToken cancellationToken);
    }
}
