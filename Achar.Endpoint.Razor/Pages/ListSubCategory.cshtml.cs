using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos.HomeServiceDto;
using AcharDomainCore.Dtos.SubCategoryDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Pages
{
    public class ListSubCategoryModel : PageModel
    {
        private readonly ISubCategoryAppService _subCategory;
        public ListSubCategoryModel(ISubCategoryAppService subCategory)
        {
            _subCategory = subCategory;
        }

        [BindProperty]
        public List<SubCategoryDto?> SubCategories { get; set; }

        public async Task OnGet(int category, CancellationToken cancellationToken)
        {
            SubCategories = await _subCategory.GetAllSubCategoryByCategory(category, cancellationToken);
        }
    }
}