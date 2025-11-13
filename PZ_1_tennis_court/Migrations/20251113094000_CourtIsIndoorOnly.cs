using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PZ_1_tennis_court.Migrations
{
    /// <inheritdoc />
    public partial class CourtIsIndoorOnly : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Courts");

            migrationBuilder.AddColumn<bool>(
                name: "IsIndoor",
                table: "Courts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsIndoor",
                table: "Courts");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Courts",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
