using System;
using System.Collections.Generic;

namespace App.Domain.Core.Comment.Entities;

public partial class ImpressionType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<CommentImpression> CommentImpressions { get; set; } = new List<CommentImpression>();
}
