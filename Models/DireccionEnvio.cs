using System.ComponentModel.DataAnnotations;

namespace KeyStore.Models
{
    public class DireccionEnvio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El ID de usuario es requerido")]
        [MaxLength(450)]
        public string UserId { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Los apellidos son requeridos")]
        [StringLength(100, ErrorMessage = "Los apellidos no pueden exceder 100 caracteres")]
        public string Apellidos { get; set; } = string.Empty;

        [Required(ErrorMessage = "La dirección es requerida")]
        [StringLength(200, ErrorMessage = "La dirección no puede exceder 200 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [StringLength(100, ErrorMessage = "La dirección 2 no puede exceder 100 caracteres")]
        public string Direccion2 { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ciudad es requerida")]
        [StringLength(100, ErrorMessage = "La ciudad no puede exceder 100 caracteres")]
        public string Ciudad { get; set; } = string.Empty;

        [Required(ErrorMessage = "La provincia es requerida")]
        [StringLength(100, ErrorMessage = "La provincia no puede exceder 100 caracteres")]
        public string Provincia { get; set; } = string.Empty;

        [Required(ErrorMessage = "El código postal es requerido")]
        [StringLength(20, ErrorMessage = "El código postal no puede exceder 20 caracteres")]
        public string CodigoPostal { get; set; } = string.Empty;

        [Required(ErrorMessage = "El país es requerido")]
        [StringLength(100, ErrorMessage = "El país no puede exceder 100 caracteres")]
        public string Pais { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "El teléfono no puede exceder 20 caracteres")]
        public string Telefono { get; set; } = string.Empty;

        public bool EsPrincipal { get; set; } = false;

        public bool Activa { get; set; } = true;

        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        public DateTime? FechaModificacion { get; set; }

        public string DireccionCompleta =>
            $"{Direccion}{(!string.IsNullOrEmpty(Direccion2) ? $", {Direccion2}" : "")}, {Ciudad}, {Provincia} {CodigoPostal}, {Pais}";

        public string NombreCompleto => $"{Nombre} {Apellidos}";
    }
}