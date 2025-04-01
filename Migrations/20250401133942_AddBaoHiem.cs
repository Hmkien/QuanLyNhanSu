using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanLuc.Migrations
{
    /// <inheritdoc />
    public partial class AddBaoHiem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BaoHiems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NhanSuId = table.Column<int>(type: "INTEGER", nullable: false),
                    SoBHXH = table.Column<string>(type: "TEXT", maxLength: 13, nullable: false),
                    SoBHXHCu = table.Column<string>(type: "TEXT", maxLength: 13, nullable: true),
                    NgayThamGia = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoiDangKyBHXH = table.Column<string>(type: "TEXT", nullable: false),
                    NgayNhanSoBHXH = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NgayCap = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NgayTraSoBHXH = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NgayThamGiaBHTN = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ThoiGianDongBHTN = table.Column<int>(type: "INTEGER", nullable: false),
                    SoBHYT = table.Column<string>(type: "TEXT", maxLength: 15, nullable: false),
                    NgayCapThe = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NgayHetHan = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NoiDangKyKCB = table.Column<string>(type: "TEXT", nullable: false),
                    MaKCB = table.Column<string>(type: "TEXT", nullable: false),
                    MaTinhBenhVien = table.Column<string>(type: "TEXT", nullable: false),
                    DaTraTheBHYT = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaoHiems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaoHiems_NhanSus_NhanSuId",
                        column: x => x.NhanSuId,
                        principalTable: "NhanSus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BaoHiems_NhanSuId",
                table: "BaoHiems",
                column: "NhanSuId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BaoHiems");
        }
    }
}
