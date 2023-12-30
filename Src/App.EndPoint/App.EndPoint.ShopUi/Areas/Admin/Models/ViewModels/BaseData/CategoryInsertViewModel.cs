using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.BaseData
{
    public class CategoryInsertViewModel
    {
      [Display(Name="دسته بندی" )]
      [Required(ErrorMessage="این فیلد اجباری است")]
        public string Name { get; set; }
        [Display(Name = "فعال یا فعال نبودن")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public bool IsActive { get; set; }
        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public int DisplayOrder { get; set; }
        [Display(Name = "دسته بندی اصلی")]
      
        public string? ParentName { get; set; }
        [Display(Name = "دسته بندی اصلی")]
   
        public int? ParentCategoryId { get; set; }



    }
}
