﻿using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? ParentCategoryId { get; set; }

    public bool IsActive { get; set; }

    public int DisplayOrder { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}