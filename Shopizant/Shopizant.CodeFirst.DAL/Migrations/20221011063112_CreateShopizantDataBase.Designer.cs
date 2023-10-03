﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopizant.CodeFirst.DAL.Models;

namespace Shopizant.CodeFirst.DAL.Migrations
{
    [DbContext(typeof(ShopizantDBContext))]
    [Migration("20221011063112_CreateShopizantDataBase")]
    partial class CreateShopizantDataBase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Shopizant.CodeFirst.DAL.Models.CardDetails", b =>
                {
                    b.Property<string>("NameCard")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("CardBalance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CardNumber")
                        .HasColumnType("decimal(18,2)")
                        .HasMaxLength(25);

                    b.Property<string>("CardType")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<decimal>("Cvv")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("ExpDate")
                        .HasColumnType("datetime2");

                    b.HasKey("NameCard");

                    b.ToTable("CardDetail");
                });

            modelBuilder.Entity("Shopizant.CodeFirst.DAL.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Shopizant.CodeFirst.DAL.Models.Product", b =>
                {
                    b.Property<string>("ProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<byte>("CatrgoryId")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("QuantityAvailable")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Shopizant.CodeFirst.DAL.Models.PurchaseDetails", b =>
                {
                    b.Property<int>("PurchaseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DayOfPurchase")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("ProductNavProductId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PurchaseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<int>("QuantityPurchased")
                        .HasColumnType("int");

                    b.Property<string>("UserEmailEmailId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("PurchaseID");

                    b.HasIndex("ProductNavProductId");

                    b.HasIndex("UserEmailEmailId");

                    b.ToTable("PurchaseDetail");
                });

            modelBuilder.Entity("Shopizant.CodeFirst.DAL.Models.Roles", b =>
                {
                    b.Property<byte>("RoleID")
                        .HasColumnType("tinyint");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.HasKey("RoleID");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Shopizant.CodeFirst.DAL.Models.Users", b =>
                {
                    b.Property<string>("EmailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<byte>("RoleId")
                        .HasColumnType("tinyint");

                    b.HasKey("EmailId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Shopizant.CodeFirst.DAL.Models.Product", b =>
                {
                    b.HasOne("Shopizant.CodeFirst.DAL.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Shopizant.CodeFirst.DAL.Models.PurchaseDetails", b =>
                {
                    b.HasOne("Shopizant.CodeFirst.DAL.Models.Product", "ProductNav")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("ProductNavProductId");

                    b.HasOne("Shopizant.CodeFirst.DAL.Models.Users", "UserEmail")
                        .WithMany("PurchaseDetails")
                        .HasForeignKey("UserEmailEmailId");
                });

            modelBuilder.Entity("Shopizant.CodeFirst.DAL.Models.Users", b =>
                {
                    b.HasOne("Shopizant.CodeFirst.DAL.Models.Roles", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
