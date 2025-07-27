using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyStore.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class AgregarTablaImagenSitio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 55, 58, 368, DateTimeKind.Utc).AddTicks(3748));

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 55, 58, 368, DateTimeKind.Utc).AddTicks(4014));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 55, 58, 368, DateTimeKind.Utc).AddTicks(5549));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 55, 58, 368, DateTimeKind.Utc).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 55, 58, 368, DateTimeKind.Utc).AddTicks(5767));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 55, 58, 368, DateTimeKind.Utc).AddTicks(5771));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 55, 58, 368, DateTimeKind.Utc).AddTicks(5772));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(611));

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(2530));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(2531));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(2533));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(2534));
        }
    }
}
