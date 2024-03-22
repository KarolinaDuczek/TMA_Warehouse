﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMA_Warehouse_database.Entities;

namespace TMA_Warehouse_database.EntitiesConfiguration
{
    public class RequestEntityConfiguration : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.HasKey(p => p.RequestId);
            builder.Property(p => p.RequestId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.HasIndex(p => p.RequestId)
                .IsUnique();
            builder.Property(p => p.EmployeeName)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.Quantity)
                .IsRequired();
            builder.Property(p => p.Comment)
                .HasMaxLength(50);
            builder.Property(p => p.Status)
                .HasMaxLength(20);
            builder.Property(p => p.RequestRowId)
                .IsRequired();
            builder.HasIndex(p => p.RequestRowId)
                .IsUnique();

            //builder.HasOne(request => request.RequestRow)
            //       .WithOne(requestRow => requestRow.Request)
            //       .HasForeignKey<RequestRow>(r => r.RequestRowId)
            //       .IsRequired();
        }
    }
}
