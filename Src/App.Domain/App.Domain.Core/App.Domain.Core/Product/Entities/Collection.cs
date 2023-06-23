using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class Collection
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CollectionProduct> CollectionProducts { get; set; } = new List<CollectionProduct>();
}
