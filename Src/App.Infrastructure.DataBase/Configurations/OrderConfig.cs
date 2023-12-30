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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
         
            builder.HasMany(x => x.OrderDetails)
                .WithOne(x=>x.Order)
                .HasForeignKey(x=>x.OrderId)
                .HasPrincipalKey(x=>x.Id)
                .OnDelete(DeleteBehavior.ClientCascade);



         
        }
    }
}
