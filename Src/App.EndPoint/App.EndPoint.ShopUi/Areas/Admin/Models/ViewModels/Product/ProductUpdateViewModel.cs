using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.Product
{
    public class ProductUpdateViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public string Name { get; set; }
      
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public int CategoryId { get; set; }
    
       
        [Display(Name = "برند")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public int BrandId { get; set; }

        [Display(Name = "اصالت")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public bool IsOrginal { get; set; }

        [Display(Name = "توضیحات")]
        public string? Description { get; set; }

        [Display(Name = "مدل")]
        public int? ModelId { get; set; }

    
        [Display(Name = " موجودی")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public int Count { get; set; }
        [Display(Name = "قیمت")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public decimal Price { get; set; }
        [Display(Name = "نمایش قیمت")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public bool IsShowPrice { get; set; }
        [Display(Name = "قعال یاغیرفعال بودن")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public bool IsActive { get; set; }
   
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public int StatusId { get; set; }
      
        [Display(Name = "عکس محصول")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public IFormFile File { get; set; }
        public string? ImageName { get; set; }
        [Display(Name = "رنگ ها")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public List<int> Colors { get; set; } 


    }
}
