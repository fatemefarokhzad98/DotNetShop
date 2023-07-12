using ProductEntities = App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.BaseData.Entities;

public partial class Model
{
    public int Id { get; set; }

    public int BrandId { get; set; }

    public int? ParentModelId { get; set; }
    public  Model ParentModel { get; set; }
    public bool IsDeleted { get; set; }


    public string Name { get; set; } = null!;

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<ProductEntities.Product> Products { get; set; } = new List<ProductEntities.Product>();
}
