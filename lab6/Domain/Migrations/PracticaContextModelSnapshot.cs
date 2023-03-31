﻿// <auto-generated />
using System;
using Domain.SQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(PracticaContext))]
    partial class PracticaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.SQL.Cart", b =>
                {
                    b.Property<int>("IdOrder")
                        .HasColumnType("int");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("TotalCost")
                        .HasColumnType("int");

                    b.HasKey("IdOrder", "IdProduct");

                    b.HasIndex("IdProduct");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("Domain.SQL.CategoriseProduct", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("CategoriseProduct", (string)null);
                });

            modelBuilder.Entity("Domain.SQL.Filter", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Categorise")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Categorise");

                    b.ToTable("Filter", (string)null);
                });

            modelBuilder.Entity("Domain.SQL.OrderUser", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("IdUsers")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("status");

                    b.Property<int?>("TypeDelivery")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdUsers");

                    b.HasIndex("TypeDelivery");

                    b.ToTable("OrderUser", (string)null);
                });

            modelBuilder.Entity("Domain.SQL.Product", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Categories")
                        .HasColumnType("int");

                    b.Property<int?>("Cost")
                        .HasColumnType("int");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Categories");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("Domain.SQL.TypeDelivery", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("Cost")
                        .HasColumnType("int");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TypeDelivery", (string)null);
                });

            modelBuilder.Entity("Domain.SQL.User", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Card")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.SQL.Cart", b =>
                {
                    b.HasOne("Domain.SQL.OrderUser", "IdOrderNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("IdOrder")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_OrderUser");

                    b.HasOne("Domain.SQL.Product", "IdProductNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("IdProduct")
                        .IsRequired()
                        .HasConstraintName("FK_Cart_Product");

                    b.Navigation("IdOrderNavigation");

                    b.Navigation("IdProductNavigation");
                });

            modelBuilder.Entity("Domain.SQL.Filter", b =>
                {
                    b.HasOne("Domain.SQL.CategoriseProduct", "CategoriseNavigation")
                        .WithMany("Filters")
                        .HasForeignKey("Categorise")
                        .HasConstraintName("FK_Filter_CategoriseProduct");

                    b.Navigation("CategoriseNavigation");
                });

            modelBuilder.Entity("Domain.SQL.OrderUser", b =>
                {
                    b.HasOne("Domain.SQL.User", "IdUsersNavigation")
                        .WithMany("OrderUsers")
                        .HasForeignKey("IdUsers")
                        .HasConstraintName("FK_OrderUser_Users");

                    b.HasOne("Domain.SQL.TypeDelivery", "TypeDeliveryNavigation")
                        .WithMany("OrderUsers")
                        .HasForeignKey("TypeDelivery")
                        .HasConstraintName("FK_OrderUser_TypeDelivery");

                    b.Navigation("IdUsersNavigation");

                    b.Navigation("TypeDeliveryNavigation");
                });

            modelBuilder.Entity("Domain.SQL.Product", b =>
                {
                    b.HasOne("Domain.SQL.CategoriseProduct", "CategoriesNavigation")
                        .WithMany("Products")
                        .HasForeignKey("Categories")
                        .HasConstraintName("FK_Product_CategoriseProduct");

                    b.Navigation("CategoriesNavigation");
                });

            modelBuilder.Entity("Domain.SQL.CategoriseProduct", b =>
                {
                    b.Navigation("Filters");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("Domain.SQL.OrderUser", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("Domain.SQL.Product", b =>
                {
                    b.Navigation("Carts");
                });

            modelBuilder.Entity("Domain.SQL.TypeDelivery", b =>
                {
                    b.Navigation("OrderUsers");
                });

            modelBuilder.Entity("Domain.SQL.User", b =>
                {
                    b.Navigation("OrderUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
