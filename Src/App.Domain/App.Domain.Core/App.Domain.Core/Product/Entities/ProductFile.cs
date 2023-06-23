﻿using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class ProductFile
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int FileTypeId { get; set; }

    public int ProductId { get; set; }

    public virtual TypeFile FileType { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}