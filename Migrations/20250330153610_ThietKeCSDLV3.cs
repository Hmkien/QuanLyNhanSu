using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanLuc.Migrations
{
    /// <inheritdoc />
    public partial class ThietKeCSDLV3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "DuongDan",
                table: "MenuQuanTris",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "ActionName",
                table: "MenuQuanTris",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "MenuQuanTris",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ControllerName",
                table: "MenuQuanTris",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActionName",
                table: "MenuQuanTris");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "MenuQuanTris");

            migrationBuilder.DropColumn(
                name: "ControllerName",
                table: "MenuQuanTris");

            migrationBuilder.AlterColumn<string>(
                name: "DuongDan",
                table: "MenuQuanTris",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
