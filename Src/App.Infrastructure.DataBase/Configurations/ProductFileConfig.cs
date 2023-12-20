using ProductEntity= App.Domain.Core.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.Configurations
{
    public class ProductFileConfig : IEntityTypeConfiguration<ProductEntity.ProductFile>
    {
        public void Configure(EntityTypeBuilder<ProductEntity.ProductFile> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150)
                .IsRequired();
            
        }
    }
}
