using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using KeyStore.Data;

namespace KeyStore.Models
{
    public enum EstadoPedido
    {
        Procesando = 1,
        Enviado = 2,
        Entregado = 3
    }

    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(450)]
        public string UserId { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string NumeroOrden { get; set; } = string.Empty;

        [Required]
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;

        [Required]
        public EstadoPedido Estado { get; set; } = EstadoPedido.Procesando;

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Subtotal { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal CostoEnvio { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Total { get; set; }

        [Required]
        [MaxLength(50)]
        public string MetodoPago { get; set; } = string.Empty; 
        [MaxLength(200)]
        public string? DireccionEnvio { get; set; }

        [MaxLength(100)]
        public string? CiudadEnvio { get; set; }

        [MaxLength(100)]
        public string? ProvinciaEnvio { get; set; }

        [MaxLength(20)]
        public string? CodigoPostalEnvio { get; set; }
        [MaxLength(100)]
        public string? PaisEnvio { get; set; }

        [MaxLength(200)]
        public string? NombreDestinatario { get; set; }

        [MaxLength(20)]
        public string? TelefonoDestinatario { get; set; }

  
        [MaxLength(4)]
        public string? UltimosDigitosTarjeta { get; set; }

        [MaxLength(20)]
        public string? TipoTarjeta { get; set; }

 
        public DateTime? FechaEnviado { get; set; }
        public DateTime? FechaEntregado { get; set; }

        [MaxLength(500)]
        public string? Notas { get; set; }


        public virtual ApplicationUser? Usuario { get; set; }
        public virtual ICollection<DetallePedido> Detalles { get; set; } = new List<DetallePedido>();

    }

    public class DetallePedido
    {
        public int Id { get; set; }

        [Required]
        public int PedidoId { get; set; }

        [Required]
        public int ProductoId { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal PrecioUnitario { get; set; }

        [Required]
        [MaxLength(200)]
        public string NombreProducto { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? MarcaProducto { get; set; }

        [MaxLength(500)]
        public string? ImagenProducto { get; set; }


        public virtual Pedido? Pedido { get; set; }
        public virtual Producto? Producto { get; set; }

    }

    public class PedidoDto
    {
        public int Id { get; set; }
        public string NumeroOrden { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; }
        public EstadoPedido Estado { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public string DireccionCompleta { get; set; } = string.Empty;
        public string NombreDestinatario { get; set; } = string.Empty;
        public string NombreUsuario { get; set; } = string.Empty;
        public string EmailUsuario { get; set; } = string.Empty;
        public int CantidadProductos { get; set; }
        public List<DetallePedidoDto> Detalles { get; set; } = new();

        public string EstadoTexto => Estado switch
        {
            EstadoPedido.Procesando => "Procesando",
            EstadoPedido.Enviado => "Enviado",
            EstadoPedido.Entregado => "Entregado",
            _ => "Desconocido"
        };

        public string EstadoColor => Estado switch
        {
            EstadoPedido.Procesando => "warning",
            EstadoPedido.Enviado => "info",
            EstadoPedido.Entregado => "success",
            _ => "secondary"
        };

        public string EstadoIcono => Estado switch
        {
            EstadoPedido.Procesando => "bi-clock-fill",
            EstadoPedido.Enviado => "bi-truck",
            EstadoPedido.Entregado => "bi-check-circle-fill",
            _ => "bi-question-circle"
        };

        public string MetodoPagoTexto => MetodoPago switch
        {
            "tarjeta" => "Pago con Tarjeta",
            "local" => "Pago en Local",
            _ => MetodoPago
        };
    }

    public class DetallePedidoDto
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public string? MarcaProducto { get; set; }
        public string? ImagenProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}