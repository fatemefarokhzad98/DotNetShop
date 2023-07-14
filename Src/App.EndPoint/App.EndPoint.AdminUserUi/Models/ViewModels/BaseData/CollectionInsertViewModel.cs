using System.ComponentModel.DataAnnotations;
namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CollectionInsertViewModel
    {
      
        [Display(Name="نام مجموعه")]
        [Required(ErrorMessage ="تکمیل این فیلد اجباری است")]
        
        public string Name { get; set; }
      
    }
}
