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
    public class TypeFileConfig : IEntityTypeConfiguration<TypeFile>
    {
        public void Configure(EntityTypeBuilder<TypeFile> builder)
        {
            builder.Property(e => e.Name).HasMaxLength(150);
            builder.Property(e => e.ValidExtentions).HasMaxLength(150);
            builder.HasMany(x => x.ProductFiles)
                .WithOne(x => x.FileType)
                .HasForeignKey(x => x.FileTypeId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
