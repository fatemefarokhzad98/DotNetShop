using System;
using System.Collections.Generic;
using ProductEntities = App.Domain.Core.Product.Entities;

namespace App.Domain.Core.BaseData.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentCategoryId { get; set; }

    public Category? ParentCategory { get; set; }
    public bool IsActive { get; set; }

    public int DisplayOrder { get; set; }
    public bool IsDeleted { get; set; }

    public virtual ICollection<ProductEntities.Product> Products { get; set; } = new List<ProductEntities.Product>();
}
