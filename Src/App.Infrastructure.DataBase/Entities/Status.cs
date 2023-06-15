using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class Status
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public bool ForComment { get; set; }

    public bool ForUser { get; set; }

    public bool ForProduct { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
