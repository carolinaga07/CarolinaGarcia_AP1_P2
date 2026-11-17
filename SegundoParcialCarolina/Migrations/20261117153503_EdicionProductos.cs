using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SegundoParcialCarolina.Migrations
{
    /// <inheritdoc />
    public partial class EdicionProductos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1,
                column: "Nombre",
                value: "Starbucks Mocha");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "Nombre",
                value: "Starbucks Vainilla");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "Nombre",
                value: "Starbucks Caramelo");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 4,
                column: "Nombre",
                value: "Starbucks Americano");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 5,
                column: "Nombre",
                value: "Starbucks Latte");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 1,
                column: "Nombre",
                value: "Café Mocha");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 2,
                column: "Nombre",
                value: "Café Vainilla");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 3,
                column: "Nombre",
                value: "Café Caramelo");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 4,
                column: "Nombre",
                value: "Café Americano");

            migrationBuilder.UpdateData(
                table: "Productos",
                keyColumn: "ProductoId",
                keyValue: 5,
                column: "Nombre",
                value: "Café Latte");
        }
    }
}
