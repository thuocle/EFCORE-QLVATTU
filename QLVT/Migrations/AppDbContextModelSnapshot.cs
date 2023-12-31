﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QLVT.Entities;

#nullable disable

namespace QLVT.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("QLVT.Entities.ChiTietPhieuNhap", b =>
                {
                    b.Property<int>("ChiTietPhieuNhapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietPhieuNhapID"));

                    b.Property<int>("PhieuNhapID")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongNhap")
                        .HasColumnType("int");

                    b.Property<int>("VatTuID")
                        .HasColumnType("int");

                    b.HasKey("ChiTietPhieuNhapID");

                    b.HasIndex("PhieuNhapID");

                    b.HasIndex("VatTuID");

                    b.ToTable("ChiTietPhieuNhap");
                });

            modelBuilder.Entity("QLVT.Entities.ChiTietPhieuXuat", b =>
                {
                    b.Property<int>("ChiTietPhieuXuatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ChiTietPhieuXuatID"));

                    b.Property<int>("PhieuXuatID")
                        .HasColumnType("int");

                    b.Property<int>("SoLuongXuat")
                        .HasColumnType("int");

                    b.Property<int>("VatTuID")
                        .HasColumnType("int");

                    b.HasKey("ChiTietPhieuXuatID");

                    b.HasIndex("PhieuXuatID");

                    b.HasIndex("VatTuID");

                    b.ToTable("ChiTietPhieuXuat");
                });

            modelBuilder.Entity("QLVT.Entities.PhieuNhap", b =>
                {
                    b.Property<int>("PhieuNhapID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhieuNhapID"));

                    b.Property<int>("MaPhieu")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayNhap")
                        .HasColumnType("datetime2");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhieuNhapID");

                    b.ToTable("PhieuNhap");
                });

            modelBuilder.Entity("QLVT.Entities.PhieuXuat", b =>
                {
                    b.Property<int>("PhieuXuatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhieuXuatID"));

                    b.Property<int>("MaPhieu")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayXuat")
                        .HasColumnType("datetime2");

                    b.Property<string>("TieuDe")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhieuXuatID");

                    b.ToTable("PhieuXuat");
                });

            modelBuilder.Entity("QLVT.Entities.VatTu", b =>
                {
                    b.Property<int>("VatTuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VatTuID"));

                    b.Property<int>("SoLuongTon")
                        .HasColumnType("int");

                    b.Property<string>("TenVatTu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VatTuID");

                    b.ToTable("VatTu");
                });

            modelBuilder.Entity("QLVT.Entities.ChiTietPhieuNhap", b =>
                {
                    b.HasOne("QLVT.Entities.PhieuNhap", "PhieuNhap")
                        .WithMany("ChiTietPhieuNhap")
                        .HasForeignKey("PhieuNhapID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLVT.Entities.VatTu", "VatTu")
                        .WithMany("ChiTietPhieuNhap")
                        .HasForeignKey("VatTuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuNhap");

                    b.Navigation("VatTu");
                });

            modelBuilder.Entity("QLVT.Entities.ChiTietPhieuXuat", b =>
                {
                    b.HasOne("QLVT.Entities.PhieuXuat", "PhieuXuat")
                        .WithMany("ChiTietPhieuXuat")
                        .HasForeignKey("PhieuXuatID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QLVT.Entities.VatTu", "VatTu")
                        .WithMany("ChiTietPhieuXuat")
                        .HasForeignKey("VatTuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PhieuXuat");

                    b.Navigation("VatTu");
                });

            modelBuilder.Entity("QLVT.Entities.PhieuNhap", b =>
                {
                    b.Navigation("ChiTietPhieuNhap");
                });

            modelBuilder.Entity("QLVT.Entities.PhieuXuat", b =>
                {
                    b.Navigation("ChiTietPhieuXuat");
                });

            modelBuilder.Entity("QLVT.Entities.VatTu", b =>
                {
                    b.Navigation("ChiTietPhieuNhap");

                    b.Navigation("ChiTietPhieuXuat");
                });
#pragma warning restore 612, 618
        }
    }
}
