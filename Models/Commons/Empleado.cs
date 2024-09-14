namespace backNegocio.Models.Commons
{
    public class Empleado
    {
        public int id { get; set; }
        public string apellidoNombre { get; set; } = string.Empty;

        public string dni { get; set; } = string.Empty;

        public bool eliminado { get; set; } = false;

        public override string ToString()
        {
            return apellidoNombre;
        }

    }
}
