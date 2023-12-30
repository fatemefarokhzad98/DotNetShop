using App.Domain.Core.Product.Dtos;

namespace App.EndPoint.ShopUi.Models
{
    public class ProfileUserReadViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Mobile { get; set; } = null!;

        public string Address { get; set; } = null!;
        public string? Address2 { get; set; }


        public string? ProfileImgUrl { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<OrderDto> Orders { get; set; }
    }
}
