using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.SubCategoryDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.SubCategory
{
    public class ListSubCategoryModel : PageModel
    {
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly ICategoryAppService _categoryAppService;
        private readonly ILogger<IndexModel> _logger;

        public ListSubCategoryModel(ISubCategoryAppService subcategoryAppService, ICategoryAppService categoryAppService, ILogger<IndexModel> logger)
        {
            _subCategoryAppService = subcategoryAppService;
            _categoryAppService = categoryAppService;
            _logger = logger;
        }

        [BindProperty]
        public List<SubCategoryDto> SubCategories { get; set; }

        [BindProperty]
        public SubCategoryDto NewSubCategory { get; set; } = new();

        [BindProperty]
        public List<AcharDomainCore.Entites.Category> Categories { get; set; } = new();

        [BindProperty]
        public SoftDeleteDto Delete { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            SubCategories = await _subCategoryAppService.GetAllSubCategory(cancellationToken);
            Categories = await _categoryAppService.GetAllCategory(cancellationToken);
        }

        public async Task<IActionResult> OnPostCreateCategory(CancellationToken cancellationToken)
        {
            try
            {
                await _subCategoryAppService.CreateSubCategory(NewSubCategory, cancellationToken);
                TempData["Success"] = "زیرمجموعه با موفقیت ایجاد شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("ListSubCategory");
        }

        public async Task<IActionResult> OnPostUpCategory(CancellationToken cancellationToken)
        {
            try
            {
                await _subCategoryAppService.UpdateSubCategory(NewSubCategory, cancellationToken);
                TempData["Success"] = "زیرمجموعه با موفقیت به‌روزرسانی شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("ListSubCategory");
        }

        public async Task<IActionResult> OnPostDeleteCategory(CancellationToken cancellationToken)
        {
            try
            {
                await _subCategoryAppService.DeleteCategory(Delete, cancellationToken);
                TempData["Success"] = "زیرمجموعه با موفقیت حذف شد.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("ListSubCategory");
        }
    }
}
