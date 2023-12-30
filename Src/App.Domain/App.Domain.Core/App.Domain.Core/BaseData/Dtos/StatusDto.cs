using App.Domain.Core.Product.Dtos;
using App.Domain.Core.Product.Entities;
using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Core.BaseData.Dtos
{
    public class StatusDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool ForComment { get; set; }

        public bool ForOrder { get; set; }

        public bool ForProduct { get; set; }
        public bool IsDeleted { get; set; }
    
    }
}
