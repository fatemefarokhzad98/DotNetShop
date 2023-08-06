using System.ComponentModel.DataAnnotations;

namespace App.EndPoint.ShopUi.Area.Admin.Models.ViewModels.Product
{
    public class ProductReadViewModel
    {
        public int Id { get; set; }
        [Display(Name = "نام محصول")]
        public string Name { get; set; }
        [Display(Name = "دسته بندی")]
        public int CategoryId { get; set; }
        [Display(Name = "دسته بندی")]
        public string CategoryName { get; set; }
        [Display(Name = "برند")]
        public int BrandId { get; set; }
        [Display(Name = "برند")]
        public string BrandName { get; set; }
        [Display(Name = "اصالت")]
        public bool IsOrginal { get; set; }
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
        [Display(Name = "وضعیت")]
        public int StatusId { get; set; }
        [Display(Name = "وضعیت")]
        public string StatusName { get; set; }
        [Display(Name = "حدف شده یانشده")]
        public bool IsActive { get; set; }
        [Display(Name = "اپراتورثبت کننده")]
        public int SubmitOperatorId { get; set; }
        [Display(Name = "اپراتورثبت کننده")]
        public string SubmitOperatorName { get; set; }
        [Display(Name = "تاریخ ثبت محصول")]
        public DateTime SubmitTime { get; set; }

    }

}
