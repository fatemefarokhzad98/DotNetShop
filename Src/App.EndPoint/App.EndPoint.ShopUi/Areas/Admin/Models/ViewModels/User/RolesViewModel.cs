using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.User
{
    public class RolesViewModel
    {
        [Display(Name = "شناسه نقش")]

        public int RoleId { get; set; }
        [Required]
        [Display ( Name = "نام نقش")]
        public string RoleName { get; set; } = null!;
        [Required]
        [Display(Name = "توضیحات نقش")]
        public string RoleDescription { get; set; } = null!;
        [Display(Name = "تعداد کاربران")]
        public  int CountUser { get; set; }
        public string? RecentRoleName { get; set; }


    }
}
