using AcharDomainAppService;
using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Dtos.ApplicationUserDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly ICityAppService _cityAppService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(IApplicationUserAppService applicationUserAppService, ICityAppService cityAppService, ILogger<CreateModel> logger)
        {
            _applicationUserAppService = applicationUserAppService;
            _cityAppService = cityAppService;
            _logger = logger;
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
            try
            {
                await _applicationUserAppService.Register(User, cancellationToken);
                TempData["Success"] = "کاربر با موفقیت ایجاد شد.";
                _logger.LogInformation("کاربر با موفقیت ایجاد شد. UserId: {UserName} در زمان: {Time}", User.UserName, DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در ایجاد کاربر. در زمان: {Time}", DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("Index");
        }
    }
}
