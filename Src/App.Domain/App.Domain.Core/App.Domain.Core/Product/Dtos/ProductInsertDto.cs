using App.Domain.Core.BaseData.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductInsertDto
    {
        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }

        public int BrandId { get; set; }
        public int StatusId { get; set; }


        public bool IsOrginal { get; set; }

        public string? Description { get; set; }
        public string SubmitOperatorName { get; set; }
       

        public int? ModelId { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public bool IsShowPrice { get; set; }
        public string ImageName { get; set; } 

        public bool IsActive { get; set; }
        //TODO:
        public DateTime SubmitTime { get; set; }
        public List<ColorDto> Colors { get; set; } = null!;
       
    }
}
