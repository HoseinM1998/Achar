using AcharDomainCore.Contracts.Request;
using AcharDomainCore.Entites.Config;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListRequestController : ControllerBase
    {
        private readonly IRequestAppService _appService;
        private readonly string _apiKey;

        public ListRequestController(IRequestAppService appService, SiteSetting siteSetting)
        {
            _appService = appService;
            _apiKey = siteSetting.ApiKey;
        }

        private bool ValidateApiKey(string? apikey) => !string.IsNullOrWhiteSpace(apikey) && apikey == _apiKey;

        private IActionResult ValidateRequest(string? apikey)
        {
            if (!ValidateApiKey(apikey))
                return Unauthorized("شما دسترسی به این ای پی ای را ندارید.");

            return null;
        }

        [HttpGet("GetRequests")]
        public async Task<IActionResult> GetRequests([FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            var validationResult = ValidateRequest(apikey);
            if (validationResult != null)
                return validationResult;

            var requests = await _appService.GetRequests(cancellationToken);

            if (requests == null || requests.Count == 0)
                return NotFound(new { message = "هیچ درخواستی یافت نشد." });

            return Ok(requests);
        }
    }
}