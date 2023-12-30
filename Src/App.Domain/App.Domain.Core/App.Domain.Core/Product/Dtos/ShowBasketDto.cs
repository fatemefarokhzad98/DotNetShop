﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ShowBasketDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string  ProductName { get; set; }
        public string  ImageName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
    }
}
