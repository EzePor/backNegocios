using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backNegocio.Migrations
{
    /// <inheritdoc />
    public partial class AgregarDatoSemillaCuitODniACliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "id",
                keyValue: 1,
                column: "cuitDni",
                value: "25730663");

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "id",
                keyValue: 2,
                column: "cuitDni",
                value: "33698544");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "id",
                keyValue: 1,
                column: "cuitDni",
                value: "");

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "id",
                keyValue: 2,
                column: "cuitDni",
                value: "");
        }
    }
}
