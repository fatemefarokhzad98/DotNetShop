using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class ColorReadViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "نام رنگ")]
        public string Name { get; set; }
        [Display(Name = "کدرنگ")]
        public string ColorCode { get; set; }
       

    }
}
