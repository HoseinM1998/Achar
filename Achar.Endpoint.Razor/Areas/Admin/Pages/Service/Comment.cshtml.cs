using AcharDomainCore.Contracts.Bid;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Dtos.BidDto;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CommentDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Service
{
    public class CommentModel : PageModel
    {
        private readonly ICommentAppService _commentAppService;

        public CommentModel(ICommentAppService commentAppService)
        {
            _commentAppService = commentAppService;
        }
        [BindProperty]
        public List<AllCommentDto?> Comments { get; set; }
        public SoftDeleteDto Delete { get; set; }
        [BindProperty]
        public CommentAcceptDto Status { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)

        {
            Comments = await _commentAppService.GetAllComment(cancellationToken);
        }

        public async Task<IActionResult> OnPostActiveComment(CancellationToken cancellationToken)
        {
            await _commentAppService.AcceptComment(Status, cancellationToken);
            return RedirectToPage("Comment");

        }
        public async Task<IActionResult> OnPostDeleteComment(CancellationToken cancellationToken)
        {
            await _commentAppService.DeleteComment(Delete, cancellationToken);
            return RedirectToPage("Comment");

        }
    }
}
