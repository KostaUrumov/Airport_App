using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Aiport_App_Structure.Migrations
{
    /// <inheritdoc />
    public partial class seedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Continent", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Germany" },
                    { 2, 2, "Australia" },
                    { 3, 3, "USA" },
                    { 4, 1, "France" },
                    { 5, 5, "Egypt" },
                    { 6, 6, "Japan" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Berlin" },
                    { 2, 2, "Sydney" },
                    { 3, 3, "Los Angeles" },
                    { 4, 4, "Paris" },
                    { 5, 5, "Cairo" },
                    { 6, 6, "Tokyo" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 3, "Boeing" },
                    { 2, 4, "Airbus" }
                });

            migrationBuilder.InsertData(
                table: "Aircrafts",
                columns: new[] { "Id", "Capacity", "ManufacturerId", "Model" },
                values: new object[,]
                {
                    { 1, 257, 1, "737" },
                    { 2, 164, 2, "A 330" }
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "AirportCode", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "BER", 1, "Berlin International Airport" },
                    { 2, "LAX", 3, "Los Angeles International Airport" },
                    { 3, "ORY", 4, "Paris-Orly Airport" },
                    { 4, "HND", 6, "Haneda Airport" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AircraftId", "ArrivalAirportId", "DepartureAirportId", "FlightNumber", "Price", "TotalTickets" },
                values: new object[,]
                {
                    { 1, 2, 3, 1, "BO78P0", 87.21m, 164 },
                    { 2, 1, 2, 1, "LAU781", 887.21m, 251 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Aircrafts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Manufacturers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
