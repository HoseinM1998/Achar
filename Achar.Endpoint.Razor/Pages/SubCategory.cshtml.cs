using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos.HomeServiceDto;
using AcharDomainCore.Dtos.SubCategoryDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Pages
{
    public class SubCategoryModel : PageModel
    {

        private readonly ILogger<SubCategoryModel> _logger;
        private readonly ISubCategoryAppService _subCategory;
        private readonly IHomeServiceAppService _homeService;

        public SubCategoryModel(ILogger<SubCategoryModel> logger, IHomeServiceAppService homeService, ISubCategoryAppService subCategory)
        {
            _logger = logger;
            _homeService = homeService;
            _subCategory = subCategory;
        }

        [BindProperty]
        public List<HomeServiceDto> HomeServices { get; set; }

        [BindProperty]
        public List<SubCategoryDto?> SubCategories { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)

        {
            _logger.LogInformation(" ???? ??? ?????? ???? ????????{Time} ", DateTime.UtcNow.ToLongTimeString());
            SubCategories = await _subCategory.GetAllSubCategory(cancellationToken);
            HomeServices = await _homeService.GetHomeServices(cancellationToken);

        }
    }
}
