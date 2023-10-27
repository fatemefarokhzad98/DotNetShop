using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace App.Domain.Core.User.Entities;

public partial class Role
{
    public int Id { get; set; } 


    public string Description { get; set; } = null!;
    public string Name { get; set; } = null!;
   

    public virtual ICollection<Customers> Users { get; set; } = new List<Customers>();
}
