using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Customer.Pages
{
    [Authorize(Roles = "Customer")]

    public class DeleteModel : PageModel
    {

        private readonly ICustomerAppService _customerAppServices;

        public DeleteModel(ICustomerAppService customerAppServices, ICityAppService cityAppService)
        {
            _customerAppServices = customerAppServices;
        }

        public async Task OnGet(CancellationToken cancellationToken)
        {

        }

        public async Task<IActionResult> OnPostDelete(CancellationToken cancellationToken)
        {
            var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
            if (ModelState.IsValid)
            {
                await _customerAppServices.DeleteCustomer(userCustomerId, cancellationToken);
                TempData["Success"] = "حساب کاربری با موفقیت حذف شد"; 
                return LocalRedirect("/Account/Login");
            }
            else
            {
                TempData["ErrorMessage"] = "خطا در حذف حساب کاربری. لطفاً دوباره تلاش کنید"; 
                return RedirectToPage("/Index");
            }
        }
    }
}
