using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Dtos.ApplicationUserDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class CreateAdminModel : PageModel
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly ILogger<CreateAdminModel> _logger;

        public CreateAdminModel(IApplicationUserAppService applicationUserAppService, ILogger<CreateAdminModel> logger)
        {
            _applicationUserAppService = applicationUserAppService;
            _logger = logger;
        }

        [BindProperty]
        public RegisterDto User { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
        }

        public async Task<IActionResult> OnPost(CancellationToken cancellationToken)
        {
            try
            {
                await _applicationUserAppService.AdminRegister(User);
                TempData["Success"] = "ادمین با موفقیت ایجاد شد.";
                _logger.LogInformation("ادمین با موفقیت ایجاد شد. AdminId: {AdminUserName} در زمان: {Time}", User.UserName, DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در ایجاد ادمین. در زمان: {Time}", DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("Index");
        }
    }
}