
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Dtos.CustomerDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Achar.Endpoint.Razor.Areas.Customer.Pages

{
    [Authorize(Roles = "Customer")]
    public class IndexModel : PageModel
    {
        private readonly ICustomerAppService _customerAppServices;
        public IndexModel(ICustomerAppService customerAppServices)
        {
            _customerAppServices = customerAppServices;
        }

        [BindProperty]
        public CustomerProfDto Customer{ get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);


            //var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //int userId = int.Parse(userIdClaim);
            Customer = await _customerAppServices.GetCustomerById(userId, cancellationToken);
        }

    }
}