using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KeyStore.Migrations.ContextoMigrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EsActiva = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Orden = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ElementosHome",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoElemento = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Subtitulo = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UrlEnlace = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TextoBoton = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Orden = table.Column<int>(type: "int", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImagenData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    TipoImagen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NombreImagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElementosHome", x => x.Id);
                });

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
                    Ancho = table.Column<int>(type: "int", nullable: true),
                    Alto = table.Column<int>(type: "int", nullable: true),
                    ObjectFit = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, defaultValue: "cover"),
                    OcultarFondo = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagenesSitio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    ImagenUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ImagenesSecundarias = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Layout = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EsIluminado = table.Column<bool>(type: "bit", nullable: false),
                    EsInalámbrico = table.Column<bool>(type: "bit", nullable: false),
                    EsMecánico = table.Column<bool>(type: "bit", nullable: false),
                    ColorPrincipal = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    EsTemaPersonalizado = table.Column<bool>(type: "bit", nullable: false),
                    NombreTema = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EsDestacado = table.Column<bool>(type: "bit", nullable: false),
                    TipoConexion = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoSwitch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "Descripcion", "EsActiva", "Nombre", "Orden" },
                values: new object[,]
                {
                    { 1, "Teclados con iluminación RGB personalizable", true, "Teclados RGB", 1 },
                    { 2, "Teclados mecánicos de alta calidad", true, "Teclados Mecánicos", 2 },
                    { 3, "Keycaps y temas únicos para personalizar tu teclado", true, "Temas Personalizados", 3 },
                    { 4, "Accesorios y complementos para teclados", true, "Accesorios", 4 }
                });

            migrationBuilder.InsertData(
                table: "ElementosHome",
                columns: new[] { "Id", "Activo", "Descripcion", "FechaCreacion", "FechaModificacion", "ImagenData", "NombreImagen", "Orden", "Precio", "Subtitulo", "TextoBoton", "TipoElemento", "TipoImagen", "Titulo", "UrlEnlace" },
                values: new object[,]
                {
                    { 1, true, "Descubre nuestra colección exclusiva de teclados mecánicos, temas personalizados y accesorios premium para elevar tu experiencia de escritura y gaming.", new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(6264), null, null, null, 1, 99.99m, "Teclados Personalizados de Alta Calidad", "Comprar Ahora", "Hero", null, "KEYSTORE", "/productos" },
                    { 2, true, "Nuestra misión es brindar experiencias de teclado personalizadas para todos. Conoce más sobre nuestro viaje y nuestra dedicación a la calidad e innovación.", new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(6468), null, null, null, 10, 0.01m, "Nuestra Pasión por los Teclados", "Learn more", "SeccionAbout", null, "About Us", "/about" }
                });

            migrationBuilder.InsertData(
                table: "ImagenesSitio",
                columns: new[] { "Id", "Activa", "Alto", "Ancho", "Clave", "Descripcion", "FechaCreacion", "FechaModificacion", "ImagenData", "Nombre", "NombreArchivo", "ObjectFit", "OcultarFondo", "TipoImagen" },
                values: new object[] { 1, true, null, null, "hero-keyboard", "Imagen principal del hero que aparece en la página de inicio junto al título KEYSTORE", new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(8901), null, null, "Teclado Mecánico Principal - Hero", null, "cover", true, null });

            migrationBuilder.InsertData(
                table: "ImagenesSitio",
                columns: new[] { "Id", "Activa", "Alto", "Ancho", "Clave", "Descripcion", "FechaCreacion", "FechaModificacion", "ImagenData", "Nombre", "NombreArchivo", "ObjectFit", "TipoImagen" },
                values: new object[,]
                {
                    { 2, true, null, null, "about-image", "Imagen de setup gaming que aparece en la sección About Us", new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(9690), null, null, "Setup Gaming - About Us", null, "cover", null },
                    { 3, true, null, null, "product-1", "Primera imagen de producto destacado en la sección featured", new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(9692), null, null, "Producto Destacado 1", null, "cover", null },
                    { 4, true, null, null, "product-2", "Segunda imagen de producto destacado en la sección featured", new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(9694), null, null, "Producto Destacado 2", null, "cover", null },
                    { 5, true, null, null, "product-3", "Tercera imagen de producto destacado en la sección featured", new DateTime(2025, 7, 29, 3, 12, 37, 277, DateTimeKind.Utc).AddTicks(9695), null, null, "Producto Destacado 3", null, "cover", null }
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

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_EsActiva",
                table: "Categorias",
                column: "EsActiva");

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Nombre",
                table: "Categorias",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categorias_Orden",
                table: "Categorias",
                column: "Orden");

            migrationBuilder.CreateIndex(
                name: "IX_ElementosHome_Activo",
                table: "ElementosHome",
                column: "Activo");

            migrationBuilder.CreateIndex(
                name: "IX_ElementosHome_Orden",
                table: "ElementosHome",
                column: "Orden");

            migrationBuilder.CreateIndex(
                name: "IX_ElementosHome_TipoElemento",
                table: "ElementosHome",
                column: "TipoElemento");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenesSitio_Activa",
                table: "ImagenesSitio",
                column: "Activa");

            migrationBuilder.CreateIndex(
                name: "IX_ImagenesSitio_Clave",
                table: "ImagenesSitio",
                column: "Clave",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Productos_CategoriaId",
                table: "Productos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_EsDestacado",
                table: "Productos",
                column: "EsDestacado");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Marca",
                table: "Productos",
                column: "Marca");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Nombre",
                table: "Productos",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_Stock",
                table: "Productos",
                column: "Stock");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElementosHome");

            migrationBuilder.DropTable(
                name: "ImagenesSitio");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
