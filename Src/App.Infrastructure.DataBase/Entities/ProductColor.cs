﻿using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class ProductColor
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int ColorId { get; set; }

    public bool Isexit { get; set; }

    public virtual Color Color { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
