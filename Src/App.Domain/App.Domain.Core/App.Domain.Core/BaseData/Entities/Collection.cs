using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities;


public partial class Collection
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }
    public virtual ICollection<CollectionProduct> CollectionProducts { get; set; } = new List<CollectionProduct>();
}
