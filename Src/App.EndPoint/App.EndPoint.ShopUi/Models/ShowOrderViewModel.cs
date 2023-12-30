namespace App.EndPoint.ShopUi.Models
{
    public class ShowOrderViewModel
    {
        public int OrderDtailID { get; set; }
        public string ProductName { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int TotalAmount { get; set; }

        public int SiteCommission { get; set; }
    }
}
