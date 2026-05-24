using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MotorON.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class KilometrajeNullableGasto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Kilometraje",
                table: "gastos_combustible",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Kilometraje",
                table: "gastos_combustible",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);
        }
    }
}
