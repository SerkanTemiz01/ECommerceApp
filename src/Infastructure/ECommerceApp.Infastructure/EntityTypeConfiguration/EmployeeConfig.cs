﻿using ECommerceApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Infastructure.EntityTypeConfiguration
{
    public class EmployeeConfig:BaseEntityConfig<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x=>x.ID).IsRequired(true);

            builder.HasOne(x => x.Mall)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.MallId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Employees)
                .WithOne(x=>x.Manager)
                .HasForeignKey(x=>x.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
