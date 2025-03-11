using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Expert.Pages
{
    [Authorize(Roles = "Expert")]
    public class GetRequestModel : PageModel
    {
        private readonly IRequestAppService _requestAppService;
        public GetRequestModel(IRequestAppService requestAppService)
        {
            _requestAppService = requestAppService;
        }

        [BindProperty]
        public RequestGetDto? Request { get; set; }

        public async Task OnGetAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                Request = await _requestAppService.GetRequestById(id, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"????? ?? ???? ???: {ex.Message}");
            }
        }

    }
}