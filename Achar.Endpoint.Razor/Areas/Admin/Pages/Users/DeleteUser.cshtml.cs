using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Dtos.ExpertDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    public class DeleteUserModel : PageModel
    {
        private readonly IApplicationUserAppService _applicationUserAppService;
        private readonly IAdminAppService _adminAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IExpertAppService _expertAppService;
        private readonly ILogger<DeleteUserModel> _logger;

        public DeleteUserModel(IApplicationUserAppService applicationUserAppService,
            IAdminAppService adminAppService,
            ICustomerAppService customerAppService,
            IExpertAppService expertAppService,
            ILogger<DeleteUserModel> logger)
        {
            _applicationUserAppService = applicationUserAppService;
            _adminAppService = adminAppService;
            _customerAppService = customerAppService;
            _expertAppService = expertAppService;
            _logger = logger;
        }

        [BindProperty]
        public SoftDeleteDto delete { get; set; }

        public async Task<IActionResult> OnGetAsync(int id, string userType, CancellationToken cancellationToken)
        {
            delete = new SoftDeleteDto { Id = id };

            if (string.IsNullOrEmpty(userType))
            {
                TempData["ErrorMessage"] = "نوع کاربر مشخص نشده است";
                return BadRequest("نوع کاربر مشخص نشده است");
            }

            ViewData["UserType"] = userType;
            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(SoftDeleteDto delete, string userType, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(userType))
            {
                TempData["ErrorMessage"] = "نوع کاربر مشخص نشده است";
                _logger.LogError("نوع کاربر مشخص نشده است. در زمان: {Time}", DateTime.UtcNow.ToLongTimeString());
                return BadRequest("نوع کاربر مشخص نشده است");
            }

            try
            {
                if (userType == "Admin")
                {
                    var admin = await _adminAppService.DeleteAdmin(delete.Id, cancellationToken);
                    if (admin == null)
                    {
                        TempData["ErrorMessage"] = "ادمین یافت نشد.";
                        _logger.LogError("ادمین یافت نشد. AdminId: {AdminId} در زمان: {Time}", delete.Id, DateTime.UtcNow.ToLongTimeString());
                        return NotFound();
                    }
                }
                else if (userType == "Customer")
                {
                    var customer = await _customerAppService.DeleteCustomer(delete.Id, cancellationToken);
                    if (customer == null)
                    {
                        TempData["ErrorMessage"] = "مشتری یافت نشد.";
                        _logger.LogError("مشتری یافت نشد. CustomerId: {CustomerId} در زمان: {Time}", delete.Id, DateTime.UtcNow.ToLongTimeString());
                        return NotFound();
                    }
                }
                else if (userType == "Expert")
                {
                    var expert = await _expertAppService.DeleteExpert(delete.Id, cancellationToken);
                    if (expert == null)
                    {
                        TempData["ErrorMessage"] = "کارشناس یافت نشد.";
                        _logger.LogError("کارشناس یافت نشد. ExpertId: {ExpertId} در زمان: {Time}", delete.Id, DateTime.UtcNow.ToLongTimeString());
                        return NotFound();
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "نوع کاربر نامعتبر است.";
                    _logger.LogError("نوع کاربر نامعتبر است. در زمان: {Time}", DateTime.UtcNow.ToLongTimeString());
                    return BadRequest("نوع کاربر نامعتبر است");
                }

                TempData["Success"] = "کاربر با موفقیت حذف شد.";
                _logger.LogInformation("کاربر با موفقیت حذف شد. UserId: {UserId} در زمان: {Time}", delete.Id, DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در حذف کاربر. UserId: {UserId} در زمان: {Time}", delete.Id, DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage("Index");
            }
        }
    }
}
