﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using real_estate_app.Models;

#nullable disable

namespace real_estate_app.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240605113545_firsty")]
    partial class firsty
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("real_estate_app.Models.RealEstate", b =>
                {
                    b.Property<int>("RealEstateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RealEstateId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSaled")
                        .HasColumnType("boolean");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("RoomNumb")
                        .HasColumnType("integer");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<int>("SquareMeter")
                        .HasColumnType("integer");

                    b.HasKey("RealEstateId");

                    b.HasIndex("SellerId");

                    b.ToTable("RealEstate");
                });

            modelBuilder.Entity("real_estate_app.Models.RealEstateInventory", b =>
                {
                    b.Property<int>("RealEstateInventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("RealEstateInventoryId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSaled")
                        .HasColumnType("boolean");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("RealEstateId")
                        .HasColumnType("integer");

                    b.Property<int>("RoomNumb")
                        .HasColumnType("integer");

                    b.Property<int>("SquareMeter")
                        .HasColumnType("integer");

                    b.HasKey("RealEstateInventoryId");

                    b.HasIndex("RealEstateId");

                    b.ToTable("RealEstateInventory");
                });

            modelBuilder.Entity("real_estate_app.Models.Seller", b =>
                {
                    b.Property<int>("SellerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SellerId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("SellerId");

                    b.ToTable("Seller");
                });

            modelBuilder.Entity("real_estate_app.Models.RealEstate", b =>
                {
                    b.HasOne("real_estate_app.Models.Seller", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("real_estate_app.Models.RealEstateInventory", b =>
                {
                    b.HasOne("real_estate_app.Models.RealEstate", "RealEstate")
                        .WithMany()
                        .HasForeignKey("RealEstateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RealEstate");
                });
#pragma warning restore 612, 618
        }
    }
}
