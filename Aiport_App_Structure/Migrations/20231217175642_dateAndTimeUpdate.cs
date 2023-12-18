using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aiport_App_Structure.Migrations
{
    /// <inheritdoc />
    public partial class dateAndTimeUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ArivalTime",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureTime",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ArivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 1, 12, 11, 3, 52, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 12, 8, 30, 52, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ArivalTime", "DepartureTime" },
                values: new object[] { new DateTime(2024, 1, 13, 4, 22, 52, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 12, 8, 30, 52, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArivalTime",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "DepartureTime",
                table: "Flights");
        }
    }
}
