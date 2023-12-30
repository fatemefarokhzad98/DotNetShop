using App.Domain.Core.BaseData.Dtos;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }

        public bool IsOrginal { get; set; }

        public string? Description { get; set; }

        public int? ModelId { get; set; }
        public string? ModelName { get; set; }
        public string ImangeName { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }

        public bool IsShowPrice { get; set; }

        public bool IsActive { get; set; }
       
        public DateTime SubmitTime { get; set; }
        public DateTime? SubmitEditTime { get; set; }
        public DateTime? SubmitRemoveTime { get; set; }

        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string? EditUserName { get; set; }


        public bool IsDeleted { get; set; }
        public List<ColorDto> Colors { get; set; } = null!;


    }
}
