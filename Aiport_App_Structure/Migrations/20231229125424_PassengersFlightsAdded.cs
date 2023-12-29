using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aiport_App_Structure.Migrations
{
    /// <inheritdoc />
    public partial class PassengersFlightsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Passengers",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Passengers");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Passengers",
                newName: "Name");
        }
    }
}
