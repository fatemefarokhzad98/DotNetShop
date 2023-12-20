using App.Domain.Core.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.Configurations
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(300)
                 .IsRequired();
            builder.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.HasMany(x => x.Collections)
                .WithMany(x => x.Products)
                .UsingEntity("ProductCollections");
            builder.HasMany(x => x.Comments)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x=>x.ProductColors)
                 .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x=>x.ProductFiles)
                 .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(x=>x.ProductTags)
                 .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull); 
            builder.HasMany(x=>x.ProductViews)
                 .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull);


            builder.HasMany(x => x.Orders)
                .WithOne(x=>x.Product)
                .HasForeignKey(x=>x.PrductId)
                .HasPrincipalKey(x=>x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);


        }

    }
}
