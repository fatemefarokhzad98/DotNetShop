using App.Domain.Core.Comment.Entities;
using App.Domain.Core.Product.Entities;
using System;
using System.Collections.Generic;
using ProductEntities = App.Domain.Core.Product.Entities;
using StatusEnities = App.Domain.Core.BaseData.Entities;
using CommentEntities = App.Domain.Core.Comment.Entities;
namespace App.Domain.Core.User.Entities;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string PassWord { get; set; } = null!;

    public string? Mobile { get; set; }

    public string? Email { get; set; }

    public DateTime? BrithDay { get; set; }

    public bool? IsMobileVerified { get; set; }

    public bool? IsEmailVerified { get; set; }

    public DateTime SubmitTime { get; set; }

    public int RoleId { get; set; }

    public int StatusId { get; set; }

    public virtual ICollection<CommentImpression> CommentImpressions { get; set; } = new List<CommentImpression>();

    public virtual ICollection<CommentEntities.Comment> Comments { get; set; } = new List<CommentEntities.Comment>();

    public virtual ICollection<ProductView> ProductViews { get; set; } = new List<ProductView>();

    public virtual ICollection<ProductEntities.Product> Products { get; set; } = new List<ProductEntities.Product>();

    public virtual Role Role { get; set; } = null!;

    public virtual StatusEnities.Status Status { get; set; } = null!;
}
