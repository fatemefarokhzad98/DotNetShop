using System;
using System.Collections.Generic;

namespace App.Infrastructure.DataBase.Entities;

public partial class CommentImpression
{
    public int Id { get; set; }

    public int CommentId { get; set; }

    public int ImpressionTypeId { get; set; }

    public int SubmmitUserId { get; set; }

    public DateTime ImpressionTime { get; set; }

    public virtual Comment Comment { get; set; } = null!;

    public virtual ImpressionType ImpressionType { get; set; } = null!;

    public virtual User SubmmitUser { get; set; } = null!;
}
