using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanLuc.Migrations
{
    /// <inheritdoc />
    public partial class ThietKeCSDLV7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinNguoiDungs_NhanSuTypes_NhanSuTypeId",
                table: "ThongTinNguoiDungs");

            migrationBuilder.DropTable(
                name: "NhanSuTypes");

            migrationBuilder.DropIndex(
                name: "IX_ThongTinNguoiDungs_NhanSuTypeId",
                table: "ThongTinNguoiDungs");

            migrationBuilder.RenameColumn(
                name: "NhanSuTypeId",
                table: "ThongTinNguoiDungs",
                newName: "NhanSuTypeStxt");

            migrationBuilder.AddColumn<int>(
                name: "NhanSuType",
                table: "ThongTinNguoiDungs",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NhanSuType",
                table: "ThongTinNguoiDungs");

            migrationBuilder.RenameColumn(
                name: "NhanSuTypeStxt",
                table: "ThongTinNguoiDungs",
                newName: "NhanSuTypeId");

            migrationBuilder.CreateTable(
                name: "NhanSuTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MoTa = table.Column<string>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    TenLoaiNhanSu = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanSuTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinNguoiDungs_NhanSuTypeId",
                table: "ThongTinNguoiDungs",
                column: "NhanSuTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinNguoiDungs_NhanSuTypes_NhanSuTypeId",
                table: "ThongTinNguoiDungs",
                column: "NhanSuTypeId",
                principalTable: "NhanSuTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
