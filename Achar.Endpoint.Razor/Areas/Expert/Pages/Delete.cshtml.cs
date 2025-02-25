using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Contracts.Expert;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Expert.Pages
{
        [Authorize(Roles = "Expert")]

        public class DeleteModel : PageModel
        {

            private readonly IExpertAppService _expertAppService;

            public DeleteModel(IExpertAppService expertAppService, ICityAppService cityAppService)
            {
                _expertAppService = expertAppService;
            }

            public async Task OnGet(CancellationToken cancellationToken)
            {

            }

        public async Task<IActionResult> OnPostDelete(CancellationToken cancellationToken)
        {
            var userExpertId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userExpertId").Value);
            if (ModelState.IsValid)
            {
                await _expertAppService.DeleteExpert(userExpertId, cancellationToken);
                TempData["Success"] = "حساب کاربری با موفقیت حذف شد"; 
                return LocalRedirect("/Account/Login");
            }
            else
            {
                TempData["ErrorMessage"] = "خطا در حذف حساب کاربری لطفاً دوباره تلاش کنید"; 
                return RedirectToPage("/Index");
            }
        }
    }
}
