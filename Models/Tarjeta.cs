using System.ComponentModel.DataAnnotations;
using KeyStore.Data;

namespace KeyStore.Models
{
    public class Tarjeta
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [StringLength(4, MinimumLength = 4)]
        public string UltimosDigitos { get; set; } = string.Empty;

        [Required]
        [StringLength(5, MinimumLength = 5)]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/\d{2}$", ErrorMessage = "Formato inválido. Use MM/YY")]
        public string FechaVencimiento { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string NombreTitular { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string TipoTarjeta { get; set; } = string.Empty; 

        public bool EsPrincipal { get; set; } = false;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
        public bool Activa { get; set; } = true;


        [StringLength(19)]
        public string NumeroTarjeta { get; set; } = string.Empty;

        [StringLength(4)]
        public string CVV { get; set; } = string.Empty;


    }

    public class TarjetaDto
    {
        public int Id { get; set; }
        public string UltimosDigitos { get; set; } = string.Empty;
        public string FechaVencimiento { get; set; } = string.Empty;
        public string NombreTitular { get; set; } = string.Empty;
        public string TipoTarjeta { get; set; } = string.Empty;
        public bool EsPrincipal { get; set; }
        public bool Activa { get; set; }
        public string NumeroEnmascarado => $"**** **** **** {UltimosDigitos}";
    }
}