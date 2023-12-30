namespace App.EndPoint.ShopUi.Models
{
    public class ShowCartViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
