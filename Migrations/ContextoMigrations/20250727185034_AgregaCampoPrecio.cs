using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyStore.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class AgregaCampoPrecio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 18, 50, 33, 627, DateTimeKind.Utc).AddTicks(2621));

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 18, 50, 33, 627, DateTimeKind.Utc).AddTicks(2831));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 18, 48, 42, 458, DateTimeKind.Utc).AddTicks(7190));

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 18, 48, 42, 458, DateTimeKind.Utc).AddTicks(7407));
        }
    }
}
