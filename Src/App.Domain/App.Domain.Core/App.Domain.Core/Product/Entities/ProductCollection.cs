using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Entities
{
    public partial class ProductCollection
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CollectionId { get; set; }
        public virtual Collection Collection { get; set; } 
        public virtual Product Product { get; set; }



    }
}
