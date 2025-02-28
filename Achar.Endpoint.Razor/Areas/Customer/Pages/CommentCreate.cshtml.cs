using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Dtos.CommentDto;
using AcharDomainCore.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace Achar.Endpoint.Razor.Areas.Customer.Pages
{
    [Authorize(Roles = "Customer")]

    public class CommentCreateModel : PageModel
    {
        private readonly ICommentAppService _commentAppService;

        public CommentCreateModel(ICommentAppService comeAppService)
        {
            _commentAppService = comeAppService;
        }
        [BindProperty]
        public CommentDto Comment { get; set; } 
        public async Task OnGet(CancellationToken cancellationToken)
        {
         
        }

        public async Task<IActionResult> OnPostCreateComment(CancellationToken cancellationToken)
        {
            try
            {
                await _commentAppService.CreateComment(Comment, cancellationToken);
                TempData["Success"] = "??? ?? ?????? ????? ??.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "??? ?? ????? ??????";
            }
            return RedirectToPage("Comment");
        }
    }
}
