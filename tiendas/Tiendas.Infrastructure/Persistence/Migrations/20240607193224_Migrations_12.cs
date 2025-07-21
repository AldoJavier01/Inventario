using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiendas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migrations_12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreGestor",
                table: "ArticulosVentas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "ArticulosStocks",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreGestor",
                table: "ArticulosVentas");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "ArticulosStocks");
        }
    }
}
