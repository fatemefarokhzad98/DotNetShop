using App.Domain.Core.BaseData.Entities;
using App.Domain.Core.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.Configurations
{
    public class CollectionConfig : IEntityTypeConfiguration<Collection>
    {
        public void Configure(EntityTypeBuilder<Collection> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(150);
            builder.Property(x => x.Name).IsRequired();
            builder.HasMany(x => x.Products)
                .WithOne(x => x.Collection)
                .HasForeignKey(x => x.CollectionId)
                .HasPrincipalKey(x => x.Id);
                
            

        }
    }
}
