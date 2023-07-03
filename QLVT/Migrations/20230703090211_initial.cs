using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLVT.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhieuNhap",
                columns: table => new
                {
                    PhieuNhapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieu = table.Column<int>(type: "int", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuNhap", x => x.PhieuNhapID);
                });

            migrationBuilder.CreateTable(
                name: "PhieuXuat",
                columns: table => new
                {
                    PhieuXuatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaPhieu = table.Column<int>(type: "int", nullable: false),
                    TieuDe = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NgayNhap = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhieuXuat", x => x.PhieuXuatID);
                });

            migrationBuilder.CreateTable(
                name: "VatTu",
                columns: table => new
                {
                    VatTuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVatTu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoLuongTon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VatTu", x => x.VatTuID);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuNhap",
                columns: table => new
                {
                    ChiTietPhieuNhapID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VatTuID = table.Column<int>(type: "int", nullable: false),
                    PhieuNhapID = table.Column<int>(type: "int", nullable: false),
                    SoLuongNhap = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuNhap", x => x.ChiTietPhieuNhapID);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_PhieuNhap_PhieuNhapID",
                        column: x => x.PhieuNhapID,
                        principalTable: "PhieuNhap",
                        principalColumn: "PhieuNhapID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuNhap_VatTu_VatTuID",
                        column: x => x.VatTuID,
                        principalTable: "VatTu",
                        principalColumn: "VatTuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietPhieuXuat",
                columns: table => new
                {
                    ChiTietPhieuXuatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VatTuID = table.Column<int>(type: "int", nullable: false),
                    PhieuXuatID = table.Column<int>(type: "int", nullable: false),
                    SoLuongXuat = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietPhieuXuat", x => x.ChiTietPhieuXuatID);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuat_PhieuXuat_PhieuXuatID",
                        column: x => x.PhieuXuatID,
                        principalTable: "PhieuXuat",
                        principalColumn: "PhieuXuatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietPhieuXuat_VatTu_VatTuID",
                        column: x => x.VatTuID,
                        principalTable: "VatTu",
                        principalColumn: "VatTuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_PhieuNhapID",
                table: "ChiTietPhieuNhap",
                column: "PhieuNhapID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuNhap_VatTuID",
                table: "ChiTietPhieuNhap",
                column: "VatTuID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuat_PhieuXuatID",
                table: "ChiTietPhieuXuat",
                column: "PhieuXuatID");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietPhieuXuat_VatTuID",
                table: "ChiTietPhieuXuat",
                column: "VatTuID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietPhieuNhap");

            migrationBuilder.DropTable(
                name: "ChiTietPhieuXuat");

            migrationBuilder.DropTable(
                name: "PhieuNhap");

            migrationBuilder.DropTable(
                name: "PhieuXuat");

            migrationBuilder.DropTable(
                name: "VatTu");
        }
    }
}
