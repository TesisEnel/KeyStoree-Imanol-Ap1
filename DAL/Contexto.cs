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