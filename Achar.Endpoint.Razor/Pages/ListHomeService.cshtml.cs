using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Dtos.HomeServiceDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Pages
{
    public class ListHomeServiceModel : PageModel
    {
        private readonly IHomeServiceAppService _homeService;

        public ListHomeServiceModel(IHomeServiceAppService homeService)
        {
            _homeService = homeService;
        }


        [BindProperty]
        public List<HomeServiceDto> HomeService { get; set; } 

        public async Task OnGet(int subCategory, CancellationToken cancellationToken)

        {
            HomeService = await _homeService.GetAllGetHomeServicesBySubCategory(subCategory, cancellationToken);
        }
    }
}
