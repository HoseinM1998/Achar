
using AcharDomainCore.Contracts.City;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Dtos.ExpertDto;
using AcharDomainCore.Dtos.HomeServiceDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Achar.Endpoint.Razor.Areas.Expert.Pages
{
    [Authorize(Roles = "Expert")]

    public class ExpertUpdateModel : PageModel
    {
        private readonly IExpertAppService _expertAppServices;
        private readonly IHomeServiceAppService _serviceAppServices;
        private readonly ICityAppService _cityAppService;


        public ExpertUpdateModel(IExpertAppService expertAppServices, IHomeServiceAppService serviceAppServices, ICityAppService cityAppService )
        {
            _expertAppServices = expertAppServices;
            _serviceAppServices = serviceAppServices;
            _cityAppService = cityAppService;
        }

        [BindProperty]
        public ExpertProfDto? ExpertUpdate { get; set; } = new();

        [BindProperty]
        public List<int> ServiceIds { get; set; } = new();

        [BindProperty]
        public List<HomeServiceDto> Services { get; set; } = new();

        [BindProperty]
        public List<City> Cities { get; set; } = new List<City>();
        public async Task OnGet(CancellationToken cancellationToken)
        {
            var expertId = int.Parse(User.Claims.FirstOrDefault(u => u.Type == "userExpertId").Value);
            ExpertUpdate = await _expertAppServices.GetExpertById(expertId, cancellationToken);
            Services = await _serviceAppServices.GetHomeServices(cancellationToken);
            Cities = await _cityAppService.GetAllCity(cancellationToken);
            ExpertUpdate.Id = expertId;
            if (ExpertUpdate != null && ExpertUpdate.Skills != null)
            {
                ServiceIds = ExpertUpdate.Skills.Select(s => s.Id).ToList();
            }
        }

        public async Task<IActionResult> OnPostUpdateProfile(ExpertProfDto expertUpdate, CancellationToken cancellationToken)
        {
            if (ModelState.IsValid)
            {
                await _expertAppServices.UpdateExpert(expertUpdate, cancellationToken);
                TempData["Success"] = "پروفایل با موفقیت بروزرسانی شد";
                return RedirectToPage("Index");
            }
            else
            {
                TempData["ErrorMessage"] = "خطا در بروزرسانی پروفایل. لطفاً داده‌ها را بررسی کنید"; 
                return RedirectToPage("Index");
            }
        }
    }
}