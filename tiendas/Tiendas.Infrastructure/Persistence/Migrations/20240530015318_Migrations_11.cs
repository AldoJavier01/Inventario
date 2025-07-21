using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiendas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migrations_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticulosStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrlImgs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Tallas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdShein = table.Column<int>(type: "int", nullable: false),
                    SKU = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosStocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticulosVendidos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TiendaId = table.Column<long>(type: "bigint", nullable: false),
                    ArticuloId = table.Column<long>(type: "bigint", nullable: false),
                    Precio = table.Column<double>(type: "float", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreGestor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosVendidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticulosVentas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTienda = table.Column<long>(type: "bigint", nullable: false),
                    IdArticulo = table.Column<long>(type: "bigint", nullable: false),
                    PrecioDeCompra = table.Column<double>(type: "float", nullable: false),
                    PrecioVenta = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticulosVentas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiendasFisicas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiendasFisicas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticulosStocks");

            migrationBuilder.DropTable(
                name: "ArticulosVendidos");

            migrationBuilder.DropTable(
                name: "ArticulosVentas");

            migrationBuilder.DropTable(
                name: "TiendasFisicas");
        }
    }
}
