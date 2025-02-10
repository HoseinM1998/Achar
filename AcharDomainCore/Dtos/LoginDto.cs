using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcharDomainCore.Dtos
{
    public class LoginDto
    {
        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "وارد کردن شماره تلفن اجباری است")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "شماره تلفن باید فقط شامل 11 رقم باشد")]
        public string PhoneNumber { get; set; }
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
