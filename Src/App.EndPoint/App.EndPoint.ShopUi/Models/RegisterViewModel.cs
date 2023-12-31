﻿using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Models
{
    public class RegisterViewModel
    {

        [Required (ErrorMessage ="وارد کردن{0}الزامی است. ")]
        [EmailAddress]
        [Display(Name ="نام کاربری")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]

        [StringLength(maximumLength: 100, ErrorMessage = "  .{0} شامل حداقل {1}  و حداکثر {2} کاراکتر می باشد ", MinimumLength = 3)]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]

        [Display(Name = "تکرار رمز عبور")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password), ErrorMessage =".رمز عبور و تکرار رمز عبور باید یکسان باشند ")]
        public string ConfirmPassword { get; set; }
        [Display(Name = " تلفن همراه")]
        [Phone ]
        [StringLength(maximumLength:11,MinimumLength =11)]

        public string ?Mobile { get; set; }
    }
}
