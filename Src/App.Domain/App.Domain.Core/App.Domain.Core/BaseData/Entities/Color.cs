﻿using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class Color
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string ColorCode { get; set; } = null!;

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
}