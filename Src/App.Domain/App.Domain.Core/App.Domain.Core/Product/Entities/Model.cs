using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities;

public partial class Model
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public int ParentModelId { get; set; }

    public string Name { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
