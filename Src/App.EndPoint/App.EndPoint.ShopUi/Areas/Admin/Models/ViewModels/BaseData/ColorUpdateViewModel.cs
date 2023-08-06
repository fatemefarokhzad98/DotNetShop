using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.BaseData
{
    public class ColorUpdateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام رنگ")]
        [Required(ErrorMessage = "تکمیل این فیلد اجباری است")]
        public string Name { get; set; }
        [Display(Name = "کدرنگ")]
        [Required(ErrorMessage = "تکمیل این فیلد اجباری است")]
        public string ColorCode { get; set; }
       
    }
}
