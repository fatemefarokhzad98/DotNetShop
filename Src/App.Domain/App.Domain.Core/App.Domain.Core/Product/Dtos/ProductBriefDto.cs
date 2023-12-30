using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductBriefDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string CategoryName { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public bool IsOrginal { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public string ImageName { get; set; }
        public string StatusName  { get; set; }

        public bool IsDeleted { get; set; }
        public List<ColorDto> Colors { get; set; } = null!;









    }
}
