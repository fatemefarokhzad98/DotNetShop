using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.BaseData
{
    public class StatusCreateViewModel
    {
        [Required(ErrorMessage ="این فیلد اجباری است")]
        [Display(Name ="متن وضعیت")]
        
        public string Title { get; set; } = null!;
        [Display(Name ="برای کامنت هااست")]
        public bool ForComment { get; set; }
        [Display(Name = "برای سفارشات است")]
        public bool ForOrder  { get; set; }
        [Display(Name = "برای محصولات است")]
        public bool ForProduct { get; set; }

    }
}
