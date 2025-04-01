using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanLuc.Migrations
{
    /// <inheritdoc />
    public partial class ThietKeCSDLV6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ThongTinNguoiDungs",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThongTinNguoiDungs_UserId",
                table: "ThongTinNguoiDungs",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ThongTinNguoiDungs_AspNetUsers_UserId",
                table: "ThongTinNguoiDungs",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThongTinNguoiDungs_AspNetUsers_UserId",
                table: "ThongTinNguoiDungs");

            migrationBuilder.DropIndex(
                name: "IX_ThongTinNguoiDungs_UserId",
                table: "ThongTinNguoiDungs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ThongTinNguoiDungs");
        }
    }
}
