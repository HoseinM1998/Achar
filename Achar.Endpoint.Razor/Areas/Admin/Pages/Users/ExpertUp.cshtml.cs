using AcharDomainAppService;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Dtos.ExpertDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AcharDomainCore.Dtos.HomeServiceDto;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    public class ExpertUpModel : PageModel
    {
        private readonly IExpertAppService _expertAppService;
        private readonly ICityAppService _cityAppService;
        private readonly IHomeServiceAppService _homeAppService;

        public ExpertUpModel(IExpertAppService expertAppService, ICityAppService cityAppService, IHomeServiceAppService homeAppService)
        {
            _expertAppService = expertAppService;
            _cityAppService = cityAppService;
            _homeAppService = homeAppService;
        }

        [BindProperty]
        public ExpertProfDto? UpExpert { get; set; }
        [BindProperty]
        public List<City> Cities { get; set; }
        [BindProperty]
        public List<int> ServiceIds { get; set; } = new(); 

        public List<HomeServiceDto> Services { get; set; }

        public async Task OnGet(int id, CancellationToken cancellationToken)
        {
            UpExpert = await _expertAppService.GetExpertById(id, cancellationToken);
            Cities = await _cityAppService.GetAllCity(cancellationToken);
            Services = await _homeAppService.GetHomeServices(cancellationToken);

            if (UpExpert != null && UpExpert.Skills != null)
            {
                ServiceIds = UpExpert.Skills.Select(s => s.Id).ToList();
            }
        }

        public async Task<IActionResult> OnPostUpdate(CancellationToken cancellationToken)
        {
            var expert = await _expertAppService.UpdateExpert(UpExpert, cancellationToken);
            if (expert == null)
            {
                return NotFound();
            }
            return RedirectToPage("Index");
        }
    }
}
