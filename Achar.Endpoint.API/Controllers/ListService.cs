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
    public class ListService : ControllerBase
    {
        private readonly IDapper _dapper;
        private readonly string _apiKey;

        public ListService(IDapper dapper, SiteSetting siteSetting)
        {
            _dapper = dapper;
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

            var categories = await _dapper.GetAllCategoryDapper(cancellationToken);
            return Ok(categories);
        }

        [HttpGet("GetSubCategories")]
        public async Task<IActionResult> GetSubCategories([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var validationResponse = ValidateRequest(apikey);
            if (validationResponse != null) return validationResponse;

            var subCategories = await _dapper.GetAllSubCategory(cancellationToken);
            return Ok(subCategories);
        }

        [HttpGet("GetHomeServices")]
        public async Task<IActionResult> GetHomeServices([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var validationResponse = ValidateRequest(apikey);
            if (validationResponse != null) return validationResponse;

            var homeServices = await _dapper.GetAllHomeServiceDapper(cancellationToken);
            return Ok(homeServices);
        }
    }
}
