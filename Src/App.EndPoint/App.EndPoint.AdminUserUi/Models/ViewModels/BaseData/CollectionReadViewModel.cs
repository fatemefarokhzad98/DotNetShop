using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.AdminUserUi.Models.ViewModels.BaseData
{
    public class CollectionReadViewModel
    {
        public int Id { get; set; }
        [Display(Name = "تاریخ ایجاد ")]
        public DateTime CreationDate { get; set; }
        [Display(Name = "نام مجموعه")]
       
        public string Name { get; set; }


    }
}
