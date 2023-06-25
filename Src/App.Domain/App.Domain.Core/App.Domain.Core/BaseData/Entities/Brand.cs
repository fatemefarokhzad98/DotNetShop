using App.Domain.Core.Product.Entities;
using ProductEntities = App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData.Entities;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();

    public virtual ICollection<ProductEntities.Product> Products { get; set; } = new List<ProductEntities.Product>();
}
