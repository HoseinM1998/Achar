using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos.SubCategoryDto;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Service
{
    public class BidModel : PageModel
    {
        private readonly IBidAppService _bidAppService;

        public BidModel(IBidAppService bidAppService)
        {
          _bidAppService= bidAppService;
        }
        [BindProperty]
        public List<Bid> Bids { get; set; }
        public SoftDeleteDto Delete { get; set; }
        [BindProperty]

        public BidStatusDto Status { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)

        {
            Bids = await _bidAppService.GetBids(cancellationToken);
        }

        public async Task<IActionResult> OnPostChangeStatusBid(CancellationToken cancellationToken)
        {
            await _bidAppService.ChangebidStatus(Status, cancellationToken);
            return RedirectToPage("Bid");

        }
        public async Task<IActionResult> OnPostDeleteBid(CancellationToken cancellationToken)
        {
            await _bidAppService.DeleteBid(Delete, cancellationToken);
            return RedirectToPage("Bid");

        }
    }
}
