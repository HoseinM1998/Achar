using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos.ExpertDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Dtos.CommentDto;
using Microsoft.AspNetCore.Authorization;

namespace Achar.Endpoint.Razor.Areas.Customer.Pages
{
    [Authorize(Roles = "Customer")]
    public class ExpertModel : PageModel
    {
        private readonly IExpertAppService _expertAppService;
        private readonly ICommentAppService _commentAppService;


        public ExpertModel(IExpertAppService expertAppService, ICommentAppService commentAppService)
        {
            _expertAppService = expertAppService;
            _commentAppService = commentAppService;
        }

        [BindProperty]
        public ExpertProfDto Expert { get; set; }
        [BindProperty]
        public CommentDto Comment { get; set; }
        [BindProperty]
        public List<GetCommentDto?> CommentExpert { get; set; }
        public async Task OnGetAsync(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                Expert = await _expertAppService.GetExpertById(expertId, cancellationToken);
                CommentExpert = await _commentAppService.GetCommentsByExpertId(expertId, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"خطایی رخ داده است: {ex.Message}");
            }
        }

        public async Task<IActionResult> OnPostCreateComment(CancellationToken cancellationToken)
        {
            try
            {
                var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userCustomerId").Value);
                Comment.CustomerId = userId;

                if (!ModelState.IsValid)
                {
                 
                    await _commentAppService.CreateComment(Comment, cancellationToken);
                    TempData["Success"] = "ارسال کامنت انجام شد";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در ارسال کامنت";
            }
            return RedirectToPage("/Index");

        }
    }
}