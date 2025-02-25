using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Customer.Pages
{
    [Authorize(Roles = "Customer")]
    public class UpdateProfModel : PageModel
    {
        private readonly ICustomerAppService _customerAppServices;
        private readonly ICityAppService _cityAppService;

        public UpdateProfModel(ICustomerAppService customerAppServices, ICityAppService cityAppService)
        {
            _customerAppServices = customerAppServices;
            _cityAppService = cityAppService;
        }

        [BindProperty]
        public CustomerProfDto CustomerUpdate { get; set; } = new CustomerProfDto();

        [BindProperty]
        public List<City> Cities { get; set; } = new List<City>();

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
            CustomerUpdate = await _customerAppServices.GetCustomerById(userCustomerId, cancellationToken);
            Cities = await _cityAppService.GetAllCity(cancellationToken);
        }

        public async Task<IActionResult> OnPostUpdate(CustomerProfDto customerUpdate, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
                customerUpdate.Id = userCustomerId;
                await _customerAppServices.UpdateCustomer(customerUpdate, cancellationToken);
                TempData["Success"] = "اطلاعات با موفقیت بروزرسانی شد"; 
                return RedirectToPage("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "خطا در بروزرسانی اطلاعات. لطفاً داده‌ها را بررسی کنید"; 
                return RedirectToPage("Index");
            }
        }
    }
}
