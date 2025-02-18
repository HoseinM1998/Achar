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

namespace AcharDomainService
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _repository;
        public SubCategoryService(ISubCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> CreateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
            => await _repository.CreateSubCategory(subCategoryDto, cancellationToken);

        public async Task<bool> UpdateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
            => await _repository.UpdateSubCategory(subCategoryDto, cancellationToken);


        public async Task<int> SubCategoryCount(CancellationToken cancellationToken)
            => await _repository.SubCategoryCount( cancellationToken);


        public async Task<SubCategory> GetSubCategoryById(int id, CancellationToken cancellationToken)
            => await _repository.GetSubCategoryById(id, cancellationToken);


        public async Task<List<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellationToken)
            => await _repository.GetAllSubCategory(cancellationToken);


        public async Task<bool> DeleteCategory(SoftDeleteDto delete, CancellationToken cancellationToken)
            => await _repository.DeleteCategory(delete, cancellationToken);

    }
}
