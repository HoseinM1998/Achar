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

namespace Achar.Endpoint.Razor.Pages
{
    [Area(areaName: "Account")]
    public class RegisterModel : PageModel
    {
        private readonly IApplicationUserAppService _accountAppServices;
        private readonly ICityAppService _city;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(IApplicationUserAppService accountAppServices, ICityAppService city, ILogger<RegisterModel> logger)
        {
            _accountAppServices = accountAppServices;
            _city = city;
            _logger = logger;
        }

        [BindProperty]
        public RegisterDto AccountRegister { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; } = new List<City>();

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Cities = await _city.GetAllCity(cancellationToken);
        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                Cities = await _city.GetAllCity(cancellationToken);
                return Page();
            }

            try
            {
                var result = await _accountAppServices.Register(AccountRegister, cancellationToken);
                if (result.Count == 0)
                {
                    TempData["Success"] = "ثبت‌نام با موفقیت انجام شد.";
                    _logger.LogInformation("ثبت‌نام با موفقیت انجام شد. نام کاربر: {UserName} در زمان: {Time}", AccountRegister.UserName, DateTime.UtcNow.ToLongTimeString());
                    return LocalRedirect(Url.Content("~/Account/Login"));
                }

                foreach (var error in result)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                TempData["ErrorMessage"] = "خطا در انجام عملیات ثبت‌نام.";
                _logger.LogError("خطا در انجام عملیات ثبت‌نام برای کاربر. نام کاربر: {UserName} در زمان: {Time}", AccountRegister.UserName, DateTime.UtcNow.ToLongTimeString());

                Cities = await _city.GetAllCity(cancellationToken);
                return Page();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات.";
                _logger.LogError(ex, "خطا در انجام عملیات ثبت‌نام. در زمان: {Time}", DateTime.UtcNow.ToLongTimeString());

                Cities = await _city.GetAllCity(cancellationToken);
                return Page();
            }
        }
    }
}