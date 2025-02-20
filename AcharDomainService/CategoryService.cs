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
using Microsoft.Extensions.Logging;

namespace AcharDomainService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateCategory(CategoryDto category, CancellationToken cancellationToken)
            => await _repository.CreateCategory(category, cancellationToken);

        public async Task<bool> UpdateCategory(CategoryDto category, CancellationToken cancellationToken)
            => await _repository.UpdateCategory(category,cancellationToken);

        public async Task<int> CategoryCount(CancellationToken cancellationToken)
            => await _repository.CategoryCount(cancellationToken);

        public async Task<Category> GetCategoryById(int id, CancellationToken cancellationToken)
            => await _repository.GetCategoryById(id, cancellationToken);

        public async Task<List<Category>> GetAllCategory(CancellationToken cancellationToken)
            => await _repository.GetAllCategory(cancellationToken);

        public async Task<List<Category>> GetSubCategory(CancellationToken cancellationToken)
            => await _repository.GetSubCategory(cancellationToken);

        public async Task<bool> DeleteCategory(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteCategory(delete, cancellationToken);

    }
}
