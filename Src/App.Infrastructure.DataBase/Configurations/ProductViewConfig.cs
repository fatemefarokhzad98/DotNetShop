using  ProductEntity = App.Domain.Core.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.Configurations
{

    public class ProductViewConfig : IEntityTypeConfiguration<ProductEntity.ProductView>
    {
        public void Configure(EntityTypeBuilder<ProductEntity.ProductView> builder)
        {
           
        }
    }
}
