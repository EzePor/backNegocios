using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backNegocio.Migrations
{
    /// <inheritdoc />
    public partial class inicioproyecto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    apellidoNombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    direccion = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    telefono = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Localidad = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodigoPostal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Provincia = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    apellidoNombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dni = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Impresion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tamanio = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    precioBase = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    descuento10 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    descuento20 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    descuento50 = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impresion", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ModoPago",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ajuste = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModoPago", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nombre = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rubro = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    user = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoUsuario = table.Column<int>(type: "int", nullable: true),
                    eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClienteId = table.Column<int>(type: "int", nullable: false),
                    fechaPedido = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ModoPagoId = table.Column<int>(type: "int", nullable: false),
                    estadoPedido = table.Column<int>(type: "int", nullable: false),
                    FuePagado = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pedido_ModoPago_ModoPagoId",
                        column: x => x.ModoPagoId,
                        principalTable: "ModoPago",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetalleImpresion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ImpresionId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleImpresion", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetalleImpresion_Impresion_ImpresionId",
                        column: x => x.ImpresionId,
                        principalTable: "Impresion",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleImpresion_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetallePedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    cantidad = table.Column<int>(type: "int", nullable: false),
                    precioUnitario = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    eliminado = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallePedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Pedido_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallePedido_Producto_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Producto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Cliente",
                columns: new[] { "id", "CodigoPostal", "Localidad", "Provincia", "apellidoNombre", "direccion", "eliminado", "email", "telefono" },
                values: new object[,]
                {
                    { 1, "", "", "", "Porchietto Ezequiel Gustavo", " Juan Mantovani 1877", false, "ezeporche@gmail.com", "3498 431264" },
                    { 2, "", "", "", "Perez Camila", "Calle 31 324 ", false, "camiperez@gamil.com", "3498 452385" }
                });

            migrationBuilder.InsertData(
                table: "Empleado",
                columns: new[] { "id", "apellidoNombre", "dni", "eliminado" },
                values: new object[,]
                {
                    { 1, "Gomez Juan", "12345678", false },
                    { 2, "Perez Maria", "87654321", false }
                });

            migrationBuilder.InsertData(
                table: "Impresion",
                columns: new[] { "id", "descuento10", "descuento20", "descuento50", "eliminado", "precioBase", "tamanio" },
                values: new object[,]
                {
                    { 1, 0.10m, 0.20m, 0.50m, false, 800m, "7x10" },
                    { 2, 0.10m, 0.20m, 0.50m, false, 1000m, "10x15" },
                    { 3, 0.10m, 0.20m, 0.50m, false, 1500m, "13x18" },
                    { 4, 0.10m, 0.20m, 0.50m, false, 2000m, "15x21" }
                });

            migrationBuilder.InsertData(
                table: "ModoPago",
                columns: new[] { "id", "ajuste", "eliminado", "nombre" },
                values: new object[,]
                {
                    { 1, -0.5m, false, "efectivo" },
                    { 2, 0m, false, "débito" },
                    { 3, 0m, false, "crédito" },
                    { 4, -0.5m, false, "transferencia" }
                });

            migrationBuilder.InsertData(
                table: "Producto",
                columns: new[] { "id", "Rubro", "eliminado", "nombre", "precio", "stock" },
                values: new object[,]
                {
                    { 1, 4, false, "Auricular inalámbrico F9", 13500m, 0 },
                    { 2, 0, false, "Album 200F 13x18 New Album", 17900m, 0 },
                    { 3, 3, false, "Reloj Digital Dakot 1845", 22300m, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleImpresion_ImpresionId",
                table: "DetalleImpresion",
                column: "ImpresionId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleImpresion_PedidoId",
                table: "DetalleImpresion",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_PedidoId",
                table: "DetallePedido",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallePedido_ProductoId",
                table: "DetallePedido",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ModoPagoId",
                table: "Pedido",
                column: "ModoPagoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleImpresion");

            migrationBuilder.DropTable(
                name: "DetallePedido");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Impresion");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "ModoPago");
        }
    }
}
