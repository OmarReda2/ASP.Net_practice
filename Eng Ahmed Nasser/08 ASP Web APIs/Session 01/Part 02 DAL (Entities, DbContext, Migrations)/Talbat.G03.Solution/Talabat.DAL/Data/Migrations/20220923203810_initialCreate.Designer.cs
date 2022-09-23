﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Talabat.DAL.Data;

namespace Talabat.DAL.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20220923203810_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Talabat.DAL.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descrption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ProductBrandIdid")
                        .HasColumnType("int");

                    b.Property<int?>("ProductBrandid")
                        .HasColumnType("int");

                    b.Property<int?>("ProductTypeIdid")
                        .HasColumnType("int");

                    b.Property<int?>("ProductTypeid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("ProductBrandIdid");

                    b.HasIndex("ProductBrandid");

                    b.HasIndex("ProductTypeIdid");

                    b.HasIndex("ProductTypeid");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Talabat.DAL.Entities.ProductBrand", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProductBrand");
                });

            modelBuilder.Entity("Talabat.DAL.Entities.ProductType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ProductType");
                });

            modelBuilder.Entity("Talabat.DAL.Entities.Product", b =>
                {
                    b.HasOne("Talabat.DAL.Entities.ProductBrand", "ProductBrandId")
                        .WithMany()
                        .HasForeignKey("ProductBrandIdid");

                    b.HasOne("Talabat.DAL.Entities.ProductBrand", "ProductBrand")
                        .WithMany()
                        .HasForeignKey("ProductBrandid");

                    b.HasOne("Talabat.DAL.Entities.ProductType", "ProductTypeId")
                        .WithMany()
                        .HasForeignKey("ProductTypeIdid");

                    b.HasOne("Talabat.DAL.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeid");

                    b.Navigation("ProductBrand");

                    b.Navigation("ProductBrandId");

                    b.Navigation("ProductType");

                    b.Navigation("ProductTypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
