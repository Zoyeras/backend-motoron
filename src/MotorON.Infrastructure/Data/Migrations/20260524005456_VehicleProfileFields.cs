using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorON.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class VehicleProfileFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cilindraje",
                table: "vehicles",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "vehicles",
                type: "character varying(60)",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumeroSerie",
                table: "vehicles",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Placa",
                table: "vehicles",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_Placa",
                table: "vehicles",
                column: "Placa",
                unique: true,
                filter: "\"Placa\" IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vehicles_Placa",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "Cilindraje",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "NumeroSerie",
                table: "vehicles");

            migrationBuilder.DropColumn(
                name: "Placa",
                table: "vehicles");
        }
    }
}
