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
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("ApplicationUser");
            builder.Property(x => x.FirstName).HasMaxLength(200)
                .IsRequired();
            builder.Property(x => x.LastName).HasMaxLength(200)
                .IsRequired();
           
            builder.HasMany(x => x.Roles)
                .WithOne(x => x.User)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasMany(x => x.Comments)
                .WithOne(x => x.SubmitUser)
                .HasForeignKey(x => x.SubmitUserId)
                .HasPrincipalKey(x => x.Id)
                 .OnDelete(DeleteBehavior.ClientSetNull); 
        




        }
    }
}
