using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class BrandUpdateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام برند")]
        [Required(ErrorMessage = "این فیلد اجباری است")]
        public string  Name { get; set; }
        [Display(Name = "ترتیب نمایش")]
        [Required(ErrorMessage = "این فیلد اجباری است")]

        public int DisPlayOrder { get; set; }
       


    }
}
