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
using Microsoft.Extensions.Logging;

namespace Achar.Infra.Access.EfCore.Repositories
{
    public class SubCategoryRepository:ISubCategoryRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SubCategoryRepository> _logger;

        public SubCategoryRepository(AppDbContext context, ILogger<SubCategoryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<int> CreateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("ایجاد زیر دسته بندی با عنوان: {Title} زمان {Time}", subCategoryDto.Title, DateTime.UtcNow.ToLongTimeString());
            var subCategory = new SubCategory()
            {
                CreateAt = DateTime.Now,
                Title = subCategoryDto.Title,
                Image = subCategoryDto.Image,
                CategoryId = subCategoryDto.CategoryId
            };
            await _context.SubCategory.AddAsync(subCategory, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("زیر دسته بندی ایجاد شد با شناسه: {SubCategoryId} زمان {Time}", subCategory.Id, DateTime.UtcNow.ToLongTimeString());
            return subCategory.Id;
        }

        public async Task<bool> UpdateSubCategory(SubCategoryDto subCategoryDto, CancellationToken cancellationToken)
        {
            _logger.LogInformation("بروزرسانی زیر دسته بندی با شناسه: {SubCategoryId} زمان {Time}", subCategoryDto.Id, DateTime.UtcNow.ToLongTimeString());
            var subCategory = await _context.SubCategory.FirstOrDefaultAsync(x => x.Id == subCategoryDto.Id, cancellationToken);
            if (subCategory is null)
            {
                _logger.LogWarning("زیر دسته بندی با شناسه: {SubCategoryId} پیدا نشد زمان {Time}", subCategoryDto.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            subCategory.Title = subCategoryDto.Title;
            subCategory.Image = subCategoryDto.Image ?? subCategory.Image;
            subCategory.CategoryId = subCategoryDto.CategoryId;
            _context.SubCategory.Update(subCategory);
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("زیر دسته بندی با شناسه: {SubCategoryId} با موفقیت بروزرسانی شد زمان {Time}", subCategoryDto.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

        public async Task<int> SubCategoryCount(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تعداد زیر دسته بندی‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var count = await _context.SubCategory
                .AsNoTracking()
                .Where(subCategory => subCategory.IsDeleted == false)
                .CountAsync(cancellationToken);
            _logger.LogInformation("تعداد زیر دسته‌بندی‌ها: {Count} زمان {Time}", count, DateTime.UtcNow.ToLongTimeString());
            return count;
        }

        public async Task<SubCategory> GetSubCategoryById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت زیر دسته بندی با شناسه: {SubCategoryId} زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            var subCategory = await _context.SubCategory
                .Include(x => x.HomeServices)
                .AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
            if (subCategory is null)
            {
                _logger.LogWarning("زیر دسته بندی با شناسه: {SubCategoryId} پیدا نشد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
                throw new Exception("زیر دسته بندی پیدا نشد.");
            }
            _logger.LogInformation("زیر دسته بندی با شناسه: {SubCategoryId} با موفقیت دریافت شد زمان {Time}", id, DateTime.UtcNow.ToLongTimeString());
            return subCategory;
        }

        public async Task<List<SubCategoryDto>> GetAllSubCategory(CancellationToken cancellationToken)
        {
            _logger.LogInformation("دریافت تمامی زیر دسته بندی‌ها زمان {Time}", DateTime.UtcNow.ToLongTimeString());
            var subCategories = await _context.SubCategory
                .Select(e => new SubCategoryDto()
                {
                    Id = e.Id,
                    Title = e.Title,
                    Image = e.Image,
                    CategoryId = e.CategoryId,
                    CategoryName = e.Category.Title,
                    CreateAt = e.CreateAt
                }).AsNoTracking().ToListAsync(cancellationToken);
            _logger.LogInformation("تعداد زیر دسته بندی‌های دریافت شده: {Count} زمان {Time}", subCategories.Count, DateTime.UtcNow.ToLongTimeString());
            return subCategories;
        }

        public async Task<bool> DeleteCategory(SoftDeleteDto active, CancellationToken cancellationToken)
        {
            _logger.LogInformation("حذف زیر دسته بندی با شناسه: {SubCategoryId} زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            var subCategory = await _context.SubCategory.FirstOrDefaultAsync(x => x.Id == active.Id, cancellationToken);
            if (subCategory is null)
            {
                _logger.LogWarning("زیر دسته بندی با شناسه: {SubCategoryId} پیدا نشد زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
                return false;
            }
            subCategory.IsDeleted = active.IsDeleted;
            await _context.SaveChangesAsync(cancellationToken);
            _logger.LogInformation("زیر دسته بندی با شناسه: {SubCategoryId} به حالت حذف شده تغییر یافت زمان {Time}", active.Id, DateTime.UtcNow.ToLongTimeString());
            return true;
        }

    }
}
