using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorON.Api.src.MotorON.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "gastos_combustible",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Litros = table.Column<decimal>(type: "numeric(12,3)", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    Kilometraje = table.Column<int>(type: "integer", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gastos_combustible", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "mantenimientos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Tipo = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    Kilometraje = table.Column<int>(type: "integer", nullable: false),
                    Fecha = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Costo = table.Column<decimal>(type: "numeric(12,2)", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mantenimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "vehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Model = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "integer", nullable: false),
                    CurrentMileage = table.Column<int>(type: "integer", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_gastos_combustible_Fecha",
                table: "gastos_combustible",
                column: "Fecha");

            migrationBuilder.CreateIndex(
                name: "IX_gastos_combustible_Kilometraje",
                table: "gastos_combustible",
                column: "Kilometraje");

            migrationBuilder.CreateIndex(
                name: "IX_mantenimientos_Fecha",
                table: "mantenimientos",
                column: "Fecha");

            migrationBuilder.CreateIndex(
                name: "IX_mantenimientos_Kilometraje",
                table: "mantenimientos",
                column: "Kilometraje");

            migrationBuilder.CreateIndex(
                name: "IX_vehicles_Brand_Model",
                table: "vehicles",
                columns: new[] { "Brand", "Model" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "gastos_combustible");

            migrationBuilder.DropTable(
                name: "mantenimientos");

            migrationBuilder.DropTable(
                name: "vehicles");
        }
    }
}
