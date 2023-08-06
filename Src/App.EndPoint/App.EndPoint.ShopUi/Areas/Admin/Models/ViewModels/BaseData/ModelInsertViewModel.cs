using System.ComponentModel.DataAnnotations;
namespace App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.BaseData
{
    public class ModelInsertViewModel
    {
        [Display(Name="نام برند")]
        [Required(ErrorMessage ="تکمیل این فیلد اجباری است")]
      
        public int BrandId { get; set; }
        [Display(Name = "نام برند")]
        [Required(ErrorMessage = "تکمیل این فیلد اجباری است")]

        public string BrandName { get; set; }
        [Display(Name="نام مدل اصلی")]

        public int? ParentModelId { get; set; }
        [Display(Name = "نام مدل اصلی")]
        public string ParentName { get; set; }

        [Display(Name = "نام مدل")]
        [Required(ErrorMessage = "تکمیل این فیلد اجباری است")]
        public string Name { get; set; } 
    }
}
