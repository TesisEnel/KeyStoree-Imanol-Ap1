using KeyStore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace KeyStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ElementoHome> ElementosHome { get; set; }
        public DbSet<ImagenSitio> ImagenesSitio { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<DireccionEnvio> DireccionesEnvio { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetallePedido> DetallesPedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(1000);

                entity.Property(e => e.Precio)
                    .HasColumnType("decimal(18,2)")
                    .IsRequired();

                entity.Property(e => e.Stock)
                    .IsRequired();

                entity.Property(e => e.CategoriaId)
                    .IsRequired();

                entity.Property(e => e.ImagenUrl)
                    .HasMaxLength(500);

                entity.Property(e => e.Marca)
                    .HasMaxLength(100);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(100);

                entity.Property(e => e.Layout)
                    .HasMaxLength(50);

                entity.Property(e => e.ColorPrincipal)
                    .HasMaxLength(50);

                entity.Property(e => e.NombreTema)
                    .HasMaxLength(100);

                entity.Property(e => e.ImagenesSecundarias)
                    .HasConversion(
                        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
                        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>()
                    )
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.TipoConexion)
                    .HasConversion<string>()
                    .HasMaxLength(50);

                entity.Property(e => e.TipoSwitch)
                    .HasConversion<string>()
                    .HasMaxLength(50);

                entity.HasOne<Categoria>()
                    .WithMany()
                    .HasForeignKey(e => e.CategoriaId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasIndex(e => e.Nombre);
                entity.HasIndex(e => e.CategoriaId);
                entity.HasIndex(e => e.Marca);
                entity.HasIndex(e => e.EsDestacado);
                entity.HasIndex(e => e.Stock);
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(500);

                entity.Property(e => e.EsActiva)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.Property(e => e.Orden)
                    .IsRequired()
                    .HasDefaultValue(0);

                entity.HasIndex(e => e.Nombre)
                    .IsUnique();

                entity.HasIndex(e => e.EsActiva);
                entity.HasIndex(e => e.Orden);
            });

            modelBuilder.Entity<ElementoHome>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.TipoElemento).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Titulo).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Subtitulo).HasMaxLength(300);
                entity.Property(e => e.Descripcion).HasMaxLength(1000);
                entity.Property(e => e.UrlEnlace).HasMaxLength(500);
                entity.Property(e => e.TextoBoton).HasMaxLength(100);
                entity.Property(e => e.TipoImagen).HasMaxLength(100);
                entity.Property(e => e.NombreImagen).HasMaxLength(255);
                entity.Property(e => e.Precio).HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(e => e.FechaCreacion).IsRequired();
                entity.HasIndex(e => e.TipoElemento);
                entity.HasIndex(e => e.Activo);
                entity.HasIndex(e => e.Orden);
            });

            modelBuilder.Entity<ImagenSitio>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Clave).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Descripcion).HasMaxLength(500);
                entity.Property(e => e.TipoImagen).HasMaxLength(100);
                entity.Property(e => e.NombreArchivo).HasMaxLength(255);
                entity.Property(e => e.FechaCreacion).IsRequired();

                entity.Property(e => e.Ancho).HasColumnName("Ancho");
                entity.Property(e => e.Alto).HasColumnName("Alto");
                entity.Property(e => e.ObjectFit).HasMaxLength(50).HasDefaultValue("cover");
                entity.Property(e => e.OcultarFondo).HasDefaultValue(false);

                entity.HasIndex(e => e.Clave).IsUnique();
                entity.HasIndex(e => e.Activa);
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450); // Tamaño estándar para UserId de Identity

                entity.Property(e => e.UltimosDigitos)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsFixedLength();

                entity.Property(e => e.FechaVencimiento)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.NombreTitular)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TipoTarjeta)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.EsPrincipal)
                    .IsRequired()
                    .HasDefaultValue(false);

                entity.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.Activa)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => new { e.UserId, e.Activa });
                entity.HasIndex(e => new { e.UserId, e.EsPrincipal });

                entity.HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Ignore(e => e.NumeroTarjeta);
                entity.Ignore(e => e.CVV);
            });

            modelBuilder.Entity<DireccionEnvio>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Direccion2)
                    .HasMaxLength(100);

                entity.Property(e => e.Ciudad)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Provincia)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CodigoPostal)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Pais)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20);

                entity.Property(e => e.EsPrincipal)
                    .IsRequired()
                    .HasDefaultValue(false);

                entity.Property(e => e.Activa)
                    .IsRequired()
                    .HasDefaultValue(true);

                entity.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.FechaModificacion);

                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => new { e.UserId, e.Activa });
                entity.HasIndex(e => new { e.UserId, e.EsPrincipal });

                entity.HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(450);

                entity.Property(e => e.NumeroOrden)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.FechaCreacion)
                    .IsRequired()
                    .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasConversion<int>()
                    .HasDefaultValue(EstadoPedido.Procesando);

                entity.Property(e => e.Subtotal)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.CostoEnvio)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.Total)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.MetodoPago)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DireccionEnvio)
                    .HasMaxLength(200);

                entity.Property(e => e.CiudadEnvio)
                    .HasMaxLength(100);

                entity.Property(e => e.ProvinciaEnvio)
                    .HasMaxLength(100);

                entity.Property(e => e.CodigoPostalEnvio)
                    .HasMaxLength(20);

                entity.Property(e => e.PaisEnvio)
                    .HasMaxLength(100);

                entity.Property(e => e.NombreDestinatario)
                    .HasMaxLength(200);

                entity.Property(e => e.TelefonoDestinatario)
                    .HasMaxLength(20);

                entity.Property(e => e.UltimosDigitosTarjeta)
                    .HasMaxLength(4);

                entity.Property(e => e.TipoTarjeta)
                    .HasMaxLength(20);

                entity.Property(e => e.Notas)
                    .HasMaxLength(500);

                entity.HasIndex(e => e.UserId);
                entity.HasIndex(e => e.NumeroOrden).IsUnique();
                entity.HasIndex(e => e.Estado);
                entity.HasIndex(e => e.FechaCreacion);
                entity.HasIndex(e => new { e.UserId, e.Estado });
                entity.HasOne<ApplicationUser>()
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.Detalles)
                    .WithOne(d => d.Pedido)
                    .HasForeignKey(d => d.PedidoId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.PedidoId)
                    .IsRequired();

                entity.Property(e => e.ProductoId)
                    .IsRequired();

                entity.Property(e => e.Cantidad)
                    .IsRequired();

                entity.Property(e => e.PrecioUnitario)
                    .IsRequired()
                    .HasColumnType("decimal(18,2)");

                entity.Property(e => e.NombreProducto)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.MarcaProducto)
                    .HasMaxLength(100);

                entity.Property(e => e.ImagenProducto)
                    .HasMaxLength(500);

                entity.HasIndex(e => e.PedidoId);
                entity.HasIndex(e => e.ProductoId);

                entity.HasOne(e => e.Producto)
                    .WithMany()
                    .HasForeignKey(e => e.ProductoId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    Id = 1,
                    Nombre = "Teclados",
                    Descripcion = "Teclados gaming, mecánicos y RGB",
                    EsActiva = true,
                    Orden = 1
                },
                new Categoria
                {
                    Id = 2,
                    Nombre = "Mouse",
                    Descripcion = "Mouse gaming, inalámbricos y ergonómicos",
                    EsActiva = true,
                    Orden = 2
                },
                new Categoria
                {
                    Id = 3,
                    Nombre = "Audífonos",
                    Descripcion = "Audífonos gaming, inalámbricos y con micrófono",
                    EsActiva = true,
                    Orden = 3
                }
            );

            modelBuilder.Entity<ImagenSitio>().HasData(
                new ImagenSitio
                {
                    Id = 1,
                    Clave = "hero-keyboard",
                    Nombre = "Teclado Mecánico Principal - Hero",
                    Descripcion = "Imagen principal del hero que aparece en la página de inicio",
                    Activa = true,
                    FechaCreacion = new DateTime(2023, 1, 1),
                    ObjectFit = "cover",
                    OcultarFondo = true
                },
                new ImagenSitio
                {
                    Id = 2,
                    Clave = "about-image",
                    Nombre = "Setup Gaming - About Us",
                    Descripcion = "Imagen de setup gaming que aparece en la sección About Us",
                    Activa = true,
                    FechaCreacion = new DateTime(2023, 1, 1),
                    ObjectFit = "cover",
                    OcultarFondo = false
                },
                new ImagenSitio
                {
                    Id = 3,
                    Clave = "product-1",
                    Nombre = "Producto Destacado 1",
                    Descripcion = "Primera imagen de producto destacado en la sección featured",
                    Activa = true,
                    FechaCreacion = new DateTime(2023, 1, 1),
                    ObjectFit = "cover",
                    OcultarFondo = false
                }
            );
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);

            configurationBuilder
                .Properties<TipoConexion>()
                .HaveConversion<string>();

            configurationBuilder
                .Properties<TipoSwitch>()
                .HaveConversion<string>();
        }
    }
}