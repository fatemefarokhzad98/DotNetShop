using ProductEntity = App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using App.Domain.Core.Product.Entities;

namespace App.Domain.Core.BaseData.Entities;


public partial class Collection
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsDeleted { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? DeleteDate { get; set; }
    public virtual ICollection<ProductCollection> Products { get; set; } = new List<ProductCollection>();
}
