using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Dtos.AdminDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class AdminUpModel : PageModel
    {

        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly IAdminAppService _adminAppService;
        private readonly ILogger<AdminUpModel> _logger;

        public AdminUpModel(
            IApplicationUserAppService applicationUserAppService,
            IAdminAppService adminAppService,
            ILogger<AdminUpModel> logger
        )
        {
            _applicationUserAppService = applicationUserAppService;
            _adminAppService = adminAppService;
            _logger = logger;
        }

        [BindProperty]
        public AdminProfDto UpAdmin { get; set; }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            UpAdmin = await _adminAppService.GetAdminById(id, cancellationToken);
        }

        public async Task<IActionResult> OnPostUpdate(CancellationToken cancellationToken)
        {
            try
            {
                var admin = await _adminAppService.UpdateAdmin(UpAdmin, cancellationToken);
                if (admin == null)
                {
                    TempData["ErrorMessage"] = "خطا در انجام عملیات";
                    _logger.LogError("خطا در به‌روزرسانی ادمین با شناسه {AdminId}. در زمان: {Time}", UpAdmin.Id, DateTime.UtcNow.ToLongTimeString());
                    return NotFound();
                }

                TempData["Success"] = "اطلاعات ادمین با موفقیت به‌روزرسانی شد.";
                _logger.LogInformation("اطلاعات ادمین با موفقیت به‌روزرسانی شد. AdminId: {AdminId} در زمان: {Time}", UpAdmin.Id, DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در به‌روزرسانی ادمین. AdminId: {AdminId} در زمان: {Time}", UpAdmin.Id, DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage("Index");
            }
        }
    }
}
