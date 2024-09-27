using backNegocio.Enums;
using backNegocio.Models.Commons;

namespace backNegocio.Models.Detalles
{
    public class Pedido
    {
        public int id { get; set; }
        public int ClienteId { get; set; }
        public Cliente? cliente { get; set; }
        public DateTime fechaPedido { get; set; }
        public int ModoPagoId { get; set; }
        public ModoPago? modoPago { get; set; }

        public  EstadoPedidoEnum estadoPedido {get; set;}

        public bool FuePagado { get; set; } = false;
      
        public bool eliminado { get; set; } = false;

        // Relación: Un pedido puede tener múltiples productos y/o impresiones
        public ICollection<DetalleProducto>? DetallesProducto { get; set; }
        public ICollection<DetalleImpresion>? DetallesImpresion { get; set; }


        // Propiedad calculada para el total del pedido
        public decimal TotalPedido
        {
            get
            {
                decimal totalDetalleProducto = DetallesProducto?.Sum(dp => dp.total ?? 0) ?? 0;
                decimal totalDetalleImpresion = DetallesImpresion?.Sum(di => di.total ?? 0) ?? 0;

                return totalDetalleProducto + totalDetalleImpresion;
            }
        }

        public override string ToString()
        {
            return $"{cliente?.apellidoNombre}" ?? string.Empty;
        }
    }
}
