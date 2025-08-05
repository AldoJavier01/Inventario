using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tiendas.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migrations_14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Cantidad",
                table: "ArticulosVentas",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "ArticulosVentas");
        }
    }
}
