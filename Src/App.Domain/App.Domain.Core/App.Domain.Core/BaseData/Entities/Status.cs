using System;
using System.Collections.Generic;
using CommnetEntities = App.Domain.Core.Comment.Entities;
using ProductEntities = App.Domain.Core.Product.Entities;
using UserEntities = App.Domain.Core.User.Entities;

namespace App.Domain.Core.BaseData.Entities;

public partial class Status
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool ForComment { get; set; }

    public bool ForUser { get; set; }

    public bool ForProduct { get; set; }

    public virtual ICollection<CommnetEntities.Comment> Comments { get; set; } = new List<CommnetEntities.Comment>();

    public virtual ICollection<ProductEntities.Product> Products { get; set; } = new List<ProductEntities.Product>();

    public virtual ICollection<UserEntities.User> Users { get; set; } = new List<UserEntities.User>();
}
