using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PZ_1_tennis_court.Migrations
{
    /// <inheritdoc />
    public partial class AddPricingToBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PricingId",
                table: "Bookings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PricingId",
                table: "Bookings",
                column: "PricingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Pricings_PricingId",
                table: "Bookings",
                column: "PricingId",
                principalTable: "Pricings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Pricings_PricingId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_PricingId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PricingId",
                table: "Bookings");
        }
    }
}
