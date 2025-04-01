using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanLuc.Migrations
{
    /// <inheritdoc />
    public partial class ThietKeCSDLV9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DiemDanhs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NgayDiemDanh = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GioDen = table.Column<DateTime>(type: "TEXT", nullable: true),
                    GioVe = table.Column<DateTime>(type: "TEXT", nullable: true),
                    TrangThai = table.Column<int>(type: "INTEGER", nullable: false),
                    GhiChu = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiemDanhs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiemDanhs_ThongTinNguoiDungs_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "ThongTinNguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhiemVus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    TenNhiemVu = table.Column<string>(type: "TEXT", nullable: false),
                    MoTa = table.Column<string>(type: "TEXT", nullable: true),
                    HanHoanThanh = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TrangThai = table.Column<int>(type: "INTEGER", nullable: false),
                    NhanVienId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhiemVus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhiemVus_ThongTinNguoiDungs_NhanVienId",
                        column: x => x.NhanVienId,
                        principalTable: "ThongTinNguoiDungs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiemDanhs_NhanVienId",
                table: "DiemDanhs",
                column: "NhanVienId");

            migrationBuilder.CreateIndex(
                name: "IX_NhiemVus_NhanVienId",
                table: "NhiemVus",
                column: "NhanVienId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiemDanhs");

            migrationBuilder.DropTable(
                name: "NhiemVus");
        }
    }
}
