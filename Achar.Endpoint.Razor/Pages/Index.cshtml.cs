using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos.HomeServiceDto;
using AcharDomainCore.Dtos.SubCategoryDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoryAppService _category;
        private readonly IHomeServiceAppService _homeService;
        private readonly ISubCategoryAppService _subCategory;

        public IndexModel(ILogger<IndexModel> logger, ICategoryAppService category, IHomeServiceAppService homeService, ISubCategoryAppService subCategory)
        {
            _logger = logger;
            _category = category;
            _homeService = homeService;
            _subCategory = subCategory;
        }

        [BindProperty]
        public List<AcharDomainCore.Entites.Category> Categories { get; set; }

        [BindProperty]
        public List<HomeServiceDto> HomeServices { get; set; }

        [BindProperty]
        public List<SubCategoryDto?> SubCategories { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)

        {
            _logger.LogInformation("تست لاگ {Time} ", DateTime.UtcNow.ToLongTimeString());
            Categories = await _category.GetAllCategory(cancellationToken);
            SubCategories = await _subCategory.GetAllSubCategory(cancellationToken);
            HomeServices = await _homeService.GetHomeServices(cancellationToken);

        }
    }
}
