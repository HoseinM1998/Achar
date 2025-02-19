using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos.SubCategoryDto;
using AcharDomainCore.Dtos;
using AcharDomainCore.Dtos.HomeServiceDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serilog;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages.HomeService
{
    public class ListHomeServiceModel : PageModel
    {
        private readonly IHomeServiceAppService _homeServiceAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly ILogger<IndexModel> _logger;

        public ListHomeServiceModel(IHomeServiceAppService homeServiceAppService, ISubCategoryAppService subCategoryAppService, ILogger<IndexModel> logger)
        {
            _homeServiceAppService = homeServiceAppService;
            _subCategoryAppService = subCategoryAppService;
            _logger = logger;
        }

        [BindProperty]
        public List<HomeServiceDto> HomeServices { get; set; }

        [BindProperty]
        public HomeServiceDto NewHomeService { get; set; } = new();

        [BindProperty]
        public List<SubCategoryDto?> SubCategories { get; set; } = new();

        [BindProperty]
        public SoftDeleteDto Delete { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            HomeServices = await _homeServiceAppService.GetHomeServices(cancellationToken);
            SubCategories = await _subCategoryAppService.GetAllSubCategory(cancellationToken);
        }

        public async Task<IActionResult> OnPostCreateService(CancellationToken cancellationToken)
        {
            try
            {
                await _homeServiceAppService.CreateHomeService(NewHomeService, cancellationToken);
                TempData["Success"] = "خدمات با موفقیت ایجاد شد.";
                _logger.LogInformation("[{Time}] خدمات با موفقیت ایجاد شد{Time} ", DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"خطایی رخ داد: {ex.Message}";
                _logger.LogError(ex, "[{Time}] خطا در ایجاد خدمات{Time} ", DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("ListHomeService");
        }

        public async Task<IActionResult> OnPostUpService(CancellationToken cancellationToken)
        {
            try
            {
                await _homeServiceAppService.UpdateHomeService(NewHomeService, cancellationToken);
                TempData["Success"] = "خدمات با موفقیت به‌روزرسانی شد.";
                _logger.LogInformation("[{Time}] خدمات با موفقیت به‌روزرسانی شد{Time} ", DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"خطایی رخ داد: {ex.Message}";
                _logger.LogError(ex, "[{Time}] خطا در به‌روزرسانی خدمات{Time} ", DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("ListHomeService");
        }

        public async Task<IActionResult> OnPostDeleteService(CancellationToken cancellationToken)
        {
            try
            {
                await _homeServiceAppService.DeleteHomeService(Delete, cancellationToken);
                TempData["Success"] = "خدمات با موفقیت حذف شد.";
                _logger.LogInformation("[{Time}] خدمات با موفقیت حذف شد{Time} ", DateTime.UtcNow.ToLongTimeString());
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "خطا در انجام عملیات";
                _logger.LogError(ex, "[{Time}] خطا در حذف خدمات{Time} ", DateTime.UtcNow.ToLongTimeString());
            }
            return RedirectToPage("ListHomeService");
        }
    }
}
