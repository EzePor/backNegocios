using backNegocio.Models.Commons;

namespace backNegocio.Models.Detalles
{
    public class DetallePedido
    {
        public int id { get; set; }
        public int PedidoId { get; set; }
        public Pedido? pedido { get; set; }
        public int ProductoId { get; set; }
        public Producto? producto { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }

        public decimal? total => cantidad * precioUnitario;

        public bool eliminado { get; set; } = false;

        public override string ToString()
        {
            return $"{producto} - {cantidad}";
        }


    }
}
