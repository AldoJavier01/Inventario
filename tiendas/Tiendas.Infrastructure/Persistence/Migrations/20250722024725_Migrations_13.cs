using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiendas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migrations_13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecioDeCompra",
                table: "ArticulosVentas");

            migrationBuilder.DropColumn(
                name: "Tallas",
                table: "ArticulosStocks");

            migrationBuilder.AddColumn<string>(
                name: "Talla",
                table: "ArticulosVentas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "PrecioDeCompra",
                table: "ArticulosStocks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Talla",
                table: "ArticulosVentas");

            migrationBuilder.DropColumn(
                name: "PrecioDeCompra",
                table: "ArticulosStocks");

            migrationBuilder.AddColumn<double>(
                name: "PrecioDeCompra",
                table: "ArticulosVentas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Tallas",
                table: "ArticulosStocks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
