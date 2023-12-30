using App.Domain.Core.Product.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Dtos
{
    public class ModelBrefDto
    {
        public int Id { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public int? ParentModelId { get; set; }
        public string ParentName { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; } = null!;
        public virtual ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}
