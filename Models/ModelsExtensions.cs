using KeyStore.Models;

namespace KeyStore.Extensions
{
    public static class ModelExtensions
    {

        public static string GetEstadoTexto(this Pedido pedido)
        {
            return pedido.Estado switch
            {
                EstadoPedido.Procesando => "Procesando",
                EstadoPedido.Enviado => "Enviado",
                EstadoPedido.Entregado => "Entregado",
                _ => "Desconocido"
            };
        }

        public static string GetEstadoColor(this Pedido pedido)
        {
            return pedido.Estado switch
            {
                EstadoPedido.Procesando => "warning",
                EstadoPedido.Enviado => "info",
                EstadoPedido.Entregado => "success",
                _ => "secondary"
            };
        }

        public static string GetEstadoIcono(this Pedido pedido)
        {
            return pedido.Estado switch
            {
                EstadoPedido.Procesando => "bi-clock-fill",
                EstadoPedido.Enviado => "bi-truck",
                EstadoPedido.Entregado => "bi-check-circle-fill",
                _ => "bi-question-circle"
            };
        }

        public static string GetDireccionCompleta(this Pedido pedido)
        {
            return pedido.MetodoPago == "local"
                ? "Retiro en tienda"
                : $"{pedido.DireccionEnvio}, {pedido.CiudadEnvio}, {pedido.ProvinciaEnvio} {pedido.CodigoPostalEnvio}, {pedido.PaisEnvio}";
        }

        public static int GetCantidadTotal(this Pedido pedido)
        {
            return pedido.Detalles?.Sum(d => d.Cantidad) ?? 0;
        }


        public static decimal GetSubtotal(this DetallePedido detalle)
        {
            return detalle.PrecioUnitario * detalle.Cantidad;
        }

        public static string GetDireccionCompleta(this DireccionEnvio direccion)
        {
            return $"{direccion.Direccion}{(!string.IsNullOrEmpty(direccion.Direccion2) ? $", {direccion.Direccion2}" : "")}, {direccion.Ciudad}, {direccion.Provincia} {direccion.CodigoPostal}, {direccion.Pais}";
        }

        public static string GetNombreCompleto(this DireccionEnvio direccion)
        {
            return $"{direccion.Nombre} {direccion.Apellidos}";
        }
    }
}