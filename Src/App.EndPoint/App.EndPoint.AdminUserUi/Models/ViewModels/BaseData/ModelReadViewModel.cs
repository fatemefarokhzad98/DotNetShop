using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class ModelReadViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام مدل اصلی")]
        public int? ParentModelId { get; set; }
        [Display(Name = "نام مدل اصلی")]
        public string ParentName { get; set; }
        [Display(Name = "نام برند")]
        public int BrandId { get; set; }
        [Display(Name = "نام برند")]
        public string BrandName { get; set; }
        [Display(Name = "نام مدل")]
        public string Name { get; set; }



    }
}
