using System;
using System.Collections.Generic;
using USerEntities = App.Domain.Core.User.Entities;

namespace App.Domain.Core.Comment.Entities;

public partial class CommentImpression
{
    public int Id { get; set; }

    public int CommentId { get; set; }

    public int ImpressionTypeId { get; set; }

    public int SubmmitUserId { get; set; }

    public DateTime ImpressionTime { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    public virtual ImpressionType ImpressionType { get; set; } = null!;

    public virtual USerEntities.AppUser SubmmitUser { get; set; } = null!;
}
