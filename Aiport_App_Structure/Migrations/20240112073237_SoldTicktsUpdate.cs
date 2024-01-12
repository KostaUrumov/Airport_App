using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aiport_App_Structure.Migrations
{
    /// <inheritdoc />
    public partial class SoldTicktsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SoldTickets",
                table: "Flights",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                column: "SoldTickets",
                value: null);

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                column: "SoldTickets",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SoldTickets",
                table: "Flights");
        }
    }
}
