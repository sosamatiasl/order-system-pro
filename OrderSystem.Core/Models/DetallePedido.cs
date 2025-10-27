namespace OrderSystem.Core.Models
{
    public class DetallePedido
    {
        public string ProductoNombre { get; set; } = string.Empty;
        public decimal PrecioUnitario { get; set; }
        public int Cantidad { get; set; }

        public decimal CalcularSubtotal() => PrecioUnitario * Cantidad;
    }
}
