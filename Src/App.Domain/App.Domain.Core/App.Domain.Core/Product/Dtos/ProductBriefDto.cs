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

        public string CategoryName { get; set; }



        public bool IsOrginal { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

      
        public bool IsDeleted { get; set; }
        public List<ColorDto>? Colors { get; set; }
        public List<ProductFileDto>? Files { get; set; }






    }
}
