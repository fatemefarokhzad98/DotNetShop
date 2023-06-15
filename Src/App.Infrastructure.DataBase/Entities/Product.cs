﻿using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int CategoryId { get; set; }

    public int BrandId { get; set; }

    public bool IsOrginal { get; set; }

    public string? Description { get; set; }

    public int? ModelId { get; set; }

    public int Count { get; set; }

    public decimal Price { get; set; }

    public bool IsShowPrice { get; set; }

    public bool IsActive { get; set; }

    public DateTime SubmitTime { get; set; }

    public int StatusId { get; set; }

    public int SubmitOperatorId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<CollectionProduct> CollectionProducts { get; set; } = new List<CollectionProduct>();

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Model? Model { get; set; }

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

    public virtual ICollection<ProductFile> ProductFiles { get; set; } = new List<ProductFile>();

    public virtual ICollection<ProductTag> ProductTags { get; set; } = new List<ProductTag>();

    public virtual ICollection<ProductView> ProductViews { get; set; } = new List<ProductView>();

    public virtual Status Status { get; set; } = null!;

    public virtual User SubmitOperator { get; set; } = null!;
}
