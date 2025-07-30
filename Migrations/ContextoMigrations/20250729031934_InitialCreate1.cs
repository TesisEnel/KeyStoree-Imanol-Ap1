using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyStore.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(8901));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(9690));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(9692));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(9694));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(9695));
        }
    }
}
