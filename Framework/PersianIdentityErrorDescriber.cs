using Microsoft.AspNetCore.Identity;

namespace Framework
{
    public class PersianIdentityErrorDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateEmail(string email) => new IdentityError()
        {
            Code = nameof(DuplicateEmail),
            Description = $"ایمیل {email}قبلاٌ توسط شخص دیگری ثبت شده است"
        };
        public override IdentityError DuplicateUserName(string userName) => new IdentityError()
        {
            Code = nameof(DuplicateUserName),
            Description = $"نام کاربری {userName} قبلاً توسط شخص دیگری انتخاب شده است"
        };
        public override IdentityError InvalidEmail(string email) => new IdentityError()
        {
            Code = nameof(InvalidEmail),
            Description = $"ایمیل {email} یک ایمیل معتبر نیست"
        };
        public override IdentityError DuplicateRoleName(string role) => new IdentityError()
        {
            Code = nameof(DuplicateRoleName),
            Description = $"مقام {role} قبلاً ثبت شده است"
        };
        public override IdentityError InvalidRoleName(string role) => new IdentityError()
        {
            Code = nameof(InvalidRoleName),
            Description = $"نام {role} معتبر نیست"
        };

        public override IdentityError PasswordRequiresDigit() => new IdentityError()
        {
            Code = nameof(PasswordRequiresDigit),
            Description = $"رمز عبور باید حداقل دارای یک عدد باشد"
        };

        public override IdentityError PasswordRequiresLower() => new IdentityError()
        {
            Code = nameof(PasswordRequiresLower),
            Description = $"رمز عبور باید حداقل دارای یک کاراکتر انگلسی کوچک باشد ('a'-'z')"
        };

        public override IdentityError PasswordRequiresUpper() => new IdentityError()
        {
            Code = nameof(PasswordRequiresUpper),
            Description = $"رمز عبور باید حداقل دارای یک کاراکتر انگلسی بزرگ باشد ('A'-'Z')"
        };

        public override IdentityError PasswordTooShort(int length) => new IdentityError()
        {
            Code = nameof(PasswordTooShort),
            Description = $"رمز عبور نباید کمتر از{length} کاراکتر باشد"
        };

        public override IdentityError DefaultError() => new IdentityError()
        {
            Code = nameof(DefaultError),
            Description = $"خطای پیش بینی نشده رخ داد"
        };
        public override IdentityError PasswordRequiresNonAlphanumeric() => new IdentityError()
        {
            Code = nameof(PasswordRequiresNonAlphanumeric),
            Description = $"رمز عبور باید حداقل یک کاراکتر غیر الفبایی داشته باشد."
        };
    }
}
