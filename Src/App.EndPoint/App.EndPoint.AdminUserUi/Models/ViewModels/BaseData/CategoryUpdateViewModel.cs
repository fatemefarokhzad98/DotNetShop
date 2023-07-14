using App.Domain.Core.BaseData.Dtos;
using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CategoryUpdateViewModel
    {

       
        public int Id { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string Name { get; set; }
        [Display(Name = "فعال یا فعال نبودن")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public bool IsActive { get; set; }
        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public int DisplayOrder { get; set; }
        [Display(Name = "دسته بندی اصلی")]
       
        public int? ParentCategoryId { get; set; }
        [Display(Name = "دسته بندی اصلی")]
       
        public string? ParentName { get; set; }

    }
}
