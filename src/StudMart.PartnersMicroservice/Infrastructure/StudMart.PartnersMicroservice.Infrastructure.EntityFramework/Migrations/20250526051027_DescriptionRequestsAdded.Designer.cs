﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using StudMart.PartnersMicroservice.Infrastructure.EntityFramework;

#nullable disable

namespace StudMart.PartnersMicroservice.Infrastructure.EntityFramework.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250526051027_DescriptionRequestsAdded")]
    partial class DescriptionRequestsAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PartnerRegion", b =>
                {
                    b.Property<Guid>("PartnerId")
                        .HasColumnType("uuid");

                    b.Property<int>("RegionsId")
                        .HasColumnType("integer");

                    b.HasKey("PartnerId", "RegionsId");

                    b.HasIndex("RegionsId");

                    b.ToTable("PartnerRegion");
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.Aggregates.Partner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1200)
                        .HasColumnType("character varying(1200)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<bool>("HasAllRegions")
                        .HasColumnType("boolean");

                    b.Property<long>("Inn")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("character varying(15)");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<string>("Site")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CountryId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.DescriptionRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1200)
                        .HasColumnType("character varying(1200)");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("DescriptionRequests");
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("character varying(70)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<Guid>("PartnerId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("PartnerId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CountryId")
                        .HasColumnType("integer");

                    b.Property<int>("CountryId1")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(80)
                        .HasColumnType("character varying(80)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("CountryId1");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("PartnerRegion", b =>
                {
                    b.HasOne("StudMart.PartnersMicroservice.Domain.Entities.Aggregates.Partner", null)
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudMart.PartnersMicroservice.Domain.Entities.Region", null)
                        .WithMany()
                        .HasForeignKey("RegionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.Aggregates.Partner", b =>
                {
                    b.HasOne("StudMart.PartnersMicroservice.Domain.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("StudMart.PartnersMicroservice.Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("StudMart.PartnersMicroservice.Domain.ValueObjects.PaymentInformation", "PaymentInformation", b1 =>
                        {
                            b1.Property<Guid>("PartnerId")
                                .HasColumnType("uuid");

                            b1.Property<string>("AccountNumber")
                                .IsRequired()
                                .HasMaxLength(21)
                                .HasColumnType("character varying(21)");

                            b1.Property<string>("Bik")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("character varying(10)");

                            b1.Property<string>("CorrespondentAccountNumber")
                                .IsRequired()
                                .HasMaxLength(21)
                                .HasColumnType("character varying(21)");

                            b1.HasKey("PartnerId");

                            b1.ToTable("Partners");

                            b1.WithOwner()
                                .HasForeignKey("PartnerId");
                        });

                    b.Navigation("Category");

                    b.Navigation("Country");

                    b.Navigation("PaymentInformation")
                        .IsRequired();
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.DescriptionRequest", b =>
                {
                    b.HasOne("StudMart.PartnersMicroservice.Domain.Entities.Aggregates.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.Employee", b =>
                {
                    b.HasOne("StudMart.PartnersMicroservice.Domain.Entities.Aggregates.Partner", "Partner")
                        .WithMany("Employees")
                        .HasForeignKey("PartnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.Region", b =>
                {
                    b.HasOne("StudMart.PartnersMicroservice.Domain.Entities.Country", null)
                        .WithMany("Regions")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("StudMart.PartnersMicroservice.Domain.Entities.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId1")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.Aggregates.Partner", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("StudMart.PartnersMicroservice.Domain.Entities.Country", b =>
                {
                    b.Navigation("Regions");
                });
#pragma warning restore 612, 618
        }
    }
}
