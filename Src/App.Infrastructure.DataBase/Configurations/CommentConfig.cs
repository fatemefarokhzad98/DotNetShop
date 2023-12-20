using App.Domain.Core.Comment.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.Configurations
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(200);
            builder.Property(x => x.TextComment).HasMaxLength(1000);
            builder.HasMany(x => x.CommentImpressions)
                .WithOne(x => x.Comment)
                .HasForeignKey(x => x.CommentId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
