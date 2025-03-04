using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Expert.Pages
{
    [Authorize(Roles = "Expert")]
    public class SendBidModel : PageModel
    {
        private readonly IBidAppService _bidAppService;
        public SendBidModel(IRequestAppService requestAppService, IBidAppService bidAppService)
        {
            _bidAppService = bidAppService;
        }
        [BindProperty]
        public BidAddDto Bid { get; set; }
        public async Task<IActionResult> OnPostSendBid(CancellationToken cancellationToken)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);
                    Bid.ExpertId = userId;
                    await _bidAppService.CreateBid(Bid, cancellationToken);
                    TempData["Success"] = "پیشنهاد با موفقیت ثبت شد";
                    return RedirectToPage("Index");
                }
                return RedirectToPage("Index");

            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = $"خطا در ثبت پیشنهاد. لطفاً داده‌ها را بررسی کنید({e.Message})";
                return RedirectToPage("Index");
            }
        }
    }
}
