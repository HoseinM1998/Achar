using AcharDomainAppService;
using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Dtos.ApplicationUserDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly ICityAppService _cityAppService;

        public CreateModel(IApplicationUserAppService applicationUserAppService, ICityAppService cityAppService)
        {
            _applicationUserAppService = applicationUserAppService;
            _cityAppService = cityAppService;
        }

        [BindProperty]
        public RegisterDto User { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Cities = await _cityAppService.GetAllCity(cancellationToken);
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _applicationUserAppService.Register(User, cancellationToken);
            return RedirectToPage("Index");
        }
    }
}