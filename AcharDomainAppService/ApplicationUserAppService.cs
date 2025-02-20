

using AcharDomainCore.Contracts.ApplicationUser;
using AcharDomainCore.Dtos.ApplicationUserDto;
using AcharDomainCore.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading;

namespace AcharDomainAppService
{
    public class ApplicationUserAppService : IApplicationUserAppService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly ILogger<ApplicationUserAppService> _logger;


        public ApplicationUserAppService(SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            IPasswordHasher<ApplicationUser> passwordHasher)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _passwordHasher = passwordHasher;


        }

        public async Task<List<IdentityError>> Register(RegisterDto accountRegisterDto,CancellationToken cancellationToken)
        {
            var role = string.Empty;

            var user = CreateUser();

            user.UserName = accountRegisterDto.UserName;

            if (accountRegisterDto.IsExpert)
            {
                role = "Expert";
                user.Expert = new Expert()
                {
                    CityId = accountRegisterDto.CityId,
                };
            }
            else
            {
                role = "Customer";
                user.Customer = new Customer()
                {
                    CityId = accountRegisterDto.CityId,
                };
            }

            var result = await _userManager.CreateAsync(user, accountRegisterDto.Password);

            if (accountRegisterDto.IsExpert)
            {

                var userExpertId = user.Expert!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userExpertId", userExpertId.ToString()));
            }
            else
            {

                var userCustomerId = user.Customer!.Id;
                await _userManager.AddClaimAsync(user, new Claim("userCustomerId", userCustomerId.ToString()));
            }

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, role);

            return (List<IdentityError>)result.Errors;
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                                                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                                                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
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


        public async Task<List<IdentityError>> AdminRegister(RegisterDto accountAdminRegisterDto)
        {
            var user = CreateUser();

            user.UserName = accountAdminRegisterDto.UserName;

            user.Admin = new Admin()
            {
              
            };

            var result = await _userManager.CreateAsync(user, accountAdminRegisterDto.Password);

            var userAdminId = user.Admin!.Id;
            await _userManager.AddClaimAsync(user, new Claim("userAdminId", userAdminId.ToString()));

            if (result.Succeeded)
                await _userManager.AddToRoleAsync(user, "Admin");

            return (List<IdentityError>)result.Errors;
        }

    }
}

