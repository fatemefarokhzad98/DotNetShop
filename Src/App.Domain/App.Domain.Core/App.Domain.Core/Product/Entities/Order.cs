using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Dtos;
using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Entities
{
    public partial class Order
    {

        public int Id { get; set; }

        public int TotalAmount { get; set; }

        public int SiteCommission { get; set; }

        public int BuyerId { get; set; }
        public int StatusId { get; set; }

        public bool IsFinal { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Status Status { get; set; } = null!;
        public virtual AppUser Buyer { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();






    }
}
