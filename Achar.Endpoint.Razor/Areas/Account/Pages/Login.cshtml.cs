using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Dtos.ApplicationUserDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Account.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IApplicationUserAppService _accountAppServices;

        public LoginModel(IApplicationUserAppService accountAppServices)
        {
            _accountAppServices = accountAppServices;
        }

        [BindProperty]
        public LoginDto AccountLogin { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(LoginDto accountLogin, string returnUrl = null)
        {
            if (!ModelState.IsValid)
                return Page();
            var succeededLogin = await _accountAppServices.Login(accountLogin.UserName, accountLogin.Password);
            if (succeededLogin.Succeeded)
            {
                if (returnUrl != null)
                    return LocalRedirect(returnUrl);

                if (User.IsInRole("Admin"))
                    return LocalRedirect("/AdminArea/Index");

                if (User.IsInRole("Expert"))
                    return LocalRedirect("/ExpertArea/Index");

                if (User.IsInRole("Customer"))
                    return LocalRedirect("/CustomerArea/Index");
            }

            ModelState.AddModelError(string.Empty, "??? ?????? ?? ???? ???? ?????? ???");
            return Page();
        }
    }
}
