using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.ApplicationUserDto
{
    public class PasswordDto
    {

        [Required(ErrorMessage = "رمز‌عبور قبلی الزامی می‌باشد")]
        public string OldPassword { get; set; }

        [MinLength(5, ErrorMessage = "رمزعبور جدید نمی‌تواند کمتر 5 کاراکتر باشد")]
        public string NewPassword { get; set; }

    }
}
