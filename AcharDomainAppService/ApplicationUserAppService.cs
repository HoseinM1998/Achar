

using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Dtos.ApplicationUserDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Threading;

namespace AcharDomainAppService
{
    public class ApplicationUserAppService : IApplicationUserAppService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApplicationUserAppService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;

        }

        public async Task<List<IdentityError>> Register(RegisterDto registerDto, CancellationToken cancellationToken)
        {
            var role = string.Empty;
            var user = new ApplicationUser();
            user.UserName = registerDto.UserName;
            if (registerDto.IsCustomer)
            {
                role = "Customer";
                user.Customer = new Customer()
                {
                    CityId = registerDto.CityId
                };
            }

            if (registerDto.IsExpert)
            {
                role = "Expert";
                user.Expert = new Expert()
                {
                    CityId = registerDto.CityId
                };
            }

            if (registerDto.IsCustomer)
            {
                var userCustomerId = user.Customer!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userCustomerId", userCustomerId.ToString()));
            }

            if (registerDto.IsExpert)
            {
                var userExpertId = user.Expert!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userExpertId", userExpertId.ToString()));
            }

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
            }

            return (List<IdentityError>)result.Errors;
        }


        public async Task<IdentityResult> Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return IdentityResult.Failed(new IdentityError { Description = "نام کاربری یا رمز عبور نمی‌تواند خالی باشد." });
            }

            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent: false, lockoutOnFailure: false);
            return result.Succeeded ? IdentityResult.Success : IdentityResult.Failed(new IdentityError { Description = "نام کاربری یا رمز عبور نادرست است." });
        }
    }
}

