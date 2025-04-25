using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestHotelBookingAPI.Migrations
{
    /// <inheritdoc />
    public partial class SlightChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Number",
                table: "Rooms",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Rooms",
                newName: "Number");
        }
    }
}
