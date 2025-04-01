using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanLuc.Migrations
{
    /// <inheritdoc />
    public partial class AddNhanSuAndPhongBan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhongBans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenPhongBan = table.Column<string>(type: "TEXT", nullable: false),
                    MaPhongBan = table.Column<string>(type: "TEXT", nullable: false),
                    MoTa = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhongBans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NhanSus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaNhanVien = table.Column<string>(type: "TEXT", nullable: false),
                    HoVaTen = table.Column<string>(type: "TEXT", nullable: false),
                    PhongBanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanSus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NhanSus_PhongBans_PhongBanId",
                        column: x => x.PhongBanId,
                        principalTable: "PhongBans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChamCongs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NhanSuId = table.Column<int>(type: "INTEGER", nullable: false),
                    NgayChamCong = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GioVao = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    GioRa = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    TrangThai = table.Column<string>(type: "TEXT", nullable: false),
                    GhiChu = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamCongs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChamCongs_NhanSus_NhanSuId",
                        column: x => x.NhanSuId,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LichLamThems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NhanSuId = table.Column<int>(type: "INTEGER", nullable: false),
                    NgayLamThem = table.Column<DateTime>(type: "TEXT", nullable: false),
                    GioBatDau = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    GioKetThuc = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    LyDo = table.Column<string>(type: "TEXT", nullable: false),
                    TrangThai = table.Column<string>(type: "TEXT", nullable: false),
                    NguoiDuyet = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LichLamThems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LichLamThems_NhanSus_NhanSuId",
                        column: x => x.NhanSuId,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChamCongs_NhanSuId",
                table: "ChamCongs",
                column: "NhanSuId");

            migrationBuilder.CreateIndex(
                name: "IX_LichLamThems_NhanSuId",
                table: "LichLamThems",
                column: "NhanSuId");

            migrationBuilder.CreateIndex(
                name: "IX_NhanSus_PhongBanId",
                table: "NhanSus",
                column: "PhongBanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChamCongs");

            migrationBuilder.DropTable(
                name: "LichLamThems");

            migrationBuilder.DropTable(
                name: "NhanSus");

            migrationBuilder.DropTable(
                name: "PhongBans");
        }
    }
}
