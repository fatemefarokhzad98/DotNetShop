namespace App.EndPoint.AdminUserUi.Models.ViewModels.Product
{
    public class ProductUpdateViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public bool IsOrginal { get; set; }

        public string? Description { get; set; }

        public int? ModelId { get; set; }
        public string ModelName { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public bool IsShowPrice { get; set; }

        public bool IsActive { get; set; }

        public DateTime SubmitTime { get; set; }

        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public int SubmitOperatorId { get; set; }
        public string SubmitOperatorName { get; set; }
        public bool IsDeleted { get; set; }

    }
}
