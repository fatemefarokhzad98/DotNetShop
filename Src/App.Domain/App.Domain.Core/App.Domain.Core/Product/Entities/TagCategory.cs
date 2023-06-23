﻿using System;
using System.Collections.Generic;

namespace App.Domain.Core.Product.Entities;

public partial class TagCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
