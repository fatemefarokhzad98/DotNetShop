using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.User
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name = "نام نقش")]
        public string RoleName { get; set; } = null!;
        [Required]
        [Display(Name = "توضیحات نقش")]
        public string RoleDescription { get; set; } = null!;
    }
}
