using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.User
{
    public class UserManagerViewModel
    {
        public int Id { get; set; }
        [Display(Name ="نام")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = " نام کاربری")]
        public string UserName { get; set; } = null!;
        public string PhonNumber { get; set; } = null!;
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; } = null!;

        [Display(Name = "تاریخ تولد ")]
        public DateTime? BrithDay { get; set; }
        [Display(Name = "تاریخ تولد ")]
        public string? BrithDatePersian { get; set; }
        [Display(Name = "تاریخ ثبت نام ")]

        public DateTime RigesterDate { get; set; }
        [Display(Name = "آخرین بازدید")]


        public DateTime? LastVisitDate { get; set; }
        [Display(Name = "فعال/غیرفعال ")]

        public bool IsActive { get; set; }
        [Display(Name = "تصویر پروفایل")]

        public string? ProfileImgUrl { get; set; }
        [Display(Name = "نقش ها")]

        public IEnumerable<string> Roles { get; set; }

        //تایید شمااره موبایل
        public bool PhonNumberConfirmed { get; set; }
        //تایید ایمیل
        public bool EmailConfirmed { get; set; }
        //تایید دو مرحله ای
        public bool TwoFactorEnabled { get; set; }
        //حساب کاربری قفل است یا نه
        public bool LockOutEnabled { get; set; }
        //تلاشهای ناموفق کاربر
        public int AccessFailedCount { get; set; }
        public DateTimeOffset? LockOutEnd { get; set; }
    }
}
