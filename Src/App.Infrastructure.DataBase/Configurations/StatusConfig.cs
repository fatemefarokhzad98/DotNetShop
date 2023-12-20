using App.Domain.Core.BaseData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.Configurations
{
    public class StatusConfig : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.Property(x => x.Title).HasMaxLength(500)
                .IsRequired();
            builder.HasMany(x => x.Products)
                .WithOne(x => x.Status)
                .HasForeignKey(x => x.StatusId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Status)
                .HasForeignKey(x => x.StatusId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);


            builder.HasMany(x => x.Users)
                 .WithOne(x => x.Status)
                .HasForeignKey(x => x.StatusId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Status)
                .HasForeignKey(x => x.StatusId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
