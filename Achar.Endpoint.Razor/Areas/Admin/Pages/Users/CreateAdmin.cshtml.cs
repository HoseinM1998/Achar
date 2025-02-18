using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Dtos.ApplicationUserDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    public class CreateAdminModel : PageModel
    {
        private readonly IApplicationUserAppService _applicationUserAppService;

        public CreateAdminModel(IApplicationUserAppService applicationUserAppService)
        {
            _applicationUserAppService = applicationUserAppService;
        }

        [BindProperty]
        public RegisterDto User { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            await _applicationUserAppService.AdminRegister(User);
            return RedirectToPage("Index");
        }
    }
}
