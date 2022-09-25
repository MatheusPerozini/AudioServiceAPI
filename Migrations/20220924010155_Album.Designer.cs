﻿// <auto-generated />
using System;
using AudioService.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AudioServiceApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220924010155_Album")]
    partial class Album
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AlbumArtista", b =>
                {
                    b.Property<int>("albumscodAlb")
                        .HasColumnType("int");

                    b.Property<int>("artistascodArt")
                        .HasColumnType("int");

                    b.HasKey("albumscodAlb", "artistascodArt");

                    b.HasIndex("artistascodArt");

                    b.ToTable("AlbumArtista");
                });

            modelBuilder.Entity("AudioService.Models.Album", b =>
                {
                    b.Property<int>("codAlb")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codAlb"), 1L, 1);

                    b.Property<DateTime>("dataLancamento")
                        .HasColumnType("datetime2");

                    b.Property<string>("genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("gravadoracodGrav")
                        .HasColumnType("int");

                    b.Property<string>("titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codAlb");

                    b.HasIndex("gravadoracodGrav");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("AudioService.Models.Artista", b =>
                {
                    b.Property<int>("codArt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codArt"), 1L, 1);

                    b.Property<string>("nomeArt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codArt");

                    b.ToTable("Artista");
                });

            modelBuilder.Entity("AudioService.Models.Gravadora", b =>
                {
                    b.Property<int>("codGrav")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("codGrav"), 1L, 1);

                    b.Property<string>("nomeGrav")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codGrav");

                    b.ToTable("Gravadora");
                });

            modelBuilder.Entity("AlbumArtista", b =>
                {
                    b.HasOne("AudioService.Models.Album", null)
                        .WithMany()
                        .HasForeignKey("albumscodAlb")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AudioService.Models.Artista", null)
                        .WithMany()
                        .HasForeignKey("artistascodArt")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AudioService.Models.Album", b =>
                {
                    b.HasOne("AudioService.Models.Gravadora", "gravadora")
                        .WithMany("Albums")
                        .HasForeignKey("gravadoracodGrav")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("gravadora");
                });

            modelBuilder.Entity("AudioService.Models.Gravadora", b =>
                {
                    b.Navigation("Albums");
                });
#pragma warning restore 612, 618
        }
    }
}