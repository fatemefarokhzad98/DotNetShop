using App.Domain.Core.Comment.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataBase.Configurations
{
    public class CommentImpressionConfig : IEntityTypeConfiguration<CommentImpression>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CommentImpression> builder)
        {
           



        }
    }
}
