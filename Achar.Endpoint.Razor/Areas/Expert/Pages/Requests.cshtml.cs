using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Expert.Pages
{
    public class RequestsModel : PageModel
    {
        private readonly IRequestAppService _requestAppService;

        public RequestsModel(IRequestAppService requestAppService)
        {
            _requestAppService = requestAppService;
        }

        [BindProperty]
        public List<RequestGetDto?> Requests { get; set; }


        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);

            Requests = await _requestAppService.GetRequestsByExpert(userId,cancellationToken);
        }

        public async Task<IActionResult> OnPostSendBid(CancellationToken cancellationToken)
        {
            try
            {

                TempData["Success"] = "وضعیت درخواست با موفقیت تغییر یافت.";

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
              
            }
            return RedirectToPage("Request");
        }
    }
}
