using backNegocio.Enums;

namespace backNegocio.Models.Commons
{
    public class Producto
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;

        public RubroEnum Rubro { get; set; }

        public decimal precio { get; set; }

        public int stock { get; set; }

        public bool eliminado { get; set; } = false;

        public override string ToString()
        {
            return nombre;
        }
    }
}
