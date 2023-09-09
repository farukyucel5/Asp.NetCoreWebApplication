﻿// <auto-generated />
using Asp.NetCoreProjectWebApp.Utility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Asp.NetCoreProjectWebApp.Migrations
{
    [DbContext(typeof(UygulamaDbContext))]
    partial class UygulamaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Asp.NetCoreProjectWebApp.Models.Kitap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Fiyat")
                        .HasColumnType("double");

                    b.Property<string>("KitapAdi")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("KitapTuruId")
                        .HasColumnType("int");

                    b.Property<string>("ResimUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tanim")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Yazar")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("KitapTuruId");

                    b.ToTable("Kitaplar");
                });

            modelBuilder.Entity("Asp.NetCoreProjectWebApp.Models.KitapTuru", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ad")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)");

                    b.HasKey("Id");

                    b.ToTable("KitapTurleri");
                });

            modelBuilder.Entity("Asp.NetCoreProjectWebApp.Models.Kitap", b =>
                {
                    b.HasOne("Asp.NetCoreProjectWebApp.Models.KitapTuru", "KitapTuru")
                        .WithMany()
                        .HasForeignKey("KitapTuruId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("KitapTuru");
                });
#pragma warning restore 612, 618
        }
    }
}
