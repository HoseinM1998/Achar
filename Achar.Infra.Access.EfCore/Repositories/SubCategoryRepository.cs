using Achar.Infra.Db.Sql;
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
using HomeService.Domain.Core.Enums;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class SubCategoryRepository:ISubCategoryRepository
    {
        private readonly AppDbContext _context;
        public SubCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
        {
            var subCategory = new SubCategory()
            {
                Title = subCategoryDto.Title,
                Image = subCategoryDto.Image,
                CategoryId = subCategoryDto.CategoryId

            };
            await _context.SubCategory.AddAsync(subCategory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return subCategory.Id;
        }

        public async Task<bool> UpdateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
        {
            var subCategory = await _context.SubCategory.FindAsync(subCategoryDto.Id, cancellationToken);
            if (subCategory is null) return false;
            subCategory.Title = subCategoryDto.Title;
            subCategory.Image = subCategoryDto.Image;
            subCategory.CategoryId = subCategoryDto.CategoryId;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<SubCategory> GetSubCategoryById(int id, CancellationToken cancellationToken)
        {
            return await _context.SubCategory.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        }

        public async Task<List<SubCategory>> GetAllSubCategory(CancellationToken cancellationToken)
        {
            return await _context.SubCategory.AsNoTracking().ToListAsync(cancellationToken);

        }

        public async Task<bool> IsActiveCategory(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            var subCategory = await _context.SubCategory.FindAsync(active.Id, cancellationToken);
            if (subCategory is null) return false;
            subCategory.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
