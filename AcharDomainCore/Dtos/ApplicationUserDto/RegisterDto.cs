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
        [Required(ErrorMessage = "تکرار رمز‌عبور الزامی می‌باشد")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "انتخاب ‌شهر الزامی می‌باشد")]

        public int CityId { get; set; }
        public bool IsExpert { get; set; }




    }
}
