using backNegocio.Enums;

namespace backNegocio.Models.Detalles
{
    public class ResumenPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; } // Relación con el pedido principal

        public List<DetalleProducto> DetallesProducto { get; set; } // Lista de productos en el pedido
        public List<DetalleImpresion> DetallesImpresion { get; set; } // Lista de impresiones en el pedido

        // Cálculo de totales
        public decimal TotalProductos => (decimal)DetallesProducto.Sum(p => p.total);
        public decimal TotalImpresiones => (decimal)DetallesImpresion.Sum(i => i.total);
        public decimal TotalPedido => TotalProductos + TotalImpresiones;

        public EstadoPedidoEnum Estado { get; set; } // Estado del pedido

        public ResumenPedido()
        {
            DetallesProducto = new List<DetalleProducto>();
            DetallesImpresion = new List<DetalleImpresion>();
        }
    }

}
