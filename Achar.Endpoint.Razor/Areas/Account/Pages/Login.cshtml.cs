using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Dtos.ApplicationUserDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Account.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IApplicationUserAppService _accountAppServices;
        private readonly ILogger<ApplicationUser> _logger;

        public LoginModel(IApplicationUserAppService accountAppServices, ILogger<ApplicationUser> logger)
        {
            _accountAppServices = accountAppServices;
            _logger = logger;
        }

        [BindProperty]
        public LoginDto AccountLogin { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(LoginDto accountLogin)
        {
            if (!ModelState.IsValid)
                return Page();
            var succeededLogin = await _accountAppServices.Login(accountLogin.UserName, accountLogin.Password);
            if (succeededLogin.Succeeded)
            {

                if (User.IsInRole("Admin"))
                {
                    _logger.LogInformation("Admin sucsses login{Time}", DateTime.UtcNow.ToLongTimeString());
                    TempData["Success"] = "ادمین با موفقیت وارد شد";
                    return LocalRedirect("/Admin/Index");
                }

                if (User.IsInRole("Expert"))
                {
                    _logger.LogInformation("Expert sucsses login{Time}", DateTime.UtcNow.ToLongTimeString());
                    TempData["Success"] = ";کارشناس با موفقیت وارد شد";
                    return LocalRedirect("/Expert/Index");
                }

                if (User.IsInRole("Customer"))
                {
                    TempData["Success"] = "مشتری با موفقیت وارد شد";
                    _logger.LogInformation("Customer sucsses login{Time}", DateTime.UtcNow.ToLongTimeString());
                    return LocalRedirect("/Customer/Index");

                }
                else
                {
                    TempData["Error"] = "نام کاربری یا رمز عبور نادرست است";
                    return RedirectToPage("/User/Login");
                }
            }
            _logger.LogError("username ana password isvalid");
            return Page();
        }
    }
}
