using backNegocio.Models.Detalles;

namespace backNegocio.Models.Commons
{
    public class Cliente
    {
        public int id { get; set; }
        public string apellidoNombre { get; set; } = string.Empty;
        public string cuitDni { get; set; } = string.Empty;
        public string direccion { get; set; } = string.Empty;
        public string telefono { get; set; } = string.Empty;
        public string email { get; set; }   = string.Empty ;
        public string Localidad { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;



        public bool eliminado { get; set; } = false;

        public ICollection<Pedido>? Pedidos { get; set; }

        public override string ToString()
        {
            return apellidoNombre;
        }
    }
}
