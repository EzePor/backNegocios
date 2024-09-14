namespace backNegocio.Models.Commons
{
    public class Impresion
    {
        public int id {  get; set; }
        public string tamanio { get; set; }=string.Empty;

        public decimal precioBase { get; set; }
        public decimal descuento10 { get; set; }
        public decimal descuento20 { get; set; }
        public decimal descuento50 { get; set; }

        public bool eliminado { get; set; } = false;

        public decimal CalcularPrecioFinal(int cantidad)
        {
            if (cantidad >= 50) return precioBase * (1 - descuento50);
            if (cantidad >= 20) return precioBase * (1 - descuento20);
            if (cantidad >= 10) return precioBase * (1 - descuento10);
            return precioBase;
        }

        public override string ToString()
        {
            return tamanio;
        }

    }
}
