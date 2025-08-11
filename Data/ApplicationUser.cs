using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace KeyStore.Data
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string? Nombre { get; set; }

        [MaxLength(100)]
        public string? Apellido { get; set; }

        [Required, MaxLength(100)]
        public string NombreCompleto { get; set; } = string.Empty;

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        public ApplicationUser()
        {
        }
    }
}