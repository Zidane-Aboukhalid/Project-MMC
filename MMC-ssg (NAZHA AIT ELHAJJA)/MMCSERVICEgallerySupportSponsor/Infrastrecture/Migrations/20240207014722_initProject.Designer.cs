﻿// <auto-generated />
using System;
using Infrastrecture.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastrecture.Migrations
{
    [DbContext(typeof(DbContextApplication))]
    [Migration("20240207014722_initProject")]
    partial class initProject
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Models.Gallery", b =>
                {
                    b.Property<Guid>("GalleryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("imageGalleryPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GalleryId");

                    b.ToTable("Gallerys");
                });

            modelBuilder.Entity("Domain.Models.SessionSponsor", b =>
                {
                    b.Property<Guid>("SessionSponsorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SponsorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SessionSponsorId");

                    b.HasIndex("SponsorId");

                    b.ToTable("SessionSponsors");
                });

            modelBuilder.Entity("Domain.Models.Sponsor", b =>
                {
                    b.Property<Guid>("SponsorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ImagesponsorPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namesponsor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SponsorId");

                    b.ToTable("Sponsors");
                });

            modelBuilder.Entity("Domain.Models.Support", b =>
                {
                    b.Property<Guid>("SupportId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Namesupport")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SupportId");

                    b.ToTable("Supports");
                });

            modelBuilder.Entity("Domain.Models.SessionSponsor", b =>
                {
                    b.HasOne("Domain.Models.Sponsor", "Sponsor")
                        .WithMany()
                        .HasForeignKey("SponsorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sponsor");
                });
#pragma warning restore 612, 618
        }
    }
}
