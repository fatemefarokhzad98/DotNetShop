using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class ModelUpdateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام برند")]
        [Required(ErrorMessage = "تکمیل این فیلد اجباری است")]
        public int BrandId { get; set; }
        [Display(Name = "نام برند")]
        [Required(ErrorMessage = "تکمیل این فیلد اجباری است")]
        public string BrandName { get; set; }
        [Display(Name = "نام مدل اصلی")]
        public int? ParentModelId { get; set; }
        [Display(Name = "نام مدل اصلی")]
        public string ParentName { get; set; }
        [Display(Name = "نام مدل ")]
        public string Name { get; set; }
    }
}
