﻿// <auto-generated />
using System;
using App_Store.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App_Store.Api.Data.Migrations
{
    [DbContext(typeof(AppsStoreContext))]
    [Migration("20250321192118_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("App_Store.Api.Entities.Apps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenresId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<DateOnly>("ReleaseDate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("GenresId");

                    b.ToTable("Apps");
                });

            modelBuilder.Entity("App_Store.Api.Entities.Genres", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Educational"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Design"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Social Media"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Religious"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Innovations"
                        });
                });

            modelBuilder.Entity("App_Store.Api.Entities.Apps", b =>
                {
                    b.HasOne("App_Store.Api.Entities.Genres", "Genres")
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genres");
                });
#pragma warning restore 612, 618
        }
    }
}
