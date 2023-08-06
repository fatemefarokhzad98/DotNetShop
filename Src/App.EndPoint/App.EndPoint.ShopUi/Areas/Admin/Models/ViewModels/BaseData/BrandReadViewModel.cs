using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.BaseData
{
    public class BrandReadViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام برند")]
      
        public string  Name { get; set; }
        [Display(Name = "ترتیب نمایش")]
       
        public int DisplayOrder { get; set; }
        [Display(Name = " تاریخ ایجاد")]
        public DateTime CreationDate { get; set; }

    }
}
