using Achar.Endpoint.Razor.Areas.Admin.Pages.Service;
using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Expert.Pages
{
    public class BidsModel : PageModel
    {

        private readonly IBidAppService _bidAppService;
        private readonly ILogger<BidModel> _logger;

        public BidsModel(IBidAppService bidAppService, ILogger<BidModel> logger)
        {
            _bidAppService = bidAppService;
            _logger = logger;
        }

        [BindProperty]
        public List<GetBidDto> Bids { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);

            Bids = await _bidAppService.GetBidsByExpertId(userId,cancellationToken);
        }


    }
}
