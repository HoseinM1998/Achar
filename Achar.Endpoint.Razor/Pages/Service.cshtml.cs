using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos.HomeServiceDto;
using AcharDomainCore.Dtos.SubCategoryDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Pages
{
    public class ServiceModel : PageModel
    {
        private readonly IHomeServiceAppService _homeService;

        public ServiceModel(IHomeServiceAppService homeService)
        {
            _homeService = homeService;
        }


        [BindProperty]
        public HomeServiceDto HomeService { get; set; }

        public async Task OnGet(int id,CancellationToken cancellationToken)

        {
            HomeService = await _homeService.GetHomeServiceById(id, cancellationToken);
        }
    }
}
