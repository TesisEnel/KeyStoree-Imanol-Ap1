using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KeyStore.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagenesSitio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clave = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ImagenData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TipoImagen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NombreArchivo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenesSitio", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "Precio" },
                values: new object[] { new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(611), 99.99m });

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "Precio" },
                values: new object[] { new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(864), 0.01m });

            migrationBuilder.InsertData(
                table: "ImagenesSitio",
                columns: new[] { "Id", "Activa", "Clave", "Descripcion", "FechaCreacion", "FechaModificacion", "ImagenData", "Nombre", "NombreArchivo", "TipoImagen" },
                values: new object[,]
                {
                    { 1, true, "hero-keyboard", "Imagen principal del hero que aparece en la página de inicio junto al título KEYSTORE", new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(2324), null, null, "Teclado Mecánico Principal - Hero", null, null },
                    { 2, true, "about-image", "Imagen de setup gaming que aparece en la sección About Us", new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(2530), null, null, "Setup Gaming - About Us", null, null },
                    { 3, true, "product-1", "Primera imagen de producto destacado en la sección featured", new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(2531), null, null, "Producto Destacado 1", null, null },
                    { 4, true, "product-2", "Segunda imagen de producto destacado en la sección featured", new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(2533), null, null, "Producto Destacado 2", null, null },
                    { 5, true, "product-3", "Tercera imagen de producto destacado en la sección featured", new DateTime(2025, 7, 27, 20, 51, 9, 196, DateTimeKind.Utc).AddTicks(2534), null, null, "Producto Destacado 3", null, null }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "ColorPrincipal", "Descripcion", "EsDestacado", "EsIluminado", "EsInalámbrico", "EsMecánico", "EsTemaPersonalizado", "ImagenUrl", "ImagenesSecundarias", "Layout", "Marca", "Modelo", "Nombre", "NombreTema", "Precio", "Stock", "TipoConexion", "TipoSwitch" },
                values: new object[] { 4, 4, "Rojo/Dorado", "Set de keycaps artesanales con diseño de dragón, perfectos para personalizar tu teclado mecánico.", true, false, false, false, true, "/images/dragon-keycaps.jpg", "[]", "Universal", "KeyStore", "ART-DRAGON-001", "Keycaps Artisan Dragon", "Dragon", 35.99m, 20, "USB_A", "Azul_Tactil" });

            migrationBuilder.CreateIndex(
                name: "IX_ImagenesSitio_Activa",
                table: "ImagenesSitio",
                column: "Activa");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenesSitio_Clave",
                table: "ImagenesSitio",
                column: "Clave",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagenesSitio");

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "FechaCreacion", "Precio" },
                values: new object[] { new DateTime(2025, 7, 27, 18, 50, 33, 627, DateTimeKind.Utc).AddTicks(2621), 0m });

            migrationBuilder.UpdateData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "FechaCreacion", "Precio" },
                values: new object[] { new DateTime(2025, 7, 27, 18, 50, 33, 627, DateTimeKind.Utc).AddTicks(2831), 0m });
        }
    }
}
