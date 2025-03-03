using AcharDomainCore.Contracts.Bid;
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

    public class ListRequestModel : PageModel
    {
        private readonly IRequestAppService _requestAppService;

        public ListRequestModel(IRequestAppService requestAppService, IBidAppService bidAppService)
        {
            _requestAppService = requestAppService;
        }

        [BindProperty]
        public List<RequestGetDto> Request { get; set; }

        public async Task OnGetAsync(CancellationToken cancellationToken)
        {
            try
            {
                var userCustomerId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == "userCustomerId")?.Value ?? "0");
                Request = await _requestAppService.GetCustomerRequests(userCustomerId, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
            }
        }

        public async Task<IActionResult> OnPostAcceptRequest(int id, int bidId,decimal bidPrice, CancellationToken cancellationToken)
        {
            try
            {
                await _requestAppService.AcceptExpert(id, bidId, bidPrice, cancellationToken);
                TempData["Success"] = "پیشنهاد تایید شد";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در تایید پیشنهاد";
            }
            return RedirectToPage("ListRequest");
        }

        public async Task<IActionResult> OnPostDoneRequest(int id, int bidId, CancellationToken cancellationToken)
        {
            try
            {
                await _requestAppService.DoneRequest(id, bidId, cancellationToken);
                TempData["Success"] = "با موفقیت تمام شد";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
            }
            return RedirectToPage("ListRequest");
        }

        public async Task<IActionResult> OnPostCancellRequest(int id, int bidId, CancellationToken cancellationToken)
        {
            try
            {
                await _requestAppService.CancellRequest(id, bidId, cancellationToken);
                TempData["Success"] = "با موفقیت کنسل شد";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا کنسل نشد";
            }
            return RedirectToPage("ListRequest");
        }
    }
}
