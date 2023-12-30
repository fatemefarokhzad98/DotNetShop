using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class OrderForOrderDetailDto
    {
        public int Id { get; set; }

        public int TotalAmount { get; set; }

        public int SiteCommission { get; set; }

        public int BuyerId { get; set; }
        public string UserName { get; set; }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
       

        public bool IsFinal { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedAt { get; set; }
        public virtual ICollection<OrderDetailDto> OrderDetails { get; set; } = new List<OrderDetailDto>();

    }
}
