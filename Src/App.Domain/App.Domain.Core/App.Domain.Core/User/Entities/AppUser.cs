using App.Domain.Core.BaseData.Entities;
using ProductEntity= App.Domain.Core.Product.Entities;
using CommentEntity= App.Domain.Core.Comment.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.User.Entities
{
    public class AppUser:IdentityUser<int>
    {

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime BrithDay { get; set; }
        public DateTime RigesterDate { get; set; }
        public DateTime LastVisitDate { get; set; }
        public bool IsActive { get; set; }
        public string? Image { get; set; }
        public int StatusId { get; set; }


        public virtual ICollection< AppRoleUser> Roles { get; set; } = null!;
        public virtual ICollection<ProductEntity.ProductView>? ProductViews { get; set; }
        public virtual Status Status { get; set; } = null!;
        public virtual ICollection< CommentEntity.Comment>? Comments { get; set; }
      
        public virtual ICollection<Order>? Order  { get; set; } 
 


    }
}
