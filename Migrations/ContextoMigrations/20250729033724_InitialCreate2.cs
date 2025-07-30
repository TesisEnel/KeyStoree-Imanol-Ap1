using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KeyStore.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ElementosHome",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Productos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Teclados gaming, mecánicos y RGB", "Teclados" });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Mouse gaming, inalámbricos y ergonómicos", "Mouse" });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Audífonos gaming, inalámbricos y con micrófono", "Audífonos" });

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: "Imagen principal del hero que aparece en la página de inicio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Teclados con iluminación RGB personalizable", "Teclados RGB" });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Teclados mecánicos de alta calidad", "Teclados Mecánicos" });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descripcion", "Nombre" },
                values: new object[] { "Keycaps y temas únicos para personalizar tu teclado", "Temas Personalizados" });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "EsActiva", "Nombre", "Orden" },
                values: new object[] { 4, "Accesorios y complementos para teclados", true, "Accesorios", 4 });

            migrationBuilder.InsertData(
                table: "ElementosHome",
                columns: new[] { "Id", "Activo", "Descripcion", "FechaCreacion", "FechaModificacion", "ImagenData", "NombreImagen", "Orden", "Precio", "Subtitulo", "TextoBoton", "TipoElemento", "TipoImagen", "Titulo", "UrlEnlace" },
                values: new object[,]
                {
                    { 1, true, "Descubre nuestra colección exclusiva de teclados mecánicos, temas personalizados y accesorios premium para elevar tu experiencia de escritura y gaming.", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 1, 99.99m, "Teclados Personalizados de Alta Calidad", "Comprar Ahora", "Hero", null, "KEYSTORE", "/productos" },
                    { 2, true, "Nuestra misión es brindar experiencias de teclado personalizadas para todos. Conoce más sobre nuestro viaje y nuestra dedicación a la calidad e innovación.", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 10, 0.01m, "Nuestra Pasión por los Teclados", "Learn more", "SeccionAbout", null, "About Us", "/about" }
                });

            migrationBuilder.UpdateData(
                table: "ImagenesSitio",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: "Imagen principal del hero que aparece en la página de inicio junto al título KEYSTORE");

            migrationBuilder.InsertData(
                table: "ImagenesSitio",
                columns: new[] { "Id", "Activa", "Alto", "Ancho", "Clave", "Descripcion", "FechaCreacion", "FechaModificacion", "ImagenData", "Nombre", "NombreArchivo", "ObjectFit", "TipoImagen" },
                values: new object[,]
                {
                    { 4, true, null, null, "product-2", "Segunda imagen de producto destacado en la sección featured", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Producto Destacado 2", null, "cover", null },
                    { 5, true, null, null, "product-3", "Tercera imagen de producto destacado en la sección featured", new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Producto Destacado 3", null, "cover", null }
                });

            migrationBuilder.InsertData(
                table: "Productos",
                columns: new[] { "Id", "CategoriaId", "ColorPrincipal", "Descripcion", "EsDestacado", "EsIluminado", "EsInalámbrico", "EsMecánico", "EsTemaPersonalizado", "ImagenUrl", "ImagenesSecundarias", "Layout", "Marca", "Modelo", "Nombre", "NombreTema", "Precio", "Stock", "TipoConexion", "TipoSwitch" },
                values: new object[,]
                {
                    { 1, 1, "Negro", "Teclado mecánico profesional con switches Cherry MX Red y retroiluminación RGB completa. Perfecto para gaming y trabajo.", true, true, false, true, false, "/images/keyboard-rgb-1.jpg", "[]", "Español", "KeyStore", "RGB-PRO-001", "Teclado RGB Gaming Pro", "", 89.99m, 15, "USB_C", "Rojo_Linear" },
                    { 2, 3, "Amarillo/Negro", "Set completo de keycaps inspirado en el universo de Cyberpunk 2077. Incluye teclas especiales y colores únicos.", true, false, false, false, true, "/images/cyberpunk-theme.jpg", "[]", "Universal", "KeyStore", "THEME-CP77", "Tema Cyberpunk 2077", "Cyberpunk", 45.99m, 8, "USB_A", "Azul_Tactil" },
                    { 3, 2, "Blanco", "Teclado mecánico inalámbrico premium con conexión Bluetooth 5.0 y batería de larga duración.", false, true, true, true, false, "/images/wireless-mechanical.jpg", "[]", "Internacional", "KeyStore", "WRL-ELITE-001", "Teclado Mecánico Wireless Elite", "", 125.99m, 12, "Bluetooth", "Marron_Tactil_Silencioso" },
                    { 4, 4, "Rojo/Dorado", "Set de keycaps artesanales con diseño de dragón, perfectos para personalizar tu teclado mecánico.", true, false, false, false, true, "/images/dragon-keycaps.jpg", "[]", "Universal", "KeyStore", "ART-DRAGON-001", "Keycaps Artisan Dragon", "Dragon", 35.99m, 20, "USB_A", "Azul_Tactil" }
                });
        }
    }
}
