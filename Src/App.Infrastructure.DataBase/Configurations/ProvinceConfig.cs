using App.Domain.Core.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.Configurations
{
    public class ProvinceConfig : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(150)
                .IsRequired();
            builder.HasMany(x => x.Cities)
                .WithOne(x => x.Province)
                .HasForeignKey(x => x.ProvinceId)
                .HasPrincipalKey(x => x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);
        }
    }
}
