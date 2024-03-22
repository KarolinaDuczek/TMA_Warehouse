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
            builder.Property(p => p.Items)
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

            //builder.HasOne(requestRow => requestRow.Request)
            //       .WithOne(request => request.RequestRow)
            //       .HasForeignKey<Request>(r => r.RequestRowId)
            //       .IsRequired();

            //builder.HasMany(requestRow => requestRow.Items)
            //       .WithOne(item => item.RequestRow)
            //       .HasPrincipalKey(requestRow => requestRow.RequestRowId)
            //       .HasForeignKey(item => item.RequestRowId);
        }
    }
}
