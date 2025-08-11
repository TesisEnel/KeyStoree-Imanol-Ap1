using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KeyStore.Migrations
{
    /// <inheritdoc />
    public partial class inicialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "EsActiva", "Nombre", "Orden" },
                values: new object[,]
                {
                    { 1, "Teclados gaming, mecánicos y RGB", true, "Teclados", 1 },
                    { 2, "Mouse gaming, inalámbricos y ergonómicos", true, "Mouse", 2 },
                    { 3, "Audífonos gaming, inalámbricos y con micrófono", true, "Audífonos", 3 }
                });

            migrationBuilder.InsertData(
                table: "ImagenesSitio",
                columns: new[] { "Id", "Activa", "Alto", "Ancho", "Clave", "Descripcion", "FechaCreacion", "FechaModificacion", "ImagenData", "Nombre", "NombreArchivo", "ObjectFit", "OcultarFondo", "TipoImagen" },
                values: new object[] { 1, true, null, null, "hero-keyboard", "Imagen principal del hero que aparece en la página de inicio", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Teclado Mecánico Principal - Hero", null, "cover", true, null });

            migrationBuilder.InsertData(
                table: "ImagenesSitio",
                columns: new[] { "Id", "Activa", "Alto", "Ancho", "Clave", "Descripcion", "FechaCreacion", "FechaModificacion", "ImagenData", "Nombre", "NombreArchivo", "ObjectFit", "TipoImagen" },
                values: new object[,]
                {
                    { 2, true, null, null, "about-image", "Imagen de setup gaming que aparece en la sección About Us", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Setup Gaming - About Us", null, "cover", null },
                    { 3, true, null, null, "product-1", "Primera imagen de producto destacado en la sección featured", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Producto Destacado 1", null, "cover", null }
                });
        }
    }
}
