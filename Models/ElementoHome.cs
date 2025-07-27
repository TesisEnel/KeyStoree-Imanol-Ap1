using System.ComponentModel.DataAnnotations;
namespace KeyStore.Models
{
    public class ElementoHome
    {
        public int Id { get; set; }
        public string TipoElemento { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string? Subtitulo { get; set; }
        public string? Descripcion { get; set; }
        public string? UrlEnlace { get; set; }
        public string? TextoBoton { get; set; }
        public int Orden { get; set; } = 1;
        public bool Activo { get; set; } = true;

        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        public byte[]? ImagenData { get; set; }
        public string? TipoImagen { get; set; }
        public string? NombreImagen { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}