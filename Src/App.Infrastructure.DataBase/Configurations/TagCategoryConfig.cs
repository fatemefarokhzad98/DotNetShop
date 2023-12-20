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
    public class TagCategoryConfig : IEntityTypeConfiguration<TagCategory>
    {
        public void Configure(EntityTypeBuilder<TagCategory> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(200)
                 .IsRequired();
            builder.HasMany(x => x.Tags)
                .WithOne(x => x.TagCategory)
                .HasForeignKey(x => x.TagCategoryId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);
            
        }
    }
}
