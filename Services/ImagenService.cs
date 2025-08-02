using Microsoft.AspNetCore.Components.Forms;

namespace KeyStore.Services
{
    public interface IImagenService
    {
        Task<string> SubirImagenAsync(IBrowserFile archivo, string carpeta = "productos");
        Task<bool> EliminarImagenAsync(string rutaImagen);
        bool ValidarImagen(IBrowserFile archivo);
        string GenerarNombreUnico(string nombreOriginal);
    }

    public class ImagenService : IImagenService
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ImagenService> _logger;
        private const long MaxFileSize = 5 * 1024 * 1024; // 5MB
        private readonly string[] FormatosPermitidos = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };

        public ImagenService(IWebHostEnvironment webHostEnvironment, ILogger<ImagenService> logger)
        {
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }

        public async Task<string> SubirImagenAsync(IBrowserFile archivo, string carpeta = "productos")
        {
            try
            {
                if (!ValidarImagen(archivo))
                {
                    throw new ArgumentException("Archivo de imagen no válido");
                }

                var carpetaDestino = Path.Combine(_webHostEnvironment.WebRootPath, "Imagenes", carpeta);
                if (!Directory.Exists(carpetaDestino))
                {
                    Directory.CreateDirectory(carpetaDestino);
                }

                var nombreArchivo = GenerarNombreUnico(archivo.Name);
                var rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

                using var stream = new FileStream(rutaCompleta, FileMode.Create);
                await archivo.OpenReadStream(MaxFileSize).CopyToAsync(stream);

                return $"/Imagenes/{carpeta}/{nombreArchivo}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al subir imagen: {FileName}", archivo.Name);
                throw;
            }
        }

        public async Task<bool> EliminarImagenAsync(string rutaImagen)
        {
            try
            {
                if (string.IsNullOrEmpty(rutaImagen))
                    return false;

                var rutaFisica = Path.Combine(_webHostEnvironment.WebRootPath, rutaImagen.TrimStart('/'));

                if (File.Exists(rutaFisica))
                {
                    File.Delete(rutaFisica);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar imagen: {RutaImagen}", rutaImagen);
                return false;
            }
        }

        public bool ValidarImagen(IBrowserFile archivo)
        {
            if (archivo == null) return false;

            if (archivo.Size > MaxFileSize) return false;

            var extension = Path.GetExtension(archivo.Name).ToLowerInvariant();
            if (!FormatosPermitidos.Contains(extension)) return false;

            var tiposPermitidos = new[] { "image/jpeg", "image/jpg", "image/png", "image/gif", "image/webp" };
            if (!tiposPermitidos.Contains(archivo.ContentType.ToLower())) return false;

            return true;
        }

        public string GenerarNombreUnico(string nombreOriginal)
        {
            var extension = Path.GetExtension(nombreOriginal);
            var nombreSinExtension = Path.GetFileNameWithoutExtension(nombreOriginal);

            var nombreLimpio = new string(nombreSinExtension.Where(c => char.IsLetterOrDigit(c) || c == '-' || c == '_').ToArray());

            var timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            var guid = Guid.NewGuid().ToString("N")[..8];

            return $"{nombreLimpio}_{timestamp}_{guid}{extension}";
        }
    }
}