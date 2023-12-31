namespace App.EndPoint.ShopUi.Models
{
    public class ShowOrderViewModel
    {

        public int OrderDetailId { get; set;}
        public string ImageName { get; set;}
        public string ProductName { get; set;}
        public int Count { get; set;}
        public decimal Price { get; set; }
        public int Sum { get; set; }
        public int  SiteComision { get; set; }

    }
}
