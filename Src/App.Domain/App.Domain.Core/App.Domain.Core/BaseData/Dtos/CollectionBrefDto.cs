using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Dtos
{
    public class CollectionBrefDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsDeleted { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public virtual ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();

    }
}
