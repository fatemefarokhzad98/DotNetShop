using System;
using System.Collections.Generic;
using ColorEntities = App.Domain.Core.BaseData.Entities;

namespace App.Domain.Core.Product.Entities;

public partial class ProductColor
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ColorId { get; set; }

    public bool IsExit { get; set; }

    public virtual ColorEntities.Color Color { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
