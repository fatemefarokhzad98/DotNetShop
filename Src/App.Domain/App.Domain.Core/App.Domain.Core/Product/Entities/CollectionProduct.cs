﻿using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class CollectionProduct
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int CollectionId { get; set; }

    public virtual Collection Collection { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}