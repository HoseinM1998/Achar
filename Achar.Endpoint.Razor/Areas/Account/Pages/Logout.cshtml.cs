using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Account.Pages
{
    public class LogoutModel(SignInManager<ApplicationUser> signInManager) : PageModel
    {
        //private readonly SignInManager<ApplicationUser> _signInManager = signInManager;
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await signInManager.SignOutAsync();

            return RedirectToPage("/Index");
        }

    }
}
