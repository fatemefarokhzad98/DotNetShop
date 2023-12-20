
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.User
{
    public class AcountViewModel
    {
        [EmailAddress]

        [Display(Name ="ایمیل")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]
        public string Email { get; set; }

        [Display(Name = "نام خانوادگی")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]
        public string Family { get; set; }
      

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]
        public string UserName { get; set; }
        public string? Image { get; set; }

      

        [Display(Name = "نام")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]
        public string Name { get; set; }

 

        [Display(Name = "شماره موبایل")]
        [Phone]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]

        public string PhoneNumber { get; set; }

      

        [StringLength(maximumLength: 100, ErrorMessage = "  .{0} شامل حداقل {1}  و حداکثر {2} کاراکتر می باشد ", MinimumLength = 3)]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]
        public string PassWord { get; set; }


        [Display(Name = "تکرار رمز عبور")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]
        [DataType(DataType.Password)]
        [Compare(nameof(PassWord), ErrorMessage = ".رمز عبور و تکرار رمز عبور باید یکسان باشند ")]
        public string ConformPassWord { get; set; }

        [Display(Name = "تاریخ تولد")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]
        public string BrithDate { get; set; }
        [Display(Name = "نقش ها")]
        [Required(ErrorMessage = "وارد کردن{0}الزامی است. ")]
        public List<int> Roles { get; set; }







    }
}
