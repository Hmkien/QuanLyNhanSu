using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNhanLuc.Migrations
{
    /// <inheritdoc />
    public partial class ThietLapCSDLV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isSuperAdmin",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isSuperAdmin",
                table: "AspNetUsers");
        }
    }
}
