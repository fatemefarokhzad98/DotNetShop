using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CollectionUpdateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام مجموعه")]
        [Required(ErrorMessage = "تکمیل این فیلد اجباری است")]
        public string Name { get; set; }
       



    }
}
