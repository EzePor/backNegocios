using backNegocio.Enums;

namespace backNegocio.Models.Commons
{
    public class Usuario
    {
        public int id { get; set; }
        public string user { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;

        public string password { get; set; } = string.Empty;
        public TipoUsuarioEnum? TipoUsuario { get; set; }

        public bool eliminado { get; set; } = false;


        public override string ToString()
        {
            return $"{user}" ?? string.Empty;
        }
    }
}
