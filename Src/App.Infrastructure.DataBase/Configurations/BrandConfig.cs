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
    public class BrandConfig : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
           
           builder.HasKey(e => e.Id).HasName("PK__Brands__3214EC07D5C50981");
            builder.Property(x=>x.Name).HasMaxLength(150);
            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(x => x.Models)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Brand)
                .HasForeignKey(x => x.BrandId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull);




        }
    }
}
