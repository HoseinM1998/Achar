using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos.HomeServiceDto;
using AcharDomainCore.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Customer.Pages
{
    [Authorize(Roles = "Customer")]
    public class RequestModel : PageModel
    {
        private readonly IRequestAppService _requestAppService;
        private readonly IHomeServiceAppService _Service;

        public RequestModel(IRequestAppService requestAppService, IHomeServiceAppService service)
        {
            _requestAppService = requestAppService;
            _Service = service;
        }

        [BindProperty]
        public RequestDto Request { get; set; } = new RequestDto(); 
        [BindProperty]
        public List<HomeServiceGetDto> Services { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            Services = await _Service.GetHomeServiceRequest(cancellationToken);
        }

        public async Task<IActionResult> OnPostRequest(CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId").Value);
                Request.CustomerId = userCustomerId;
                await _requestAppService.CreateRequest(Request, cancellationToken);
                return RedirectToPage("Index");
            }
            return RedirectToPage("Index");

        }
    }
}
