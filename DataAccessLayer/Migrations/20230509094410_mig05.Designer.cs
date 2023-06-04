﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockApp.Data.Concrete;

#nullable disable

namespace StockApp.Data.Migrations
{
    [DbContext(typeof(StockAppDbContext))]
    [Migration("20230509094410_mig05")]
    partial class mig05
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StockApp.Entity.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies");
                });

            modelBuilder.Entity("StockApp.Entity.QuantityUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("QuantityUnits");
                });

            modelBuilder.Entity("StockApp.Entity.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CriticQantity")
                        .HasColumnType("int");

                    b.Property<string>("Cupboard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Shelf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("StockClassId")
                        .HasColumnType("int");

                    b.Property<int>("StockTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UnitCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StockClassId");

                    b.HasIndex("StockTypeId");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("StockApp.Entity.StockClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("StockClasses");
                });

            modelBuilder.Entity("StockApp.Entity.StockType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("StockTypes");
                });

            modelBuilder.Entity("StockApp.Entity.StockUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BuyingCurrencyId")
                        .HasColumnType("int");

                    b.Property<float>("BuyingPrince")
                        .HasColumnType("real");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaperWeight")
                        .HasColumnType("int");

                    b.Property<int>("QuantityUnitId")
                        .HasColumnType("int");

                    b.Property<int>("SaleCurrencyId")
                        .HasColumnType("int");

                    b.Property<float>("SalePrice")
                        .HasColumnType("real");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<int>("StockTypeId")
                        .HasColumnType("int");

                    b.Property<int>("UnitCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("QuantityUnitId");

                    b.HasIndex("StockTypeId");

                    b.ToTable("StockUnits");
                });

            modelBuilder.Entity("StockApp.Entity.Stock", b =>
                {
                    b.HasOne("StockApp.Entity.StockClass", "StockClass")
                        .WithMany("Stocks")
                        .HasForeignKey("StockClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockApp.Entity.StockType", "StockType")
                        .WithMany("Stocks")
                        .HasForeignKey("StockTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StockClass");

                    b.Navigation("StockType");
                });

            modelBuilder.Entity("StockApp.Entity.StockUnit", b =>
                {
                    b.HasOne("StockApp.Entity.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockApp.Entity.QuantityUnit", "QuantityUnit")
                        .WithMany()
                        .HasForeignKey("QuantityUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StockApp.Entity.StockType", "StockType")
                        .WithMany("Units")
                        .HasForeignKey("StockTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Currency");

                    b.Navigation("QuantityUnit");

                    b.Navigation("StockType");
                });

            modelBuilder.Entity("StockApp.Entity.StockClass", b =>
                {
                    b.Navigation("Stocks");
                });

            modelBuilder.Entity("StockApp.Entity.StockType", b =>
                {
                    b.Navigation("Stocks");

                    b.Navigation("Units");
                });
#pragma warning restore 612, 618
        }
    }
}
