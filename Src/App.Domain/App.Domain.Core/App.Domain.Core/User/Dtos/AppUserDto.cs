using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.User.Dtos
{
    public class AppUserDto
    {
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
