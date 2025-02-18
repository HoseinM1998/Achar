using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Dtos.ExpertDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    public class DeleteUserModel : PageModel
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly IAdminAppService _adminAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IExpertAppService _expertAppService;

        public DeleteUserModel(IApplicationUserAppService applicationUserAppService,
            IAdminAppService adminAppService,
            ICustomerAppService customerAppService,
            IExpertAppService expertAppService)
        {
            _applicationUserAppService = applicationUserAppService;
            _adminAppService = adminAppService;
            _customerAppService = customerAppService;
            _expertAppService = expertAppService;
        }

        [BindProperty]
        public SoftDeleteDto delete { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, string userType, CancellationToken cancellationToken)
        {
            delete = new SoftDeleteDto { Id = id };

            if (string.IsNullOrEmpty(userType))
            {
                return BadRequest("نوع کاربر مشخص نشده است");
            }

            ViewData["UserType"] = userType;
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(SoftDeleteDto delete, string userType, CancellationToken cancellationToken)

        {

            if (string.IsNullOrEmpty(userType))
            {
                return BadRequest("نوع کاربر مشخص نشده است");
            }
           
            if (userType == "Admin")
            {
                var admin = await _adminAppService.DeleteAdmin(delete.Id, cancellationToken);
                if (admin == null)
                {
                    return NotFound();
                }
            }
            else if (userType == "Customer")
            {
                var customer = await _customerAppService.DeleteCustomer(delete.Id, cancellationToken);
                if (customer == null)
                {
                    return NotFound();
                }
            }
            else if (userType == "Expert")
            {
                var expert = await _expertAppService.DeleteExpert(delete.Id, cancellationToken);
                if (expert == null)
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest("نوع کاربر نامعتبر است");
            }

            return RedirectToPage("Index");

        }
    }
}
