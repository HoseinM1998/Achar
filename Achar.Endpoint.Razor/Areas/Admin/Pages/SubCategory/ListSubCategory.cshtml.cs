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

        public ListSubCategoryModel(ISubCategoryAppService subcategoryAppService, ICategoryAppService categoryAppService)
        {
            _subCategoryAppService = subcategoryAppService;
            _categoryAppService = categoryAppService;
        }
        [BindProperty]
        public List<SubCategoryDto> SubCategories { get; set; }
        [BindProperty]
        public SubCategoryDto NewSubCategory { get; set; } = new();
        [BindProperty]
        public List<AcharDomainCore.Entites.Category> Categories {get; set; } = new ();
        [BindProperty]
        public SoftDeleteDto Delete { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)

        {
            SubCategories = await _subCategoryAppService.GetAllSubCategory(cancellationToken);
            Categories = await _categoryAppService.GetAllCategory(cancellationToken);
        }

        public async Task<IActionResult> OnPostCreateCategory(CancellationToken cancellationToken)
        {
            await _subCategoryAppService.CreateSubCategory(NewSubCategory, cancellationToken);
            return RedirectToPage("ListSubCategory");
        }

        public async Task<IActionResult> OnPostUpCategory(CancellationToken cancellationToken)
        {
            await _subCategoryAppService.UpdateSubCategory(NewSubCategory, cancellationToken);
            return RedirectToPage("ListSubCategory");

        }

        public async Task<IActionResult> OnPostDeleteCategory(CancellationToken cancellationToken)
        {
            await _subCategoryAppService.DeleteCategory(Delete, cancellationToken);
            return RedirectToPage("ListSubCategory");

        }
    }
}
