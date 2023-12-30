using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductCollectionDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CollectionId { get; set; }
    }
}
