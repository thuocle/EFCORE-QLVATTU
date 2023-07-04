using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QLVT.Migrations
{
    /// <inheritdoc />
    public partial class update_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NgayNhap",
                table: "PhieuXuat",
                newName: "NgayXuat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NgayXuat",
                table: "PhieuXuat",
                newName: "NgayNhap");
        }
    }
}
