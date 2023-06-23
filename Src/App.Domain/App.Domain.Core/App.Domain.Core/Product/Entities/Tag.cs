using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class Tag
{
    public int Id { get; set; }

    public int TagCategoryId { get; set; }

    public string Name { get; set; } = null!;

    public bool HasValue { get; set; }

    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

    public virtual TagCategory TagCategory { get; set; } = null!;
}
