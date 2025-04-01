using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanLuc.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTrangThaiToEnum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChamCongs_NhanSus_NhanSuId",
                table: "ChamCongs");

            migrationBuilder.DropForeignKey(
                name: "FK_LichLamThems_NhanSus_NhanSuId",
                table: "LichLamThems");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanSus_PhongBans_PhongBanId",
                table: "NhanSus");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetRoles");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "LichLamThems",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "TrangThai",
                table: "ChamCongs",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "GioVao",
                table: "ChamCongs",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "GioRa",
                table: "ChamCongs",
                type: "TEXT",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "ChamCongs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_PhongBans_MaPhongBan",
                table: "PhongBans",
                column: "MaPhongBan",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NhanSus_MaNhanVien",
                table: "NhanSus",
                column: "MaNhanVien",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChamCongs_NhanSus_NhanSuId",
                table: "ChamCongs",
                column: "NhanSuId",
                principalTable: "NhanSus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LichLamThems_NhanSus_NhanSuId",
                table: "LichLamThems",
                column: "NhanSuId",
                principalTable: "NhanSus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanSus_PhongBans_PhongBanId",
                table: "NhanSus",
                column: "PhongBanId",
                principalTable: "PhongBans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChamCongs_NhanSus_NhanSuId",
                table: "ChamCongs");

            migrationBuilder.DropForeignKey(
                name: "FK_LichLamThems_NhanSus_NhanSuId",
                table: "LichLamThems");

            migrationBuilder.DropForeignKey(
                name: "FK_NhanSus_PhongBans_PhongBanId",
                table: "NhanSus");

            migrationBuilder.DropIndex(
                name: "IX_PhongBans_MaPhongBan",
                table: "PhongBans");

            migrationBuilder.DropIndex(
                name: "IX_NhanSus_MaNhanVien",
                table: "NhanSus");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "LichLamThems",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "TrangThai",
                table: "ChamCongs",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "GioVao",
                table: "ChamCongs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "GioRa",
                table: "ChamCongs",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "GhiChu",
                table: "ChamCongs",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetRoles",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ChamCongs_NhanSus_NhanSuId",
                table: "ChamCongs",
                column: "NhanSuId",
                principalTable: "NhanSus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LichLamThems_NhanSus_NhanSuId",
                table: "LichLamThems",
                column: "NhanSuId",
                principalTable: "NhanSus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NhanSus_PhongBans_PhongBanId",
                table: "NhanSus",
                column: "PhongBanId",
                principalTable: "PhongBans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
