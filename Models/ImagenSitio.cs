using System.ComponentModel.DataAnnotations;

namespace KeyStore.Models
{
    public class ImagenSitio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La clave es requerida")]
        [StringLength(100, ErrorMessage = "La clave no puede exceder 100 caracteres")]
        public string Clave { get; set; } = string.Empty; // ej: "hero-keyboard", "about-image"

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder 200 caracteres")]
        public string Nombre { get; set; } = string.Empty; // Nombre descriptivo

        [StringLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        public string? Descripcion { get; set; }

        public byte[]? ImagenData { get; set; }
        public string? TipoImagen { get; set; }
        public string? NombreArchivo { get; set; }

        public bool Activa { get; set; } = true;

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}