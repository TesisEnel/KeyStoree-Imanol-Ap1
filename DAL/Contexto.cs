using Microsoft.EntityFrameworkCore;
using KeyStore.Models;
using System.Text.Json;

namespace KeyStore.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ElementoHome> ElementosHome { get; set; }
        public DbSet<ImagenSitio> ImagenesSitio { get; set; }


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

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria
                {
                    Id = 1,
                    Nombre = "Teclados RGB",
                    Descripcion = "Teclados con iluminación RGB personalizable",
                    EsActiva = true,
                    Orden = 1
                },
                new Categoria
                {
                    Id = 2,
                    Nombre = "Teclados Mecánicos",
                    Descripcion = "Teclados mecánicos de alta calidad",
                    EsActiva = true,
                    Orden = 2
                },
                new Categoria
                {
                    Id = 3,
                    Nombre = "Temas Personalizados",
                    Descripcion = "Keycaps y temas únicos para personalizar tu teclado",
                    EsActiva = true,
                    Orden = 3
                },
                new Categoria
                {
                    Id = 4,
                    Nombre = "Accesorios",
                    Descripcion = "Accesorios y complementos para teclados",
                    EsActiva = true,
                    Orden = 4
                }
            );

            modelBuilder.Entity<Producto>().HasData(
                new Producto
                {
                    Id = 1,
                    Nombre = "Teclado RGB Gaming Pro",
                    Descripcion = "Teclado mecánico profesional con switches Cherry MX Red y retroiluminación RGB completa. Perfecto para gaming y trabajo.",
                    Precio = 89.99m,
                    Stock = 15,
                    CategoriaId = 1,
                    ImagenUrl = "/images/keyboard-rgb-1.jpg",
                    Marca = "KeyStore",
                    Modelo = "RGB-PRO-001",
                    Layout = "Español",
                    EsIluminado = true,
                    EsInalámbrico = false,
                    EsMecánico = true,
                    ColorPrincipal = "Negro",
                    EsTemaPersonalizado = false,
                    NombreTema = "",
                    EsDestacado = true,
                    TipoConexion = TipoConexion.USB_C,
                    TipoSwitch = TipoSwitch.Rojo_Linear
                },
                new Producto
                {
                    Id = 2,
                    Nombre = "Tema Cyberpunk 2077",
                    Descripcion = "Set completo de keycaps inspirado en el universo de Cyberpunk 2077. Incluye teclas especiales y colores únicos.",
                    Precio = 45.99m,
                    Stock = 8,
                    CategoriaId = 3,
                    ImagenUrl = "/images/cyberpunk-theme.jpg",
                    Marca = "KeyStore",
                    Modelo = "THEME-CP77",
                    Layout = "Universal",
                    EsIluminado = false,
                    EsInalámbrico = false,
                    EsMecánico = false,
                    ColorPrincipal = "Amarillo/Negro",
                    EsTemaPersonalizado = true,
                    NombreTema = "Cyberpunk",
                    EsDestacado = true,
                    TipoConexion = TipoConexion.USB_A,
                    TipoSwitch = TipoSwitch.Azul_Tactil
                },
                new Producto
                {
                    Id = 3,
                    Nombre = "Teclado Mecánico Wireless Elite",
                    Descripcion = "Teclado mecánico inalámbrico premium con conexión Bluetooth 5.0 y batería de larga duración.",
                    Precio = 125.99m,
                    Stock = 12,
                    CategoriaId = 2,
                    ImagenUrl = "/images/wireless-mechanical.jpg",
                    Marca = "KeyStore",
                    Modelo = "WRL-ELITE-001",
                    Layout = "Internacional",
                    EsIluminado = true,
                    EsInalámbrico = true,
                    EsMecánico = true,
                    ColorPrincipal = "Blanco",
                    EsTemaPersonalizado = false,
                    NombreTema = "",
                    EsDestacado = false,
                    TipoConexion = TipoConexion.Bluetooth,
                    TipoSwitch = TipoSwitch.Marron_Tactil_Silencioso
                },
                new Producto
                {
                    Id = 4,
                    Nombre = "Keycaps Artisan Dragon",
                    Descripcion = "Set de keycaps artesanales con diseño de dragón, perfectos para personalizar tu teclado mecánico.",
                    Precio = 35.99m,
                    Stock = 20,
                    CategoriaId = 4,
                    ImagenUrl = "/images/dragon-keycaps.jpg",
                    Marca = "KeyStore",
                    Modelo = "ART-DRAGON-001",
                    Layout = "Universal",
                    EsIluminado = false,
                    EsInalámbrico = false,
                    EsMecánico = false,
                    ColorPrincipal = "Rojo/Dorado",
                    EsTemaPersonalizado = true,
                    NombreTema = "Dragon",
                    EsDestacado = true,
                    TipoConexion = TipoConexion.USB_A,
                    TipoSwitch = TipoSwitch.Azul_Tactil
                }
            );


            modelBuilder.Entity<ElementoHome>().HasData(
                new ElementoHome
                {
                    Id = 1,
                    TipoElemento = "Hero",
                    Titulo = "KEYSTORE",
                    Subtitulo = "Teclados Personalizados de Alta Calidad",
                    Descripcion = "Descubre nuestra colección exclusiva de teclados mecánicos, temas personalizados y accesorios premium para elevar tu experiencia de escritura y gaming.",
                    TextoBoton = "Comprar Ahora",
                    UrlEnlace = "/productos",
                    Precio = 99.99m,
                    Orden = 1,
                    Activo = true,
                    FechaCreacion = DateTime.UtcNow
                },
                new ElementoHome
                {
                    Id = 2,
                    TipoElemento = "SeccionAbout",
                    Titulo = "About Us",
                    Subtitulo = "Nuestra Pasión por los Teclados",
                    Descripcion = "Nuestra misión es brindar experiencias de teclado personalizadas para todos. Conoce más sobre nuestro viaje y nuestra dedicación a la calidad e innovación.",
                    TextoBoton = "Learn more",
                    UrlEnlace = "/about",
                    Precio = 0.01m,
                    Orden = 10,
                    Activo = true,
                    FechaCreacion = DateTime.UtcNow
                }
            );


            modelBuilder.Entity<ImagenSitio>().HasData(
                new ImagenSitio
                {
                    Id = 1,
                    Clave = "hero-keyboard",
                    Nombre = "Teclado Mecánico Principal - Hero",
                    Descripcion = "Imagen principal del hero que aparece en la página de inicio junto al título KEYSTORE",
                    Activa = true,
                    FechaCreacion = DateTime.UtcNow,
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
                    FechaCreacion = DateTime.UtcNow,
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
                    FechaCreacion = DateTime.UtcNow,
                    ObjectFit = "cover",
                    OcultarFondo = false
                },
                new ImagenSitio
                {
                    Id = 4,
                    Clave = "product-2",
                    Nombre = "Producto Destacado 2",
                    Descripcion = "Segunda imagen de producto destacado en la sección featured",
                    Activa = true,
                    FechaCreacion = DateTime.UtcNow,
                    ObjectFit = "cover",
                    OcultarFondo = false
                },
                new ImagenSitio
                {
                    Id = 5,
                    Clave = "product-3",
                    Nombre = "Producto Destacado 3",
                    Descripcion = "Tercera imagen de producto destacado en la sección featured",
                    Activa = true,
                    FechaCreacion = DateTime.UtcNow,
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