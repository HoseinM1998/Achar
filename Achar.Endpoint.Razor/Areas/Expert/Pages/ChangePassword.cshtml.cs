using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos.ApplicationUserDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Expert.Pages
{
    [Authorize(Roles = "Expert")]

    public class ChangePasswordModel : PageModel
    {

        private readonly IExpertAppService _expert;
        private readonly IApplicationUserAppService _user;
        public ChangePasswordModel(IExpertAppService expert, IApplicationUserAppService user)
        {
            _expert= expert;
            _user = user;
        }

        [BindProperty]
        public PasswordDto Password { get; set; }

        public async Task<IActionResult> OnPostChangePassword(CancellationToken cancellationToken)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);
                    var expert = await _expert.GetExpertById(userId, cancellationToken);
                    await _user.Password(expert.ApplictaionUserId, Password);
                    TempData["Success"] = "تغییر پسوورد با موفقیت ثبت شد";
                    return RedirectToPage("Index");
                }
                return RedirectToPage();

            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"خطا({e.Message})";
                return RedirectToPage();
            }

        }
    }
}