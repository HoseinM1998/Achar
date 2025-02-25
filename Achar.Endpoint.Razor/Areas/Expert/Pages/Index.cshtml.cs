using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos.CustomerDto;
using AcharDomainCore.Dtos.ExpertDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Expert.Pages
{
    [Authorize(Roles = "Expert")]

    public class IndexModel : PageModel
    {
        private readonly IExpertAppService _expertAppService;
        public IndexModel(IExpertAppService expertAppService)
        {
            _expertAppService = expertAppService;
        }

        [BindProperty]
        public ExpertProfDto Expert { get; set; }
        public async Task OnGet(CancellationToken cancellationToken)
        {
            var userId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);


            //var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            //int userId = int.Parse(userIdClaim);
            Expert = await _expertAppService.GetExpertById(userId, cancellationToken);
        }
    }
}
