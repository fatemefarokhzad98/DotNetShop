using ProductEntity = App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;


namespace App.Domain.Core.BaseData.Entities;


public partial class Collection
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }
    public DateTime CreationDate { get; set; }
    public virtual ICollection<ProductEntity.Product> Products { get; set; } = new List<ProductEntity.Product>();
}
