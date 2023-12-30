using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductInBasketDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }
        public string ImageName { get; set; }

    }
}
