using ECommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infastructure.EntityTypeConfiguration
{
    public class MallConfig:BaseEntityConfig<Mall>
    {
        public override void Configure(EntityTypeBuilder<Mall> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).IsRequired(true);
            base.Configure(builder);
        }
    }
}
