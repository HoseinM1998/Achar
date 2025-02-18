using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CategoryDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Category
{
    public class ListCategoryModel : PageModel
    {
        private readonly ICategoryAppService _categoryAppService;
        public ListCategoryModel(ICategoryAppService categoryAppService)
        {
          _categoryAppService=categoryAppService;
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

        public async Task<IActionResult> OnPostCreateCategory( CancellationToken cancellationToken)
        {
            await _categoryAppService.CreateCategory(NewCategory, cancellationToken);
            return RedirectToPage("ListCategory");
        }

        public async Task<IActionResult> OnPostUpCategory(CancellationToken cancellationToken)
        {
            await _categoryAppService.UpdateCategory(NewCategory, cancellationToken);
            return RedirectToPage("ListCategory");

        }

        public async Task<IActionResult> OnPostDeleteCategory(CancellationToken cancellationToken)
        {
            await _categoryAppService.DeleteCategory(Delete, cancellationToken);
            return RedirectToPage("ListCategory");

        }

    }
}
