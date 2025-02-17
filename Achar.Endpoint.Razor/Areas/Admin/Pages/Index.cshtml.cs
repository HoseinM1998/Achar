using AcharDomainCore.Contracts.Admin;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.Comment;
using AcharDomainCore.Contracts.Customer;
using AcharDomainCore.Contracts.Expert;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Achar.Endpoint.Razor.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IAdminAppService _adminAppService;
        private readonly IExpertAppService _expertAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly ICategoryService _categoryAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly IHomeServiceAppService _homeServiceAppService;
        private readonly ICommentAppService _commentAppService;
        private readonly IRequestAppService _requestAppService;

        public IndexModel(
                   IAdminAppService adminAppService,
                   IExpertAppService expertAppService,
                   ICustomerAppService customerAppService,
                   ICategoryService categoryAppService,
                   ISubCategoryAppService subCategoryAppService,
                   IHomeServiceAppService homeServiceAppService,
                   ICommentAppService commentAppService,
                   IRequestAppService requestAppService)
        {
            _adminAppService = adminAppService;
            _expertAppService = expertAppService;
            _customerAppService = customerAppService;
            _categoryAppService = categoryAppService;
            _subCategoryAppService = subCategoryAppService;
            _homeServiceAppService = homeServiceAppService;
            _commentAppService = commentAppService;
            _requestAppService = requestAppService;
        }

        [BindProperty]
        public int CountAdmin { get; set; }
        [BindProperty]
        public int CountExperts { get; set; }
        [BindProperty]
        public int CountCustomers { get; set; }
        [BindProperty]
        public int CountCategories { get; set; }
        [BindProperty]
        public int CountSubCategories { get; set; }
        [BindProperty]
        public int CountHomeServices { get; set; }
        [BindProperty]
        public int CountComments { get; set; }
        [BindProperty]
        public int CountRequests { get; set; }

        public async Task OnGet(CancellationToken cancellationToken)
        {
            CountAdmin = await _adminAppService.AdminCount(cancellationToken);
            CountExperts = await _expertAppService.ExpertCount(cancellationToken);
            CountCustomers = await _customerAppService.CoustomerCount(cancellationToken);
            CountCategories = await _categoryAppService.CategoryCount(cancellationToken);
            CountSubCategories = await _subCategoryAppService.SubCategoryCount(cancellationToken);
            CountHomeServices = await _homeServiceAppService.HomeServiceCount(cancellationToken);
            CountComments = await _commentAppService.CommentCount(cancellationToken);
            CountRequests = await _requestAppService.RequestCount(cancellationToken);
        }



       

    }
}

