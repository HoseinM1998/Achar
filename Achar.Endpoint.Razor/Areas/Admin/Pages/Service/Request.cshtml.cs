using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos.CommentDto;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Service
{
    public class RequestModel : PageModel
    {
        private readonly IRequestAppService _requestAppService;

        public RequestModel(IRequestAppService requestAppService)
        {
            _requestAppService = requestAppService;
        }
        [BindProperty]
        public List<RequestGetDto?> Requests { get; set; }
        public SoftDeleteDto Delete { get; set; }
        [BindProperty]
        public StatusRequestDto Status { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)

        {
            Requests = await _requestAppService.GetRequests(cancellationToken);
        }

        public async Task<IActionResult> OnPostChangeStatusRequest(CancellationToken cancellationToken)
        {
            await _requestAppService.ChangeRequestStatus(Status, cancellationToken);
            return RedirectToPage("Request");

        }
        public async Task<IActionResult> OnPostDeleteRequest(CancellationToken cancellationToken)
        {
            await _requestAppService.DeleteRequest(Delete, cancellationToken);
            return RedirectToPage("Request");

        }
    }
}
