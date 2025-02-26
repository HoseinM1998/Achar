using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos.Request;
using AcharDomainCore.Dtos;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Achar.Endpoint.Razor.Areas.Expert.Pages
{
    [Authorize(Roles = "Expert")]
    public class RequestsModel : PageModel
    {
        private readonly IRequestAppService _requestAppService;
        private readonly IBidAppService _bidAppService;


        public RequestsModel(IRequestAppService requestAppService,IBidAppService bidAppService)
        {
            _requestAppService = requestAppService;
            _bidAppService = bidAppService;
        }

        [BindProperty]
        public List<RequestGetDto?> Requests { get; set; }

        [BindProperty]
        public Bid? Bid { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);

            Requests = await _requestAppService.GetRequestsByExpert(userId,cancellationToken);

        }

    }
}
