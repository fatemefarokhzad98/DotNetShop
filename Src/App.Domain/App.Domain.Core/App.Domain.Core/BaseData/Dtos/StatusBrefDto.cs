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
    public class StatusBrefDto
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public bool ForComment { get; set; }

        public bool ForUser { get; set; }

        public bool ForProduct { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<ProductBriefDto> Products { get; set; } = new List<ProductBriefDto>();

        public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
