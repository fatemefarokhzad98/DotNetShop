using System;
using System.Collections.Generic;
using UserEntities = App.Domain.Core.User.Entities;

namespace App.Domain.Core.Product.Entities;
public partial class ProductView
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateTime ViewTime { get; set; }

    public int? ViewerUserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual UserEntities.AppUser? ViewerUser { get; set; }
}
