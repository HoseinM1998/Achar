using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class CustomerUpModel : PageModel
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly ICityAppService _cityAppService;
        private readonly ILogger<CustomerUpModel> _logger;

        public CustomerUpModel(ICustomerAppService customerAppService, ICityAppService cityAppService, ILogger<CustomerUpModel> logger)
        {
            _customerAppService = customerAppService;
            _cityAppService = cityAppService;
            _logger = logger;
        }

        [BindProperty]
        public CustomerProfDto UpCustomer { get; set; }

        [BindProperty]
        public List<City> CityList { get; set; }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            UpCustomer = await _customerAppService.GetCustomerById(id, cancellationToken);
            CityList = await _cityAppService.GetAllCity(cancellationToken);
        }

        public async Task<IActionResult> OnPostUpdate(CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerAppService.UpdateCustomer(UpCustomer, cancellationToken);
                if (customer == null)
                {
                    TempData["ErrorMessage"] = "خطا در انجام عملیات";
                    _logger.LogError("خطا در به‌روزرسانی اطلاعات مشتری با شناسه {CustomerId}. در زمان: {Time}", UpCustomer.Id, DateTime.UtcNow.ToLongTimeString());
                    return NotFound();
                }

                TempData["Success"] = "اطلاعات مشتری با موفقیت به‌روزرسانی شد.";
                _logger.LogInformation("اطلاعات مشتری با موفقیت به‌روزرسانی شد. CustomerId: {CustomerId} در زمان: {Time}", UpCustomer.Id, DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در به‌روزرسانی اطلاعات مشتری. CustomerId: {CustomerId} در زمان: {Time}", UpCustomer.Id, DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage("Index");
            }
        }
    }
}
