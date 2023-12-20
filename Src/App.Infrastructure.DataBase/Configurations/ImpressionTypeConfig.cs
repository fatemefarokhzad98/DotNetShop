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
    public class ImpressionTypeConfig : IEntityTypeConfiguration<ImpressionType>
    {
        public void Configure(EntityTypeBuilder<ImpressionType> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(200)
               .IsRequired();
            builder.HasMany(x => x.CommentImpressions)
                 .WithOne(x => x.ImpressionType)
                 .HasForeignKey(x => x.ImpressionTypeId)
                 .HasPrincipalKey(x => x.Id)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
