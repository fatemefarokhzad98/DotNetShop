using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class Brand
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
