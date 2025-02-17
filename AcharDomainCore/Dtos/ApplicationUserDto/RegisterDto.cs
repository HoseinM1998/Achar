using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos.ApplicationUserDto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "نام کاربری الزامی می‌باشد")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "رمز‌عبور الزامی می‌باشد")]
        [MinLength(5, ErrorMessage = "رمزعبور نمی‌تواند کمتر 6 کاراکتر باشد")]
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public int CityId { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsExpert { get; set; }


    }
}
