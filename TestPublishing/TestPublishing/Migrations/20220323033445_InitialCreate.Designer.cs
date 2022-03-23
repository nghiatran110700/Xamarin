﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestPublishing.Model;

namespace TestPublishing.Migrations
{
    [DbContext(typeof(NccData))]
    [Migration("20220323033445_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestPublishing.Model.Asset", b =>
                {
                    b.Property<Guid>("AccessK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("AccessPercent")
                        .HasColumnType("float");

                    b.Property<string>("Accessname")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("AssetTypeK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LocationK")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("TimeRead")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AccessK");

                    b.HasIndex("AssetTypeK");

                    b.HasIndex("LocationK");

                    b.ToTable("Asset");
                });

            modelBuilder.Entity("TestPublishing.Model.AssetType", b =>
                {
                    b.Property<Guid>("AssetTypeK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssetTypeName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("AssetTypeK");

                    b.ToTable("AssetType");
                });

            modelBuilder.Entity("TestPublishing.Model.LocationTB", b =>
                {
                    b.Property<Guid>("LocationK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LocationName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("TenancyK")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LocationK");

                    b.HasIndex("TenancyK");

                    b.ToTable("LocationTB");
                });

            modelBuilder.Entity("TestPublishing.Model.Tenancy", b =>
                {
                    b.Property<Guid>("TenancyK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("TenancyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TenancyK");

                    b.ToTable("Tenancy");
                });

            modelBuilder.Entity("TestPublishing.Model.UserTB", b =>
                {
                    b.Property<Guid>("UserK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Username")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserK");

                    b.ToTable("UserTB");
                });

            modelBuilder.Entity("TestPublishing.Model.Asset", b =>
                {
                    b.HasOne("TestPublishing.Model.AssetType", "AssetType")
                        .WithMany("Asset")
                        .HasForeignKey("AssetTypeK");

                    b.HasOne("TestPublishing.Model.LocationTB", "LocationTB")
                        .WithMany("Asset")
                        .HasForeignKey("LocationK");

                    b.Navigation("AssetType");

                    b.Navigation("LocationTB");
                });

            modelBuilder.Entity("TestPublishing.Model.LocationTB", b =>
                {
                    b.HasOne("TestPublishing.Model.Tenancy", "Tenancy")
                        .WithMany("LocationTB")
                        .HasForeignKey("TenancyK");

                    b.Navigation("Tenancy");
                });

            modelBuilder.Entity("TestPublishing.Model.AssetType", b =>
                {
                    b.Navigation("Asset");
                });

            modelBuilder.Entity("TestPublishing.Model.LocationTB", b =>
                {
                    b.Navigation("Asset");
                });

            modelBuilder.Entity("TestPublishing.Model.Tenancy", b =>
                {
                    b.Navigation("LocationTB");
                });
#pragma warning restore 612, 618
        }
    }
}
