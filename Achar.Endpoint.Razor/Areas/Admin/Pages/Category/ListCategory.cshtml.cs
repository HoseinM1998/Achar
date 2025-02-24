
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CategoryDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;


namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Category
{
    [Authorize(Roles = "Admin")]

    public class ListCategoryModel : PageModel
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly ILogger<IndexModel> _logger;


        public ListCategoryModel(ICategoryAppService categoryAppService, ILogger<IndexModel> logger)
        {

            _categoryAppService = categoryAppService;
            _logger = logger;
        }

        [BindProperty]
        public List<AcharDomainCore.Entites.Category> Categories { get; set; }

        [BindProperty]
        public CategoryDto NewCategory { get; set; } = new();

        [BindProperty]
        public SoftDeleteDto Delete { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Categories = await _categoryAppService.GetAllCategory(cancellationToken);
        }

        public async Task<IActionResult> OnPostCreateCategory(IFormFile categoryImage, CancellationToken cancellationToken)
        {
            try
            {
                await _categoryAppService.CreateCategory(NewCategory, cancellationToken);
                TempData["Success"] = "دسته‌بندی با موفقیت ایجاد شد.";
                _logger.LogInformation("دسته‌بندی با موفقیت ایجاد شد: {CategoryName}", NewCategory.Title);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در ایجاد دسته‌بندی: {CategoryName}", NewCategory.Title);
            }
            return RedirectToPage("ListCategory");
        }

        public async Task<IActionResult> OnPostUpCategory(CancellationToken cancellationToken)
        {
            try
            {
                await _categoryAppService.UpdateCategory(NewCategory, cancellationToken);
                TempData["Success"] = "دسته‌بندی با موفقیت به‌روزرسانی شد.";
                _logger.LogInformation("دسته‌بندی با موفقیت به‌روزرسانی شد {Time} " ,DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در به‌روزرسانی دسته‌بندی{Time} ", DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("ListCategory");
        }

        public async Task<IActionResult> OnPostDeleteCategory(CancellationToken cancellationToken)
        {
            try
            {
                await _categoryAppService.DeleteCategory(Delete, cancellationToken);
                TempData["Success"] = "دسته‌بندی با موفقیت حذف شد.";
                _logger.LogInformation("دسته‌بندی با موفقیت حذف شد {Time} ", DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در حذف دسته‌بندی {Time} ", DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("ListCategory");
        }
    }
}
