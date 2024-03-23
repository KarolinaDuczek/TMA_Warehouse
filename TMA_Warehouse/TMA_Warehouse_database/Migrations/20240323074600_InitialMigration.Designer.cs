﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TMA_Warehouse_database.Context;

#nullable disable

namespace TMA_Warehouse_database.Migrations
{
    [DbContext(typeof(WarehouseContext))]
    [Migration("20240323074600_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TMA_Warehouse_database.Entities.Item", b =>
                {
                    b.Property<int>("ItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ItemId"));

                    b.Property<string>("ContactPerson")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte>("ItemGroup")
                        .HasMaxLength(50)
                        .HasColumnType("tinyint");

                    b.Property<decimal>("PriceWithoutVAT")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("StorageLocation")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<byte>("UnitOfMeasurement")
                        .HasMaxLength(20)
                        .HasColumnType("tinyint");

                    b.HasKey("ItemId");

                    b.HasIndex("ItemId")
                        .IsUnique();

                    b.ToTable("Items");
                });

            modelBuilder.Entity("TMA_Warehouse_database.Entities.Request", b =>
                {
                    b.Property<int>("RequestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestId"));

                    b.Property<string>("Comment")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EmployeeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<decimal>("PriceWithoutVAT")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<byte?>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("tinyint");

                    b.Property<byte>("UnitOfMeasurement")
                        .HasColumnType("tinyint");

                    b.HasKey("RequestId");

                    b.HasIndex("ItemId");

                    b.HasIndex("RequestId")
                        .IsUnique();

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("TMA_Warehouse_database.Entities.Request", b =>
                {
                    b.HasOne("TMA_Warehouse_database.Entities.Item", "Item")
                        .WithMany("Requests")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
                });

            modelBuilder.Entity("TMA_Warehouse_database.Entities.Item", b =>
                {
                    b.Navigation("Requests");
                });
#pragma warning restore 612, 618
        }
    }
}
