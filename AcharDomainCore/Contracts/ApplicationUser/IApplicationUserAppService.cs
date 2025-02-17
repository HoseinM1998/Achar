using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcharDomainCore.Dtos.ApplicationUserDto;

namespace AcharDomainCore.Contracts.ApplicationUser
{
    public interface IApplicationUserAppService
    {   Task<List<IdentityError>> Register(RegisterDto registerDto, CancellationToken cancellationToken);
        Task<List<IdentityError>> AdminRegister(RegisterDto accountAdminRegisterDto);
        Task<IdentityResult> Login(string username, string password);

    }
}
