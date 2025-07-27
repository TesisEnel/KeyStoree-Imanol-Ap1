using KeyStore.Models;
using System.Net.Http.Json;
using System.Text.Json;

namespace KeyStore.Services
{
    public interface IProductosService
    {
        // Métodos existentes
        Task<List<ProductoDto>> ObtenerProductosAsync();
        Task<List<ProductoDto>> ObtenerProductosFiltradosAsync(FiltroProductos filtro);
        Task<ProductoDto?> ObtenerProductoPorIdAsync(int id);
        Task<List<ProductoDto>> ObtenerProductosDestacadosAsync();
        Task<List<ProductoDto>> ObtenerProductosPorCategoriaAsync(int categoriaId);
        Task<List<Categoria>> ObtenerCategoriasAsync();
        Task<List<string>> ObtenerMarcasAsync();
        Task<(List<ProductoDto> productos, int totalPaginas)> ObtenerProductosPaginadosAsync(FiltroProductos filtro);

        // Métodos de administración - NUEVOS
        Task<ProductoDto> CrearProductoAsync(Producto producto);
        Task<ProductoDto> ActualizarProductoAsync(int id, Producto producto);
        Task<bool> EliminarProductoAsync(int id);
    }

    public class ProductosService : IProductosService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProductosService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<List<ProductoDto>> ObtenerProductosAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ProductoDto>>(
                    "api/productos", _jsonOptions);
                return response ?? new List<ProductoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos: {ex.Message}");
                return new List<ProductoDto>();
            }
        }

        public async Task<List<ProductoDto>> ObtenerProductosFiltradosAsync(FiltroProductos filtro)
        {
            try
            {
                var queryString = ConstruirQueryString(filtro);
                var response = await _httpClient.GetFromJsonAsync<List<ProductoDto>>(
                    $"api/productos/filtrados?{queryString}", _jsonOptions);
                return response ?? new List<ProductoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos filtrados: {ex.Message}");
                return new List<ProductoDto>();
            }
        }

        public async Task<ProductoDto?> ObtenerProductoPorIdAsync(int id)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ProductoDto>(
                    $"api/productos/{id}", _jsonOptions);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener producto {id}: {ex.Message}");
                return null;
            }
        }

        public async Task<List<ProductoDto>> ObtenerProductosDestacadosAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ProductoDto>>(
                    "api/productos/destacados", _jsonOptions);
                return response ?? new List<ProductoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos destacados: {ex.Message}");
                return new List<ProductoDto>();
            }
        }

        public async Task<List<ProductoDto>> ObtenerProductosPorCategoriaAsync(int categoriaId)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<ProductoDto>>(
                    $"api/productos/categoria/{categoriaId}", _jsonOptions);
                return response ?? new List<ProductoDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos de categoría {categoriaId}: {ex.Message}");
                return new List<ProductoDto>();
            }
        }

        public async Task<List<Categoria>> ObtenerCategoriasAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<Categoria>>(
                    "api/categorias", _jsonOptions);
                return response ?? new List<Categoria>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener categorías: {ex.Message}");
                return new List<Categoria>();
            }
        }

        public async Task<List<string>> ObtenerMarcasAsync()
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<List<string>>(
                    "api/productos/marcas", _jsonOptions);
                return response ?? new List<string>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener marcas: {ex.Message}");
                return new List<string>();
            }
        }

        public async Task<(List<ProductoDto> productos, int totalPaginas)> ObtenerProductosPaginadosAsync(FiltroProductos filtro)
        {
            try
            {
                var queryString = ConstruirQueryString(filtro);
                var response = await _httpClient.GetFromJsonAsync<RespuestaPaginada>(
                    $"api/productos/paginados?{queryString}", _jsonOptions);

                return (response?.Productos ?? new List<ProductoDto>(), response?.TotalPaginas ?? 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener productos paginados: {ex.Message}");
                return (new List<ProductoDto>(), 0);
            }
        }

        // MÉTODOS DE ADMINISTRACIÓN - NUEVOS
        public async Task<ProductoDto> CrearProductoAsync(Producto producto)
        {
            try
            {
                var productoDto = MapearEntidadADto(producto);
                var response = await _httpClient.PostAsJsonAsync("api/productos", productoDto, _jsonOptions);
                response.EnsureSuccessStatusCode();

                var resultado = await response.Content.ReadFromJsonAsync<ProductoDto>(_jsonOptions);
                return resultado ?? throw new Exception("No se pudo crear el producto");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear producto: {ex.Message}");
                throw;
            }
        }

        public async Task<ProductoDto> ActualizarProductoAsync(int id, Producto producto)
        {
            try
            {
                var productoDto = MapearEntidadADto(producto);
                var response = await _httpClient.PutAsJsonAsync($"api/productos/{id}", productoDto, _jsonOptions);
                response.EnsureSuccessStatusCode();

                var resultado = await response.Content.ReadFromJsonAsync<ProductoDto>(_jsonOptions);
                return resultado ?? throw new Exception("No se pudo actualizar el producto");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar producto: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> EliminarProductoAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/productos/{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar producto: {ex.Message}");
                return false;
            }
        }

        private static ProductoDto MapearEntidadADto(Producto producto)
        {
            return new ProductoDto
            {
                Id = producto.Id,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                CategoriaId = producto.CategoriaId,
                ImagenUrl = producto.ImagenUrl,
                ImagenesSecundarias = producto.ImagenesSecundarias,
                Marca = producto.Marca,
                Modelo = producto.Modelo,
                Layout = producto.Layout,
                EsIluminado = producto.EsIluminado,
                EsInalámbrico = producto.EsInalámbrico,
                EsMecánico = producto.EsMecánico,
                ColorPrincipal = producto.ColorPrincipal,
                EsTemaPersonalizado = producto.EsTemaPersonalizado,
                NombreTema = producto.NombreTema,
                EsDestacado = producto.EsDestacado,
                TipoConexion = producto.TipoConexion.ToString(),
                TipoSwitch = producto.TipoSwitch.ToString(),
                EstaEnStock = producto.Stock > 0,
                EstadoStock = producto.Stock > 0 ? "Disponible" : "Agotado"
            };
        }

        private static string ConstruirQueryString(FiltroProductos filtro)
        {
            var parametros = new List<string>();

            if (!string.IsNullOrEmpty(filtro.Busqueda))
                parametros.Add($"busqueda={Uri.EscapeDataString(filtro.Busqueda)}");

            if (filtro.CategoriaId.HasValue)
                parametros.Add($"categoriaId={filtro.CategoriaId.Value}");

            if (filtro.PrecioMinimo.HasValue)
                parametros.Add($"precioMinimo={filtro.PrecioMinimo.Value}");

            if (filtro.PrecioMaximo.HasValue)
                parametros.Add($"precioMaximo={filtro.PrecioMaximo.Value}");

            if (!string.IsNullOrEmpty(filtro.Marca))
                parametros.Add($"marca={Uri.EscapeDataString(filtro.Marca)}");

            if (filtro.TipoConexion.HasValue)
                parametros.Add($"tipoConexion={filtro.TipoConexion.Value}");

            if (filtro.TipoSwitch.HasValue)
                parametros.Add($"tipoSwitch={filtro.TipoSwitch.Value}");

            if (filtro.EsIluminado.HasValue)
                parametros.Add($"esIluminado={filtro.EsIluminado.Value}");

            if (filtro.EsInalámbrico.HasValue)
                parametros.Add($"esInalambrico={filtro.EsInalámbrico.Value}");

            if (filtro.EsMecánico.HasValue)
                parametros.Add($"esMecanico={filtro.EsMecánico.Value}");

            if (filtro.SoloEnStock.HasValue)
                parametros.Add($"soloEnStock={filtro.SoloEnStock.Value}");

            parametros.Add($"ordenarPor={Uri.EscapeDataString(filtro.OrdenarPor)}");
            parametros.Add($"ordenDescendente={filtro.OrdenDescendente}");
            parametros.Add($"pagina={filtro.Pagina}");
            parametros.Add($"elementosPorPagina={filtro.ElementosPorPagina}");

            return string.Join("&", parametros);
        }
    }

    // Modelo para respuesta paginada
    public class RespuestaPaginada
    {
        public List<ProductoDto> Productos { get; set; } = new();
        public int TotalProductos { get; set; }
        public int TotalPaginas { get; set; }
        public int PaginaActual { get; set; }
        public bool TienePaginaAnterior { get; set; }
        public bool TienePaginaSiguiente { get; set; }
    }

    // Service Mock para desarrollo/testing
    public class ProductosServiceMock : IProductosService
    {
        private readonly List<ProductoDto> _productos;
        private readonly List<Categoria> _categorias;
        private int _nextId = 100;

        public ProductosServiceMock()
        {
            _categorias = new List<Categoria>
            {
                new() { Id = 1, Nombre = "Teclados RGB", Descripcion = "Teclados con iluminación RGB", EsActiva = true, Orden = 1 },
                new() { Id = 2, Nombre = "Teclados Mecánicos", Descripcion = "Teclados mecánicos premium", EsActiva = true, Orden = 2 },
                new() { Id = 3, Nombre = "Temas Personalizados", Descripcion = "Keycaps y temas únicos", EsActiva = true, Orden = 3 }
            };

            _productos = new List<ProductoDto>
            {
                new()
                {
                    Id = 1,
                    Nombre = "Teclado RGB Gaming Pro",
                    Descripcion = "Teclado mecánico con switches rojos y RGB completo",
                    Precio = 89.99m,
                    Stock = 15,
                    CategoriaId = 1,
                    CategoriaNombre = "Teclados RGB",
                    ImagenUrl = "/images/keyboard-rgb-1.jpg",
                    ImagenesSecundarias = new List<string>(),
                    Marca = "KeyStore",
                    Modelo = "RGB-PRO-001",
                    TipoConexion = "USB_C",
                    TipoSwitch = "Rojo_Linear",
                    Layout = "Español",
                    EsIluminado = true,
                    EsInalámbrico = false,
                    EsMecánico = true,
                    ColorPrincipal = "Negro",
                    EsDestacado = true,
                    Calificacion = 4.5,
                    NumeroVentas = 234,
                    EstaEnStock = true,
                    EstadoStock = "Disponible"
                },
                new()
                {
                    Id = 2,
                    Nombre = "Tema Cyberpunk 2077",
                    Descripcion = "Set completo de keycaps inspirado en Cyberpunk",
                    Precio = 45.99m,
                    Stock = 8,
                    CategoriaId = 3,
                    CategoriaNombre = "Temas Personalizados",
                    ImagenUrl = "/images/cyberpunk-theme.jpg",
                    ImagenesSecundarias = new List<string>(),
                    Marca = "KeyStore",
                    Modelo = "THEME-CP77",
                    EsTemaPersonalizado = true,
                    NombreTema = "Cyberpunk",
                    ColorPrincipal = "Amarillo/Negro",
                    EsDestacado = true,
                    Calificacion = 4.8,
                    NumeroVentas = 156,
                    EstaEnStock = true,
                    EstadoStock = "Pocas unidades"
                }
            };
        }

        public Task<List<ProductoDto>> ObtenerProductosAsync()
        {
            return Task.FromResult(_productos);
        }

        public Task<List<ProductoDto>> ObtenerProductosFiltradosAsync(FiltroProductos filtro)
        {
            var productos = _productos.AsEnumerable();

            if (!string.IsNullOrEmpty(filtro.Busqueda))
                productos = productos.Where(p => p.Nombre.Contains(filtro.Busqueda, StringComparison.OrdinalIgnoreCase));

            if (filtro.CategoriaId.HasValue)
                productos = productos.Where(p => p.CategoriaId == filtro.CategoriaId.Value);

            if (filtro.SoloEnStock == true)
                productos = productos.Where(p => p.EstaEnStock);

            return Task.FromResult(productos.ToList());
        }

        public Task<ProductoDto?> ObtenerProductoPorIdAsync(int id)
        {
            return Task.FromResult(_productos.FirstOrDefault(p => p.Id == id));
        }

        public Task<List<ProductoDto>> ObtenerProductosDestacadosAsync()
        {
            return Task.FromResult(_productos.Where(p => p.EsDestacado).ToList());
        }

        public Task<List<ProductoDto>> ObtenerProductosPorCategoriaAsync(int categoriaId)
        {
            return Task.FromResult(_productos.Where(p => p.CategoriaId == categoriaId).ToList());
        }

        public Task<List<Categoria>> ObtenerCategoriasAsync()
        {
            return Task.FromResult(_categorias);
        }

        public Task<List<string>> ObtenerMarcasAsync()
        {
            return Task.FromResult(_productos.Select(p => p.Marca).Distinct().ToList());
        }

        public Task<(List<ProductoDto> productos, int totalPaginas)> ObtenerProductosPaginadosAsync(FiltroProductos filtro)
        {
            var totalProductos = _productos.Count;
            var totalPaginas = (int)Math.Ceiling((double)totalProductos / filtro.ElementosPorPagina);
            var productos = _productos
                .Skip((filtro.Pagina - 1) * filtro.ElementosPorPagina)
                .Take(filtro.ElementosPorPagina)
                .ToList();

            return Task.FromResult((productos, totalPaginas));
        }

        // MÉTODOS DE ADMINISTRACIÓN - MOCK
        public async Task<ProductoDto> CrearProductoAsync(Producto producto)
        {
            await Task.Delay(500); // Simular llamada async

            var productoDto = new ProductoDto
            {
                Id = _nextId++,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Stock = producto.Stock,
                CategoriaId = producto.CategoriaId,
                CategoriaNombre = _categorias.FirstOrDefault(c => c.Id == producto.CategoriaId)?.Nombre ?? "Sin categoría",
                ImagenUrl = producto.ImagenUrl,
                ImagenesSecundarias = producto.ImagenesSecundarias,
                Marca = producto.Marca,
                Modelo = producto.Modelo,
                Layout = producto.Layout,
                EsIluminado = producto.EsIluminado,
                EsInalámbrico = producto.EsInalámbrico,
                EsMecánico = producto.EsMecánico,
                ColorPrincipal = producto.ColorPrincipal,
                EsTemaPersonalizado = producto.EsTemaPersonalizado,
                NombreTema = producto.NombreTema,
                EsDestacado = producto.EsDestacado,
                TipoConexion = producto.TipoConexion.ToString(),
                TipoSwitch = producto.TipoSwitch.ToString(),
                EstaEnStock = producto.Stock > 0,
                EstadoStock = producto.Stock > 0 ? "Disponible" : "Agotado",
                Calificacion = 0,
                NumeroVentas = 0
            };

            _productos.Add(productoDto);
            return productoDto;
        }

        public async Task<ProductoDto> ActualizarProductoAsync(int id, Producto producto)
        {
            await Task.Delay(500); // Simular llamada async

            var productoExistente = _productos.FirstOrDefault(p => p.Id == id);
            if (productoExistente == null)
                throw new Exception("Producto no encontrado");

            // Actualizar propiedades
            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;
            productoExistente.Stock = producto.Stock;
            productoExistente.CategoriaId = producto.CategoriaId;
            productoExistente.CategoriaNombre = _categorias.FirstOrDefault(c => c.Id == producto.CategoriaId)?.Nombre ?? "Sin categoría";
            productoExistente.ImagenUrl = producto.ImagenUrl;
            productoExistente.ImagenesSecundarias = producto.ImagenesSecundarias;
            productoExistente.Marca = producto.Marca;
            productoExistente.Modelo = producto.Modelo;
            productoExistente.Layout = producto.Layout;
            productoExistente.EsIluminado = producto.EsIluminado;
            productoExistente.EsInalámbrico = producto.EsInalámbrico;
            productoExistente.EsMecánico = producto.EsMecánico;
            productoExistente.ColorPrincipal = producto.ColorPrincipal;
            productoExistente.EsTemaPersonalizado = producto.EsTemaPersonalizado;
            productoExistente.NombreTema = producto.NombreTema;
            productoExistente.EsDestacado = producto.EsDestacado;
            productoExistente.TipoConexion = producto.TipoConexion.ToString();
            productoExistente.TipoSwitch = producto.TipoSwitch.ToString();
            productoExistente.EstaEnStock = producto.Stock > 0;
            productoExistente.EstadoStock = producto.Stock > 0 ? "Disponible" : "Agotado";

            return productoExistente;
        }

        public async Task<bool> EliminarProductoAsync(int id)
        {
            await Task.Delay(200); // Simular llamada async

            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                _productos.Remove(producto);
                return true;
            }
            return false;
        }
    }
}