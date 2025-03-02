using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Dtos.ExpertDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Razor.Areas.Customer.Pages
{
    public class ExpertModel : PageModel
    {
        private readonly IExpertAppService _expertAppService;

        public ExpertModel(IExpertAppService expertAppService)
        {
            _expertAppService = expertAppService;
        }

        [BindProperty]
        public ExpertProfDto Expert { get; set; }

        public async Task OnGetAsync(int expertId, CancellationToken cancellationToken)
        {
            try
            {
                Expert = await _expertAppService.GetExpertById(expertId, cancellationToken);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"خطایی رخ داده است: {ex.Message}");
            }
        }
    }
}