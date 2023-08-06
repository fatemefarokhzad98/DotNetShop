using System.ComponentModel.DataAnnotations;
namespace App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.Product
{
    public class ProductInsertViewModel
    {

        [Display(Name="نام محصول")]
        [Required(ErrorMessage =" تکمیل این فیلد اجباری است")]
        public string Name { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public int CategoryId { get; set; }
        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public string CategoryName { get; set; }
        [Display(Name = "برند")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public int BrandId { get; set; }
        [Display(Name = "برند")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public string BrandName { get; set; }
        [Display(Name = "اصالت")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]
        public bool IsOrginal { get; set; }
        [Display(Name = "توضیحات")]
        public string? Description { get; set; }
        [Display(Name = "مدل")]
        public int? ModelId { get; set; }
        [Display(Name = "مدل")]
        public string ModelName { get; set; }
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
        [Display(Name = "تاریخ ثبت محصول")]
        public DateTime SubmitTime { get; set; }

        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]

        public int StatusId { get; set; }
        [Display(Name = "وضعیت")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]

        public string StatusName { get; set; }
        [Display(Name = "اپراتورثبت کننده")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]

        public int SubmitOperatorId { get; set; }
        [Display(Name = "اپراتورثبت کننده")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]

        public string SubmitOperatorName { get; set; }
        [Display(Name = "حدف شده یانشده")]
        [Required(ErrorMessage = " تکمیل این فیلد اجباری است")]

        public bool IsDeleted { get; set; }



    }
}
