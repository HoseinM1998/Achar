using System.ComponentModel.DataAnnotations;
using AcharDomainCore.Contracts.Customer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Customer.Pages
{
    public class UpdateBalanceModel : PageModel
    {
        private readonly ICustomerAppService _customerAppServices;
        public UpdateBalanceModel(ICustomerAppService customerAppServices)
        {
            _customerAppServices = customerAppServices;
        }
        [BindProperty]
        [Range(100.01, (double)decimal.MaxValue, ErrorMessage = "????? Balance ???? ??????? ?? ??? ????.")]
        public decimal Balance { get; set; }

        public async Task<IActionResult> OnPostBalance( CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "?????? ?????? ????? ??? ????";
                return RedirectToPage("Index");
            }

            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);
            await _customerAppServices.UpdateBalance(userId, Balance, cancellationToken);

            TempData["Success"] = "?????? ?? ?????? ?????? ????.";
            return RedirectToPage("Index");

        }
    }
}
