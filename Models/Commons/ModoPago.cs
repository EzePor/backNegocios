namespace backNegocio.Models.Commons
{
    public class ModoPago
    {
        public int id { get; set; }
        public string nombre { get; set; } = string.Empty;
        public decimal ajuste { get; set; }

        public bool eliminado { get; set; } = false;

        public override string ToString()
        {
            return nombre;
        }
    }
}
