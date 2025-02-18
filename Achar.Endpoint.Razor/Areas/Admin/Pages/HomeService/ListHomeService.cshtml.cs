using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos.SubCategoryDto;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.HomeServiceDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.HomeService
{
    public class ListHomeServiceModel : PageModel
    {
        private readonly IHomeServiceAppService _homeServiceAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;

        public ListHomeServiceModel(IHomeServiceAppService homeServiceAppService, ISubCategoryAppService subCategoryAppService)
        {
            _homeServiceAppService= homeServiceAppService;
            _subCategoryAppService = subCategoryAppService;
        }
        [BindProperty]
        public List<HomeServiceDto> HomeServices { get; set; }
        [BindProperty]
        public HomeServiceDto NewHomeService { get; set; } = new();
        [BindProperty]
        public List<SubCategoryDto?> SubCategories { get; set; } = new();
        [BindProperty]
        public SoftDeleteDto Delete { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)

        {
            HomeServices = await _homeServiceAppService.GetHomeServices(cancellationToken);
            SubCategories = await _subCategoryAppService.GetAllSubCategory(cancellationToken);
        }

        public async Task<IActionResult> OnPostCreateService(CancellationToken cancellationToken)
        {
            await _homeServiceAppService.CreateHomeService(NewHomeService, cancellationToken);
            return RedirectToPage("ListHomeService");
        }

        public async Task<IActionResult> OnPostUpService(CancellationToken cancellationToken)
        {
            await _homeServiceAppService.UpdateHomeService(NewHomeService, cancellationToken);
            return RedirectToPage("ListHomeService");

        }

        public async Task<IActionResult> OnPostDeleteService(CancellationToken cancellationToken)
        {
            await _homeServiceAppService.DeleteHomeService(Delete, cancellationToken);
            return RedirectToPage("ListHomeService");

        }
    }
}
