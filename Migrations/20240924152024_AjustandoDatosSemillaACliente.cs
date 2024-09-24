using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backNegocio.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoDatosSemillaACliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CodigoPostal", "Localidad", "Provincia", "cuitDni" },
                values: new object[] { "3040", "San Justo", "Santa Fe", "25730663" });

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CodigoPostal", "Localidad", "Provincia", "cuitDni" },
                values: new object[] { "3048", "Videla", "Santa Fe", "33258369" });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "id",
                keyValue: 2,
                column: "apellidoNombre",
                value: "Cantero Maria");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id",
                keyValue: 1,
                column: "stock",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id",
                keyValue: 2,
                column: "stock",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id",
                keyValue: 3,
                column: "stock",
                value: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "CodigoPostal", "Localidad", "Provincia", "cuitDni" },
                values: new object[] { "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Cliente",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "CodigoPostal", "Localidad", "Provincia", "cuitDni" },
                values: new object[] { "", "", "", "" });

            migrationBuilder.UpdateData(
                table: "Empleado",
                keyColumn: "id",
                keyValue: 2,
                column: "apellidoNombre",
                value: "Perez Maria");

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id",
                keyValue: 1,
                column: "stock",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id",
                keyValue: 2,
                column: "stock",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Producto",
                keyColumn: "id",
                keyValue: 3,
                column: "stock",
                value: 0);
        }
    }
}
