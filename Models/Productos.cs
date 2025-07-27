using System.ComponentModel.DataAnnotations;

namespace KeyStore.Models
{

    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder 200 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es requerido")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public decimal Precio { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El stock no puede ser negativo")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoría")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría válida")]
        public int CategoriaId { get; set; }

        public string ImagenUrl { get; set; } = string.Empty;
        public List<string> ImagenesSecundarias { get; set; } = new();

        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Layout { get; set; } = string.Empty;
        public bool EsIluminado { get; set; }
        public bool EsInalámbrico { get; set; }
        public bool EsMecánico { get; set; }
        public string ColorPrincipal { get; set; } = string.Empty;
        public bool EsTemaPersonalizado { get; set; }
        public string NombreTema { get; set; } = string.Empty;
        public bool EsDestacado { get; set; }
        public TipoConexion TipoConexion { get; set; }
        public TipoSwitch TipoSwitch { get; set; }
    }


    public class ProductoDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int CategoriaId { get; set; }
        public string CategoriaNombre { get; set; } = string.Empty;
        public string ImagenUrl { get; set; } = string.Empty;
        public List<string> ImagenesSecundarias { get; set; } = new();
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Layout { get; set; } = string.Empty;
        public bool EsIluminado { get; set; }
        public bool EsInalámbrico { get; set; }
        public bool EsMecánico { get; set; }
        public string ColorPrincipal { get; set; } = string.Empty;
        public bool EsTemaPersonalizado { get; set; }
        public string NombreTema { get; set; } = string.Empty;
        public bool EsDestacado { get; set; }
        public string TipoConexion { get; set; } = string.Empty;
        public string TipoSwitch { get; set; } = string.Empty;

        public bool EstaEnStock { get; set; }
        public string EstadoStock { get; set; } = string.Empty;
        public double Calificacion { get; set; }
        public int NumeroVentas { get; set; }
    }

    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool EsActiva { get; set; }
        public int Orden { get; set; }
    }

    public enum TipoConexion
    {
        USB_C,
        USB_A,
        Inalambrico_2_4GHz,
        Bluetooth,
        Cable_Desmontable
    }

    public enum TipoSwitch
    {
        Rojo_Linear,
        Azul_Tactil,
        Marron_Tactil_Silencioso,
        Negro_Linear_Pesado,
        Plata_Linear_Rapido,
        Verde_Tactil_Pesado
    }


    public class FiltroProductos
    {
        public string Busqueda { get; set; } = string.Empty;
        public int? CategoriaId { get; set; }
        public decimal? PrecioMinimo { get; set; }
        public decimal? PrecioMaximo { get; set; }
        public string Marca { get; set; } = string.Empty;
        public TipoConexion? TipoConexion { get; set; }
        public TipoSwitch? TipoSwitch { get; set; }
        public bool? EsIluminado { get; set; }
        public bool? EsInalámbrico { get; set; }
        public bool? EsMecánico { get; set; }
        public bool? SoloEnStock { get; set; }
        public string OrdenarPor { get; set; } = "nombre";
        public bool OrdenDescendente { get; set; }
        public int Pagina { get; set; } = 1;
        public int ElementosPorPagina { get; set; } = 12;
    }
}