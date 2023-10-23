﻿using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.User
{
    public class RolesViewModel
    {
        [Display(Name = "شناسه نقش")]

        public int RoleId { get; set; }
        [Required]
        [Display ( Name = "نام نقش")]
        public string RoleName { get; set; }
        [Required]
        [Display(Name = "توضیحات نقش")]
        public string RoleDescription { get; set; }
      

    }
}
