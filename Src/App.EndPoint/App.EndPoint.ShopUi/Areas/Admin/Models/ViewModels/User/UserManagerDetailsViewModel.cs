using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.User
{
    public class UserManagerDetailsViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام")]
        public string FirstName { get; set; } = null!;
        [Display(Name = "ایمیل")]
        public string Email { get; set; }
        [Display(Name = " نام کاربری")]
        public string UserName { get; set; } = null!;
        public string PhonNumber { get; set; } = null!;
        [Display(Name = "نام خانوادگی")]
        public string LastName { get; set; } = null!;
        [Display(Name = "تاریخ تولد ")]
        public string BrithDatePersian { get; set; }
        [Display(Name = "تاریخ تولد ")]
        public DateTime? BrithDay { get; set; }
        public string? ProfileImgUrl { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
