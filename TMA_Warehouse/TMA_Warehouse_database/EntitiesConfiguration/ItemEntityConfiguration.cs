using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TMA_Warehouse_database.Entities;

namespace TMA_Warehouse_database.EntitiesConfiguration
{
    public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.HasKey(p => p.ItemId);
            builder.Property(p => p.ItemId)
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.HasIndex(p=>p.ItemId)
                .IsUnique();
            builder.Property(p => p.ItemGroup)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.UnitOfMeasurement)
                .HasMaxLength(20)
                .IsRequired();
            builder.Property(p => p.Quantity)
                .IsRequired();
            builder.Property(p => p.PriceWithoutVAT)
                .HasColumnType("decimal(5,2)")
                .IsRequired();
            builder.Property(p=>p.Status)
                .HasMaxLength (20)
                .IsRequired();
            builder.Property(p=>p.StorageLocation)
                .HasMaxLength(20);
            builder.Property(p => p.ContactPerson)
                .HasMaxLength(50);
        }
    }
}
