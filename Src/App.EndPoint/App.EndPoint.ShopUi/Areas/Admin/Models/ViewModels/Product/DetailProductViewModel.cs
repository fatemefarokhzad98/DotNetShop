using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Areas.Admin.Models.ViewModels.Product
{
    public class DetailProductViewModel
    {

        public int Id { get; set; }
        [Display(Name = "نام محصول")]
        public string Name { get; set; }
        [Display(Name = "تاریخ ثبت محصول")]
        public DateTime SubmitTime { get; set; }
      
        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }
        [Display(Name = "دسته بندی")]
        public string CategoryName { get; set; }
        [Display(Name = "برند")]
        public int BrandId { get; set; }
        [Display(Name = "برند")]
        public string BrandName { get; set; }
     
        [Display(Name = "مدل")]
        public int? ModelId { get; set; }
        [Display(Name = "مدل")]
        public string ModelName { get; set; }
        [Display(Name = " موجودی")]
        public int Count { get; set; }
        [Display(Name = "قیمت")]
        public decimal Price { get; set; }
        [Display(Name = "توضیحات")]

        public string? Description { get; set; }
        public string operatornameinsert { get; set; }

        
       
   
        [Display(Name = "عکس محصول")]
        public string UerlImage { get; set; }
        [Display(Name = "رنگ محصول")]
     
        public List<int> Colors { get; set; }
    }
}
