using App.Domain.Core.Comment.Entities;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using ProductEntities = App.Domain.Core.Product.Entities;
using StatusEnities = App.Domain.Core.BaseData.Entities;
using CommentEntities = App.Domain.Core.Comment.Entities;
namespace App.Domain.Core.User.Entities;

public partial class Customers
{

    public int Id { get; set; }
    public Cities City1 { get; set; } = null!;
    public Cities?City2 { get; set; }
    public string Adress1 { get; set; } = null!;
    public string? Adress2 { get; set; }
    public int StatusId { get; set; }


    public virtual ICollection<CommentImpression> CommentImpressions { get; set; } = new List<CommentImpression>();

    public virtual ICollection<CommentEntities.Comment> Comments { get; set; } = new List<CommentEntities.Comment>();

    public virtual ICollection<ProductView> ProductViews { get; set; } = new List<ProductView>();

    public virtual ICollection<ProductEntities.Product> Products { get; set; } = new List<ProductEntities.Product>();

    public virtual StatusEnities.Status Status { get; set; } = null!;
}
