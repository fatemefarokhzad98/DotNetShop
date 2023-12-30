using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class OrderShowForBasketDto
    {
        public int OrderDtailID { get; set; }
        public string ProductName { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public int TotalAmount { get; set; }

        public int SiteCommission { get; set; }
    }
}
