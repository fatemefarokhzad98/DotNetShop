using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class ProductView
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public DateTime ViewTime { get; set; }

    public int? ViewerUserId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual User? ViewerUser { get; set; }
}
