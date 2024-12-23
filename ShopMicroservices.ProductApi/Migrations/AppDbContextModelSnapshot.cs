﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShopMicroservices.ProductApi.Infrastructure.Context;

#nullable disable

namespace ShopMicroservices.ProductApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ShopMicroservices.ProductApi.Domain.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("44d1f9c1-2fd2-4941-93e0-a8af000f4623"),
                            Created_at = new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9526),
                            Name = "Bebidas"
                        },
                        new
                        {
                            Id = new Guid("a1a8ad4a-294d-406f-b854-355ae5b2ca19"),
                            Created_at = new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9538),
                            Name = "Salgados"
                        },
                        new
                        {
                            Id = new Guid("c07c2148-0093-46a5-8638-ba58f7ee1649"),
                            Created_at = new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9539),
                            Name = "Doces"
                        });
                });

            modelBuilder.Entity("ShopMicroservices.ProductApi.Domain.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("PriceInCents")
                        .HasColumnType("int");

                    b.Property<long>("Stock")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6fda4adf-ab64-4710-8e40-09119064fca2"),
                            CategoryId = new Guid("44d1f9c1-2fd2-4941-93e0-a8af000f4623"),
                            Created_at = new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9619),
                            Description = "da fruta",
                            ImageUrl = "suco_de_caju.jpg",
                            Name = "Suco de caju",
                            PriceInCents = 800,
                            Stock = 100L
                        },
                        new
                        {
                            Id = new Guid("0f2b29b5-8826-4891-9998-ea51d588a0ca"),
                            CategoryId = new Guid("a1a8ad4a-294d-406f-b854-355ae5b2ca19"),
                            Created_at = new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9621),
                            Description = "queijo e presunto",
                            ImageUrl = "joelho.jpg",
                            Name = "Joelho",
                            PriceInCents = 600,
                            Stock = 100L
                        },
                        new
                        {
                            Id = new Guid("d60782a1-7fb9-4dce-b5ee-b8ae439db768"),
                            CategoryId = new Guid("c07c2148-0093-46a5-8638-ba58f7ee1649"),
                            Created_at = new DateTime(2024, 12, 23, 18, 25, 3, 387, DateTimeKind.Local).AddTicks(9623),
                            Description = "de chocolate",
                            ImageUrl = "sorvete_de_chocolate.jpg",
                            Name = "Sorvete",
                            PriceInCents = 1000,
                            Stock = 100L
                        });
                });

            modelBuilder.Entity("ShopMicroservices.ProductApi.Domain.Models.Product", b =>
                {
                    b.HasOne("ShopMicroservices.ProductApi.Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("ShopMicroservices.ProductApi.Domain.Models.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
