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
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly IAdminAppService _adminAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IExpertAppService _expertAppService;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IApplicationUserAppService applicationUserAppService,
            IAdminAppService adminAppService,
            ICustomerAppService customerAppService,
            IExpertAppService expertAppService,
            ILogger<IndexModel> logger)
        {
            _applicationUserAppService = applicationUserAppService;
            _adminAppService = adminAppService;
            _customerAppService = customerAppService;
            _expertAppService = expertAppService;
            _logger = logger;
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
                TempData["ErrorMessage"] = "شناسه نامعتبر است.";
                _logger.LogError("شناسه نامعتبر است. در زمان: {Time}", DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage();
            }

            var activeDto = new SoftActiveDto
            {
                Id = id,
                IsActive = isActive
            };

            try
            {
                var expert = await _expertAppService.IActiveExpert(activeDto, cancellationToken);
                if (!expert)
                {
                    TempData["ErrorMessage"] = "کارشناس یافت نشد.";
                    _logger.LogError("کارشناس یافت نشد. ExpertId: {ExpertId} در زمان: {Time}", id, DateTime.UtcNow.ToLongTimeString());
                    return RedirectToPage();
                }

                TempData["Success"] = "وضعیت کارشناس با موفقیت تغییر یافت.";
                _logger.LogInformation("وضعیت کارشناس با موفقیت تغییر یافت. ExpertId: {ExpertId} در زمان: {Time}", id, DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در تغییر وضعیت کارشناس. ExpertId: {ExpertId} در زمان: {Time}", id, DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage();
            }
        }
    }
}
