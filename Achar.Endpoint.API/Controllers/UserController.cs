using Microsoft.AspNetCore.Identity;
using AcharDomainCore.Dtos.ApplicationUserDto;
using AcharDomainCore.Entites.Config;
using Microsoft.AspNetCore.Mvc;
using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Entites;
using AcharDomainCore.Contracts.City; 

namespace Achar.Endpoint.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUserAppService _appService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly string _apiKey;
        private readonly ICityAppService _cityService; 

        public UserController(IApplicationUserAppService appService, UserManager<ApplicationUser> userManager, SiteSetting siteSetting, ICityAppService cityService)
        {
            _appService = appService;
            _userManager = userManager;
            _apiKey = siteSetting.ApiKey;
            _cityService = cityService; 
        }

        private bool ValidateApiKey(string? apikey) => !string.IsNullOrWhiteSpace(apikey) && apikey == _apiKey;

        private async Task<bool> ValidateCityAsync(int cityId, CancellationToken cancellationToken)
        {
            var validCities = await _cityService.GetAllCity(cancellationToken);
            return validCities.Any(c => c.Id == cityId);
        }

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

            var existingUser = await _userManager.FindByNameAsync(register.UserName);
            if (existingUser != null)
                return Conflict(new { message = "این نام کاربری قبلاً ثبت شده است" });

            if (!await ValidateCityAsync(register.CityId, cancellationToken))
                return BadRequest(new { message = "شهر وارد شده معتبر نمی‌باشد" });
            var userId = await _appService.Register(register, cancellationToken);
            return Ok(new { message = "کاربر با موفقیت اضافه شد", register.UserName });
        }
    }
}
