using System.ComponentModel.DataAnnotations;
namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class ColorInsertViewModel
    {
        [Display(Name="کدرنگ")]
        [Required(ErrorMessage ="تکمیل این فیلد اجباری است")]
        public string ColorCode { get; set; }
        [Display(Name="نام رنگ")]
        [Required(ErrorMessage = "تکمیل این فیلد اجباری است")]
        public string Name { get; set; }

    }
}
