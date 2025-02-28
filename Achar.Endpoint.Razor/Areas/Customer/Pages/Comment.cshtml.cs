using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Contracts.Customer;
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
        public async Task OnGet(CancellationToken cancellationToken)
        {
            Comments = await _commentAppService.GetAllComment(cancellationToken);
        }

        //public async Task<IActionResult> OnPostComment(CancellationToken cancellationToken)
        //{
    
        //}
    }
}
