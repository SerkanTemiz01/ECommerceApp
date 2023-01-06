using ECommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infastructure.EntityTypeConfiguration
{
    public class CategoryConfig :BaseEntityConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.ID);

            builder.HasMany(x => x.Products)
                .WithMany(x => x.Categories);
            base.Configure(builder);
        }
    }
}
