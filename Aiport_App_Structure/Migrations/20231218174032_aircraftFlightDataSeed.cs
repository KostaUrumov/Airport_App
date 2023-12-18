using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aiport_App_Structure.Migrations
{
    /// <inheritdoc />
    public partial class aircraftFlightDataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AircraftsFlights",
                columns: new[] { "AircraftId", "FlightId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AircraftsFlights",
                keyColumns: new[] { "AircraftId", "FlightId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AircraftsFlights",
                keyColumns: new[] { "AircraftId", "FlightId" },
                keyValues: new object[] { 2, 1 });
        }
    }
}
