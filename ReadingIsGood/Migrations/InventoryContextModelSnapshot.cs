﻿// <auto-generated />
using System;
using ReadingIsGood.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ReadingIsGood.Migrations
{
    [DbContext(typeof(InventoryContext))]
    partial class InventoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReadingIsGood.Models.InventoryItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("InventoryItem");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4d5a57ce-fc83-4486-b6e3-1f52120505b6"),
                            ProductId = new Guid("2a2eb7b1-407c-44a2-9b6b-c7623f43f243"),
                            Quantity = 25
                        },
                        new
                        {
                            Id = new Guid("151a3d36-dfc0-46d6-96a8-d673745815c0"),
                            ProductId = new Guid("4e297b40-7e29-45e6-bd0c-cad5884c3700"),
                            Quantity = 45
                        },
                        new
                        {
                            Id = new Guid("26a0ed0d-32db-4e3f-912c-504802ea3a08"),
                            ProductId = new Guid("3435b3c4-45d2-4510-9f2d-748ff2a58fc3"),
                            Quantity = 15
                        },
                        new
                        {
                            Id = new Guid("626cb87f-e386-4865-a44e-2bd1d438d5db"),
                            ProductId = new Guid("c6288e56-71a5-4f12-8f3c-addc55f5cf7a"),
                            Quantity = 5
                        });
                });

            modelBuilder.Entity("ReadingIsGood.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("ProductCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2a2eb7b1-407c-44a2-9b6b-c7623f43f243"),
                            IsActive = true,
                            Name = "The Hitchhiker's Guide to the Galaxy",
                            ProductCode = "Book1"
                        },
                        new
                        {
                            Id = new Guid("4e297b40-7e29-45e6-bd0c-cad5884c3700"),
                            IsActive = true,
                            Name = "The Lord of the Rings Trilogy",
                            ProductCode = "Book2"
                        },
                        new
                        {
                            Id = new Guid("3435b3c4-45d2-4510-9f2d-748ff2a58fc3"),
                            IsActive = true,
                            Name = "The Pearl",
                            ProductCode = "Book3"
                        },
                        new
                        {
                            Id = new Guid("c6288e56-71a5-4f12-8f3c-addc55f5cf7a"),
                            IsActive = true,
                            Name = "The Hobbit",
                            ProductCode = "Book4"
                        });
                });

            modelBuilder.Entity("ReadingIsGood.Models.SalesOrder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserInfoUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserInfoUserId");

                    b.ToTable("SalesOrder");
                });

            modelBuilder.Entity("ReadingIsGood.Models.UserInfo", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("(getdate())");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("UserId")
                        .HasName("PK__UserInfo__1788CC4CF55D88A1");

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            UserId = new Guid("61ca5534-af16-49d0-bd2d-9ea47557aecc"),
                            Address = "Ankara",
                            CreatedDate = new DateTime(2021, 1, 10, 14, 51, 26, 862, DateTimeKind.Local).AddTicks(8321),
                            Email = "mustsezgin@yahoo.com",
                            FirstName = "Mustafa",
                            LastName = "Sezgin",
                            Password = "1",
                            Role = "Operator",
                            UserName = "msezgin"
                        },
                        new
                        {
                            UserId = new Guid("b490fc38-c3af-440b-9a18-f29b54d7b5e9"),
                            Address = "California",
                            CreatedDate = new DateTime(2021, 1, 10, 14, 51, 26, 863, DateTimeKind.Local).AddTicks(8942),
                            Email = "hankmoody@moody.de",
                            FirstName = "Hank",
                            LastName = "Moody",
                            Password = "1",
                            Role = "Customer",
                            UserName = "hankmoody"
                        });
                });

            modelBuilder.Entity("ReadingIsGood.Models.InventoryItem", b =>
                {
                    b.HasOne("ReadingIsGood.Models.Product", "Product")
                        .WithMany("InventoryItem")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_pro_inv");
                });

            modelBuilder.Entity("ReadingIsGood.Models.SalesOrder", b =>
                {
                    b.HasOne("ReadingIsGood.Models.Product", "Product")
                        .WithMany("SalesOrder")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_pro_sal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ReadingIsGood.Models.UserInfo", "UserInfo")
                        .WithMany("SalesOrder")
                        .HasForeignKey("UserInfoUserId")
                        .HasConstraintName("fk_usr_sal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}