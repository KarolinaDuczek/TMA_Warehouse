using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TMA_Warehouse_database.Entities;

namespace TMA_Warehouse_database.EntitiesConfiguration
{
    public class RequestRowEntityConfiguration : IEntityTypeConfiguration<RequestRow>
    {
        public void Configure(EntityTypeBuilder<RequestRow> builder)
        {
            builder.Property(p=>p.RequestId)
                .IsRequired();
            builder.HasIndex(p => p.RequestId)
                .IsUnique();
            builder.HasKey(p => p.RequestRowId);
            builder.Property(p => p.RequestRowId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.HasIndex(p => p.RequestRowId)
                .IsUnique();
            builder.Property(p => p.ItemIds)
                .IsRequired();
            builder.Property(p => p.UnitOfMeasurement)
                .IsRequired();
            builder.Property(p => p.Quantity)
                .IsRequired();
            builder.Property(p => p.PriceWithoutVAT)
                .IsRequired()
                .HasColumnType("decimal(5,2)");
            builder.Property(p => p.Comment)
                .HasMaxLength(50);
        }
    }
}
