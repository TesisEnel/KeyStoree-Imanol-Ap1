using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KeyStore.Migrations
{
    /// <inheritdoc />
    public partial class inicialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NombreCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DireccionesEnvio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Direccion2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ciudad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Provincia = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoPostal = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Pais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EsPrincipal = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Activa = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    FechaModificacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionesEnvio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DireccionesEnvio_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    NumeroOrden = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Estado = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CostoEnvio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DireccionEnvio = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CiudadEnvio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ProvinciaEnvio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodigoPostalEnvio = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    PaisEnvio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NombreDestinatario = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    TelefonoDestinatario = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    UltimosDigitosTarjeta = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    TipoTarjeta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FechaEnviado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaEntregado = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Notas = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pedidos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedidos_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tarjetas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    UltimosDigitos = table.Column<string>(type: "nchar(4)", fixedLength: true, maxLength: 4, nullable: false),
                    FechaVencimiento = table.Column<string>(type: "nchar(5)", fixedLength: true, maxLength: 5, nullable: false),
                    NombreTitular = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TipoTarjeta = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EsPrincipal = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Activa = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjetas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarjetas_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "DetallesPedidos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NombreProducto = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MarcaProducto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ImagenProducto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesPedidos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesPedidos_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesPedidos_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "IX_DetallesPedidos_PedidoId",
                table: "DetallesPedidos",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_DetallesPedidos_ProductoId",
                table: "DetallesPedidos",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesEnvio_UserId",
                table: "DireccionesEnvio",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesEnvio_UserId_Activa",
                table: "DireccionesEnvio",
                columns: new[] { "UserId", "Activa" });

            migrationBuilder.CreateIndex(
                name: "IX_DireccionesEnvio_UserId_EsPrincipal",
                table: "DireccionesEnvio",
                columns: new[] { "UserId", "EsPrincipal" });

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
                name: "IX_Pedidos_Estado",
                table: "Pedidos",
                column: "Estado");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FechaCreacion",
                table: "Pedidos",
                column: "FechaCreacion");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_NumeroOrden",
                table: "Pedidos",
                column: "NumeroOrden",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UserId",
                table: "Pedidos",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UserId_Estado",
                table: "Pedidos",
                columns: new[] { "UserId", "Estado" });

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_UsuarioId",
                table: "Pedidos",
                column: "UsuarioId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_UserId",
                table: "Tarjetas",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_UserId_Activa",
                table: "Tarjetas",
                columns: new[] { "UserId", "Activa" });

            migrationBuilder.CreateIndex(
                name: "IX_Tarjetas_UserId_EsPrincipal",
                table: "Tarjetas",
                columns: new[] { "UserId", "EsPrincipal" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DetallesPedidos");

            migrationBuilder.DropTable(
                name: "DireccionesEnvio");

            migrationBuilder.DropTable(
                name: "ElementosHome");

            migrationBuilder.DropTable(
                name: "ImagenesSitio");

            migrationBuilder.DropTable(
                name: "Tarjetas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
