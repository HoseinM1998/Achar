using AcharDomainAppService;
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Dtos.ExpertDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AcharDomainCore.Dtos.HomeServiceDto;
using Microsoft.AspNetCore.Authorization;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]

    public class ExpertUpModel : PageModel
    {
        private readonly IExpertAppService _expertAppService;
        private readonly ICityAppService _cityAppService;
        private readonly IHomeServiceAppService _homeAppService;
        private readonly ILogger<ExpertUpModel> _logger;

        public ExpertUpModel(IExpertAppService expertAppService, ICityAppService cityAppService, IHomeServiceAppService homeAppService, ILogger<ExpertUpModel> logger)
        {
            _expertAppService = expertAppService;
            _cityAppService = cityAppService;
            _homeAppService = homeAppService;
            _logger = logger;
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
            try
            {
                var expert = await _expertAppService.UpdateExpert(UpExpert, cancellationToken);
                if (expert == null)
                {
                    TempData["ErrorMessage"] = "خطا در انجام عملیات";
                    _logger.LogError("خطا در به‌روزرسانی اطلاعات کارشناس با شناسه {ExpertId}. در زمان: {Time}", UpExpert.Id, DateTime.UtcNow.ToLongTimeString());
                    return NotFound();
                }

                TempData["Success"] = "اطلاعات کارشناس با موفقیت به‌روزرسانی شد.";
                _logger.LogInformation("اطلاعات کارشناس با موفقیت به‌روزرسانی شد. ExpertId: {ExpertId} در زمان: {Time}", UpExpert.Id, DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "خطا در به‌روزرسانی اطلاعات کارشناس. ExpertId: {ExpertId} در زمان: {Time}", UpExpert.Id, DateTime.UtcNow.ToLongTimeString());
                return RedirectToPage("Index");
            }
        }
    }
}
