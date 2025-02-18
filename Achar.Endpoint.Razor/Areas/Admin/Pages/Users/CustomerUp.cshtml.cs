using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    public class CustomerUpModel : PageModel
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly ICityAppService _cityAppService;

        public CustomerUpModel(ICustomerAppService customerAppService, ICityAppService cityAppService)
        {
            _customerAppService = customerAppService;
            _cityAppService = cityAppService;
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
            var customer = await _customerAppService.UpdateCustomer(UpCustomer, cancellationToken);
            if (customer == null)
            {
                return NotFound();
            }

            return RedirectToPage("Index");

        }
    }
}