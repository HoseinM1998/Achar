using AcharDomainAppService;
using AcharDomainCore.Contracts.Category;
using AcharDomainCore.Contracts.HomeService;
using AcharDomainCore.Contracts.SubCategory;
using AcharDomainCore.Entites.Config;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using AcharDomainCore.Contracts.Dapper;

namespace Achar.Endpoint.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListServiceController : ControllerBase
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly ISubCategoryAppService _subCategoryAppService;
        private readonly IHomeServiceAppService _homeServiceAppService;

        private readonly string _apiKey;

        public ListServiceController(ICategoryAppService categoryAppService, ISubCategoryAppService subCategoryAppService, IHomeServiceAppService homeServiceAppService, SiteSetting siteSetting)
        {
            _categoryAppService=categoryAppService;
            _subCategoryAppService=subCategoryAppService;
            _homeServiceAppService=homeServiceAppService;
            _apiKey = siteSetting.ApiKey;
        }

        private bool ValidateApiKey(string? apikey) => !string.IsNullOrWhiteSpace(apikey) && apikey == _apiKey;

        private IActionResult ValidateRequest(string? apikey)
        {
            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی ای را ندارید.");

            return null;
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var validationResponse = ValidateRequest(apikey);
            if (validationResponse != null) return validationResponse;

            var categories = await _categoryAppService.GetAllCategory(cancellationToken);
            return Ok(categories);
        }

        [HttpGet("GetSubCategories")]
        public async Task<IActionResult> GetSubCategories([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var validationResponse = ValidateRequest(apikey);
            if (validationResponse != null) return validationResponse;

            var subCategories = await _subCategoryAppService.GetAllSubCategory(cancellationToken);
            return Ok(subCategories);
        }

        [HttpGet("GetHomeServices")]
        public async Task<IActionResult> GetHomeServices([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var validationResponse = ValidateRequest(apikey);
            if (validationResponse != null) return validationResponse;

            var homeServices = await _homeServiceAppService.GetHomeServices(cancellationToken);
            return Ok(homeServices);
        }
    }
}
