﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication2;

namespace WebApplication2.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20220120181430_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WebApplication2.Album", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("year")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("WebApplication2.Song", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("album_id")
                        .HasColumnType("int");

                    b.Property<int?>("albumid")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("albumid");

                    b.ToTable("Songs");
                });

            modelBuilder.Entity("WebApplication2.Song", b =>
                {
                    b.HasOne("WebApplication2.Album", "album")
                        .WithMany("songs")
                        .HasForeignKey("albumid");

                    b.Navigation("album");
                });

            modelBuilder.Entity("WebApplication2.Album", b =>
                {
                    b.Navigation("songs");
                });
#pragma warning restore 612, 618
        }
    }
}
