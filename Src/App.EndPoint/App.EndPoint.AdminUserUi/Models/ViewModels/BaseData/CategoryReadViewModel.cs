using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CategoryReadViewModel
    {

        public int Id { get; set; }

        [Display(Name = "دسته بندی")]
        public string Name { get; set; }

        [Display(Name = "دسته بندی اصلی")]
        public string? ParentName { get; set; }

        [Display(Name = "ترتیب نمایش")]
        public int DisplayOrder { get; set; }
        [Display(Name = "فعال یا فعال نبودن")]
        public bool IsActive { get; set; }


    }
}
