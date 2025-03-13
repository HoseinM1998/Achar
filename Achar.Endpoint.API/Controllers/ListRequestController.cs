using AcharDomainCore.Contracts.Request;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Achar.Endpoint.Api.ActionFillter; 

namespace Achar.Endpoint.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(FilterApiKey))] 
    public class ListRequestController : ControllerBase
    {
        private readonly IRequestAppService _appService;

        public ListRequestController(IRequestAppService appService)
        {
            _appService = appService;
        }

        [HttpGet("GetRequests")]
        public async Task<IActionResult> GetRequests(CancellationToken cancellationToken)
        {
            var requests = await _appService.GetRequests(cancellationToken);

            if (requests == null || requests.Count == 0)
                return NotFound(new { message = "هیچ درخواستی یافت نشد." });

            return Ok(requests);
        }
    }
}