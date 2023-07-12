using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class BrandUpdateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام برند")]
        public string  Name { get; set; }
        [Display(Name = "ترتیب نمایش")]

        public int DisPlayOrder { get; set; }
       


    }
}
