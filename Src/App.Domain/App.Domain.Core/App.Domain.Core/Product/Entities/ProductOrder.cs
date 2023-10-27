using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Entities
{
    public partial class ProductOrder
    {
        public int Id { get; set; }
        public int PrductId { get; set; }
        public int OrderId { get; set; }


        public virtual Product Product { get; set; } = null!;
        public virtual Orders Order { get; set; } = null!;
    }
}
