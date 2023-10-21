﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.Product.Dtos
{
    public class ProductFileDto
    {

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int FileTypeId { get; set; }

        public int ProductId { get; set; }

        public DateTime CreationDate { get; set; }
        public bool IsDeleted { get; set; }
    

    }
}
