﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyFirstMVC.Models;

namespace MyFirstMVC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyFirstMVC.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("ParentCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new { Id = 1, Name = "IOS" },
                        new { Id = 2, Name = "Android" }
                    );
                });

            modelBuilder.Entity("MyFirstMVC.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new { Id = 1, Name = "Apple" },
                        new { Id = 2, Name = "Samsung" },
                        new { Id = 3, Name = "Nokia" }
                    );
                });

            modelBuilder.Entity("MyFirstMVC.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addres");

                    b.Property<string>("ContactPhone");

                    b.Property<int>("PhoneId");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.HasIndex("PhoneId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("MyFirstMVC.Models.Phone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<int>("CompanyId");

                    b.Property<bool>("InStock");

                    b.Property<string>("Name");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Phones");

                    b.HasData(
                        new { Id = 1, CategoryId = 1, CompanyId = 1, InStock = true, Name = "Iphone 4", Price = 200.0 },
                        new { Id = 2, CategoryId = 2, CompanyId = 2, InStock = false, Name = "Xperia", Price = 100.0 }
                    );
                });

            modelBuilder.Entity("MyFirstMVC.Models.PhoneOnStock", b =>
                {
                    b.Property<int>("PhoneId");

                    b.Property<int>("StockId");

                    b.Property<int>("Quantity");

                    b.HasKey("PhoneId", "StockId");

                    b.HasIndex("StockId");

                    b.ToTable("PhonesOnStocks");
                });

            modelBuilder.Entity("MyFirstMVC.Models.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Stocks");

                    b.HasData(
                        new { Id = 1, Name = "Склад 1" },
                        new { Id = 2, Name = "Склад 2" },
                        new { Id = 3, Name = "Склад 3" }
                    );
                });

            modelBuilder.Entity("MyFirstMVC.Models.Category", b =>
                {
                    b.HasOne("MyFirstMVC.Models.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MyFirstMVC.Models.Order", b =>
                {
                    b.HasOne("MyFirstMVC.Models.Phone", "Phone")
                        .WithMany("Orders")
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MyFirstMVC.Models.Phone", b =>
                {
                    b.HasOne("MyFirstMVC.Models.Category", "Category")
                        .WithMany("Phones")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MyFirstMVC.Models.Company", "Company")
                        .WithMany("Phones")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("MyFirstMVC.Models.PhoneOnStock", b =>
                {
                    b.HasOne("MyFirstMVC.Models.Phone", "Phone")
                        .WithMany("PhoneOnStocks")
                        .HasForeignKey("PhoneId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MyFirstMVC.Models.Stock", "Stock")
                        .WithMany("PhoneOnStocks")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
