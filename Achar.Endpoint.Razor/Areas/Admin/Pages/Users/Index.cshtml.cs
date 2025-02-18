using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.AdminDto;
using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Dtos.ExpertDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly IAdminAppService _adminAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IExpertAppService _expertAppService;


        public IndexModel(IApplicationUserAppService applicationUserAppService,
            IAdminAppService adminAppService,
            ICustomerAppService customerAppService,
            IExpertAppService expertAppService
            )
        {
            _applicationUserAppService = applicationUserAppService;
            _adminAppService = adminAppService;
            _customerAppService = customerAppService;
            _expertAppService = expertAppService;
        }

        [BindProperty]
        public List<ExpertProfDto> Expert { get; set; }

        [BindProperty]
        public List<CustomerGetAll> Customer { get; set; }
        [BindProperty]
        public List<AcharDomainCore.Entites.Admin> Admin { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)

        {
            Expert = await _expertAppService.GetExperts(cancellationToken);
            Customer = await _customerAppService.GetCustomers(cancellationToken);
            Admin = await _adminAppService.GetAllAmin(cancellationToken);

        }


        public async Task<IActionResult> OnPostChangeExpertStatusAsync(int id, bool isActive, CancellationToken cancellationToken)
        {
            if (id <= 0)
            {
                return RedirectToPage();
            }
            var activeDto = new SoftActiveDto
            {
                Id = id,
                IsActive = isActive
            };
            var expert = await _expertAppService.IActiveExpert(activeDto, cancellationToken);
            if (!expert)
            {
                return RedirectToPage();
            }

            return RedirectToPage("Index");

        }
    }
}
