using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Dtos.AdminDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    public class AdminUpModel : PageModel
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly IAdminAppService _adminAppService;

        public AdminUpModel(
            IApplicationUserAppService applicationUserAppService,
            IAdminAppService adminAppService
        )
        {
            _applicationUserAppService = applicationUserAppService;
            _adminAppService = adminAppService;
        }

        [BindProperty]
        public AdminProfDto UpAdmin { get; set; }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            UpAdmin = await _adminAppService.GetAdminById(id, cancellationToken);
        }

        public async Task<IActionResult> OnPostUpdate(CancellationToken cancellationToken)
        {
            var admin = await _adminAppService.UpdateAdmin(UpAdmin, cancellationToken);
            if (admin == null)
            {
                return NotFound();
            }

            return RedirectToPage("Index");

        }
    }
}