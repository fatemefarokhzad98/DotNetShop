﻿using App.Domain.Core.BaseData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Dtos
{
    public class ModelDto
    {
        public int Id { get; set; }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
         
        public int? ParentModelId { get; set; }
        public string ParentName { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; } = null!;

       
    }
}
