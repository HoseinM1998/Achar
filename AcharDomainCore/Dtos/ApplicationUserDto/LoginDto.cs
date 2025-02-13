using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.ApplicationUserDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "وارد کردن یوزرنیم اجباری است")]
        [Length(5, 50, ErrorMessage = "یوزرنیم نمی‌تواند کمتر 5 و بیشتر از 50 کاراکتر باشد")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "وارد کردن رمزعبور اجباری است")]
        [MinLength(5, ErrorMessage = "رمزعبور نمی‌تواند کمتر 5 کاراکتر باشد")]
        public string Password { get; set; }
    }
}
