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
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.Property(e => e.ColorCode).HasMaxLength(100)
                .IsRequired();
            builder.Property(e => e.Name).HasMaxLength(150)
                .IsRequired();
            builder.HasMany(x => x.ProductColors)
                .WithOne(x => x.Color)
                .HasForeignKey(x => x.ColorId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }
}
