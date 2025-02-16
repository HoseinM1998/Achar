using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AcharDomainCore.Dtos.AdminDto
{
    public class AdminDto
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "نام نمی‌تواند بیشتر از 50 کاراکتر باشد")]
        [MinLength(3, ErrorMessage = "نام نمی‌تواند کمتر از 3 کاراکتر باشد")]
        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        public string FirstName { get; set; }
        [MaxLength(50, ErrorMessage = "نام خانوادگی نمی‌تواند بیشتر از 50 کاراکتر باشد")]
        [MinLength(3, ErrorMessage = "نام خانوادگی نمی‌تواند کمتر از 3 کاراکتر باشد")]
        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "وارد کردن نام کاربری الزامی است")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "اوارد کردن ایمیل  الزامی است")]
        [EmailAddress(ErrorMessage = "فرمت ایمیل اشتباه است")]
        public string Email { get; set; }
        [DisplayName(" عکس پروفایل")]
        [Required(ErrorMessage = "عکس پروفایل خودراانتخاب کنید")]

        public string ProfileImageUrl { get; set; }
        [DisplayName("شماره تلفن")]
        [Length(11, 11, ErrorMessage = " شماره تلفن نمی‌تواند کمتر یا بیشتر از 11 کاراکتر باشد")]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "فرمت شماره تلفن اشتباه است و باید با 09 شروع شود")]
        [Required(ErrorMessage = "وارد کردن شماره تلفن  الزامی است")]
        public string PhoneNumber { get; set; }
    }
}
