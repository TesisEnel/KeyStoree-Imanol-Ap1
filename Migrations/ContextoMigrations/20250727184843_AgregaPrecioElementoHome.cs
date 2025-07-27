using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyStore.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class AgregaPrecioElementoHome : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Precio",
                table: "ElementosHome",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "Precio" },
                values: new object[] { new DateTime(2025, 7, 27, 18, 48, 42, 458, DateTimeKind.Utc).AddTicks(7190), 0m });

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "Precio" },
                values: new object[] { new DateTime(2025, 7, 27, 18, 48, 42, 458, DateTimeKind.Utc).AddTicks(7407), 0m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precio",
                table: "ElementosHome");

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 16, 59, 30, 475, DateTimeKind.Utc).AddTicks(2914));

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 16, 59, 30, 475, DateTimeKind.Utc).AddTicks(3125));
        }
    }
}
