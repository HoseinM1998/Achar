using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Dtos.ApplicationUserDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Pages.Areas.Account.Page
{
    public class RegisterModel : PageModel
    {
        private readonly IApplicationUserAppService _accountAppServices;
        private readonly ICityAppService _city;

        public RegisterModel(IApplicationUserAppService accountAppServices, ICityAppService city)
        {
            _accountAppServices = accountAppServices;
            _city = city;
        }

        [BindProperty]
        public RegisterDto AccountRegister { get; set; }

        [BindProperty]
        public List<City> Cities { get; set; } = new List<City>();


        public async Task OnGet(CancellationToken cancellationToken)
        {
            Cities = await _city.GetAllCity(cancellationToken);

        }

        public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken, string returnUrl = null)

        {
            if (!ModelState.IsValid)
                return Page();

            var result = await _accountAppServices.Register(AccountRegister, cancellationToken);
            Console.WriteLine(result.Count);
            if (result.Count == 0)
            {
                return LocalRedirect(returnUrl ?? Url.Content("~/Account/Login"));
            }

            foreach (var error in result)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
        }
    }
}
