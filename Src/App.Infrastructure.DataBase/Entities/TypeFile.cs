using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class TypeFile
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ValidExtentions { get; set; }

    public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();
}
