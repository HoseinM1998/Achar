using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Dtos.ApplicationUserDto;
using AcharDomainCore.Entites.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Achar.Endpoint.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUserAppService _appService;
        private readonly string _apiKey;

        public UserController(IApplicationUserAppService appService, SiteSetting siteSetting)
        {
            _appService = appService;
            _apiKey = siteSetting.ApiKey;

        }

        private bool ValidateApiKey(string? apikey) => !string.IsNullOrWhiteSpace(apikey) && apikey == _apiKey;

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto? register, [FromHeader] string? apikey, CancellationToken cancellationToken)
        {
            if (!ValidateApiKey(apikey))
                return Unauthorized(new { message = "شما دسترسی به این ای پی آی ندارید" });

            if (register is null)
                return BadRequest(new { message = "داده‌های کاربر نمی‌توانند خالی باشند" });

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return BadRequest(new { message = "اطلاعات وارد شده صحیح نیست", errors });
            }

            if (register.Password != register.ConfirmPassword)
                return BadRequest(new { message = "رمز عبور و تکرار رمز عبور باید یکسان باشند" });

            var userId = await _appService.Register(register, cancellationToken);

            return Ok(new { message = "کاربر با موفقیت اضافه شد", register.UserName });
        }
    }
}