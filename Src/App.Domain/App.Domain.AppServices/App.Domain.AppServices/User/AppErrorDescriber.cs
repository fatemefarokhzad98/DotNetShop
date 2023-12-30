using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Entities
{
    public class AppErrorDescriber :IdentityErrorDescriber
    {
        public override IdentityError InvalidUserName(string userName) => new IdentityError { Code = nameof(InvalidUserName), Description = "نام کاربری باید شامل کاراکتر های(1-9)و(A-Z)باشد" };
        
        public override IdentityError DuplicateUserName(string userName) => new IdentityError { Code = nameof(DuplicateUserName), Description = $"نام کاربری{userName}قبلا توسط شخص دیگری انتخاب شده است." };
        public override IdentityError PasswordRequiresNonAlphanumeric() => new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = " کلمه ی عبور باید شامل یک کاراکتر غیرعددی و غیر حرفی باشد.(@,#,%,...)" };

        public override IdentityError PasswordRequiresDigit() => new IdentityError { Code = nameof(PasswordRequiresDigit),Description = "باشد. (0-9)کلمه ی عبور باید حداقل شامل یک عدد" };
        public override IdentityError PasswordRequiresLower() => new IdentityError { Code = nameof(PasswordRequiresLower), Description = "کلمه عبور باید حداقل شامل یک حرف کوچک(a-z)باشد" };
        public override IdentityError PasswordRequiresUpper() => new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "کلمه ی عبور حداقل باید شامل  یک حرف بزرگ(A-Z)باشد" };

        public override IdentityError PasswordTooShort(int length) => new IdentityError { Code = nameof(PasswordTooShort), Description = $"کلمه ی عبور شامل حداقل{length}کاراکتر باشد" };

        public override IdentityError DuplicateEmail(string email) => new IdentityError { Code = nameof(DuplicateEmail), Description = $"   شما باایمیل '{email}'قبلا ثبت نام کرده اید." };

        public override IdentityError DuplicateRoleName(string role) => new IdentityError { Code = nameof(DuplicateRoleName), Description = $" نقش '{role}' تکراری است" };

       









    }
}
