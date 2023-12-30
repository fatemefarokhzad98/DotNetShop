using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Entities
{
    public partial class ProductColor
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public int ProductId { get; set; }
        public virtual Color Color { get; set; }
        public virtual Product Product { get; set; }
    }
}
