using Achar.Infra.Db.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CategoryDto;
using AcharDomainCore.Entites;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateCategory(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Title = categoryDto.Title,
                Image = categoryDto.Image
            };

            await _context.Categories.AddAsync(category, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return category.Id;
        }

        public async Task<bool> UpdateCategory(CategoryDto categoryDto, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(categoryDto.Id, cancellationToken);
            if (category is null) return false;
            category.Title = categoryDto.Title;
            category.Image = categoryDto.Image;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<Category> GetCategoryById(int id, CancellationToken cancellationToken)
        {
            return await _context.Categories.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

        }

        public async Task<List<Category>> GetAllCategory(CancellationToken cancellationToken)
        {
            return await _context.Categories.AsNoTracking().ToListAsync(cancellationToken);

        }

        public async Task<List<Category>> GetSubCategory(CancellationToken cancellationToken)
        {
            return await _context.Categories.AsNoTracking().Include(c => c.SubCategories).ToListAsync(cancellationToken);

        }

        public async Task<bool> DeleteCategory(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.FindAsync(active.Id, cancellationToken);
            if (category is null) return false;
            category.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
