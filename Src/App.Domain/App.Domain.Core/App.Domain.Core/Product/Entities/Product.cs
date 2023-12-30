using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.User.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommentEntities = App.Domain.Core.Comment.Entities;
using StatusEntities = App.Domain.Core.BaseData.Entities;
using UserEntities = App.Domain.Core.User.Entities;

namespace App.Domain.Core.Product.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }

        public int BrandId { get; set; }

      

        public bool IsOrginal { get; set; }

        public string? Description { get; set; }
        public string ImageName { get; set; }

        public int? ModelId { get; set; }

        public int Count { get; set; }

        public decimal Price { get; set; }
    
        public bool IsShowPrice { get; set; }

        public bool IsActive { get; set; }
        public string OperatorInsert { get; set; }
        public string? OperatorEdit { get; set; }
        public string? OperatorRemove { get; set; }

        //TODO:
        public DateTime SubmitTime { get; set; }
        public DateTime? SubmitEditTime { get; set; }
        public DateTime? SubmitRemoveTime { get; set; }


        public int StatusId { get; set; }

        public virtual ICollection<ProductCollection> Collections { get; set; } = new List<ProductCollection>();

        public virtual ICollection<CommentEntities.Comment> Comments { get; set; } = new List<CommentEntities.Comment>();

        public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

        public virtual ICollection<OrderDetail>?OrderDetails { get; set; }
       
        public virtual Brand Brand { get; set; } = null!;

        public virtual Category Category { get; set; } = null!;
        public virtual StatusEntities.Status Status { get; set; } = null!;
        public virtual Model? Model { get; set; }
      
       



    }
}
