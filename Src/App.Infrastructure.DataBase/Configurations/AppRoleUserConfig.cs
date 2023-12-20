using App.Domain.Core.User.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.Configurations
{
    public class AppRoleUserConfig : IEntityTypeConfiguration<AppRoleUser>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AppRoleUser> builder)
        {
            builder.ToTable("ApplicationRoleUsers");
        }
    }
}
