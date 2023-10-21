using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 100, ErrorMessage = "  .{0} شامل حداقل {1}  و حداکثر {2} کاراکتر می باشد ", MinimumLength = 3)]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "مرابه خاطر بسپار")]
        public bool RememberMe { get; set; }

    }
}
