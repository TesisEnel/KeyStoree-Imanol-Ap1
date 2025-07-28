using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyStore.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class AgregarPropiedadesImagenSitio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Alto",
                table: "ImagenesSitio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Ancho",
                table: "ImagenesSitio",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ObjectFit",
                table: "ImagenesSitio",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "cover");

            migrationBuilder.AddColumn<bool>(
                name: "OcultarFondo",
                table: "ImagenesSitio",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 28, 3, 5, 17, 367, DateTimeKind.Utc).AddTicks(3816));

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2025, 7, 28, 3, 5, 17, 367, DateTimeKind.Utc).AddTicks(4084));

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Alto", "Ancho", "FechaCreacion", "ObjectFit", "OcultarFondo" },
                values: new object[] { null, null, new DateTime(2025, 7, 28, 3, 5, 17, 367, DateTimeKind.Utc).AddTicks(5568), "cover", true });

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Alto", "Ancho", "FechaCreacion", "ObjectFit" },
                values: new object[] { null, null, new DateTime(2025, 7, 28, 3, 5, 17, 367, DateTimeKind.Utc).AddTicks(6142), "cover" });

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Alto", "Ancho", "FechaCreacion", "ObjectFit" },
                values: new object[] { null, null, new DateTime(2025, 7, 28, 3, 5, 17, 367, DateTimeKind.Utc).AddTicks(6144), "cover" });

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Alto", "Ancho", "FechaCreacion", "ObjectFit" },
                values: new object[] { null, null, new DateTime(2025, 7, 28, 3, 5, 17, 367, DateTimeKind.Utc).AddTicks(6145), "cover" });

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Alto", "Ancho", "FechaCreacion", "ObjectFit" },
                values: new object[] { null, null, new DateTime(2025, 7, 28, 3, 5, 17, 367, DateTimeKind.Utc).AddTicks(6147), "cover" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Alto",
                table: "ImagenesSitio");

            migrationBuilder.DropColumn(
                name: "Ancho",
                table: "ImagenesSitio");

            migrationBuilder.DropColumn(
                name: "ObjectFit",
                table: "ImagenesSitio");

            migrationBuilder.DropColumn(
                name: "OcultarFondo",
                table: "ImagenesSitio");

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
    }
}
