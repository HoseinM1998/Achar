using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.CommentDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Pages.Shared
{
    public class CommentModel : PageModel
    {

        private readonly ICommentAppService _commentAppService;

        public CommentModel(ICommentAppService comeAppService)
        {
            _commentAppService = comeAppService;
        }
        [BindProperty]
        public List<AllCommentDto?> Comments { get; set; }
        [BindProperty]
        public SoftDeleteDto Delete { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);

            Comments = await _commentAppService.GetAllCommentByCustomerId(userId,cancellationToken);
        }

        public async Task<IActionResult> OnPostDeleteComment(CancellationToken cancellationToken)
        {
            try
            {
                await _commentAppService.DeleteComment(Delete, cancellationToken);
                TempData["Success"] = "??? ?? ?????? ??? ??.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "??? ?? ????? ??????";
            }
            return RedirectToPage("Comment");
        }
    }
}
