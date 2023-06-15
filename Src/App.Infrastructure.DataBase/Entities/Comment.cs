using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class Comment
{
    public int Id { get; set; }

    public string? TextComment { get; set; }

    public string? Title { get; set; }

    public int ProductId { get; set; }

    public DateTime CommentTime { get; set; }

    public int StatusId { get; set; }

    public int SubmitUserId { get; set; }

    public int? ParentCommentId { get; set; }

    public DateTime? LastEditTimeStatus { get; set; }

    public int? Rate { get; set; }

    public virtual ICollection<CommentImpression> CommentImpressions { get; set; } = new List<CommentImpression>();

    public virtual Product Product { get; set; } = null!;

    public virtual Status Status { get; set; } = null!;

    public virtual User SubmitUser { get; set; } = null!;
}
