using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SegundoParcialCarolina.Migrations
{
    /// <inheritdoc />
    public partial class MigracionInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Ventas",
                columns: table => new
                {
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Observacion = table.Column<string>(type: "TEXT", nullable: false),
                    Total = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ventas", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "VentasDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VentaId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentasDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_VentasDetalles_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentasDetalles_Ventas_VentaId",
                        column: x => x.VentaId,
                        principalTable: "Ventas",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "ProductoId", "Nombre", "Precio", "Stock" },
                values: new object[,]
                {
                    { 1, "Café Mocha", 150.0, 10 },
                    { 2, "Café Vainilla", 150.0, 10 },
                    { 3, "Café Caramelo", 160.0, 10 },
                    { 4, "Café Americano", 120.0, 10 },
                    { 5, "Café Latte", 140.0, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalles_ProductoId",
                table: "VentasDetalles",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_VentasDetalles_VentaId",
                table: "VentasDetalles",
                column: "VentaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VentasDetalles");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Ventas");
        }
    }
}
