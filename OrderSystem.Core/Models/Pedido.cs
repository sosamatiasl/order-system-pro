using OrderSystem.Core.Enums;

namespace OrderSystem.Core.Models
{
    public class Pedido
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<DetallePedido> Items { get; set; } = new List<DetallePedido>();
        public decimal TasaImpuestos { get; set; } = 0.15m; // Ejemplo del 15%

        public TipoDescuento DescuentoAplicado { get; set; } = TipoDescuento.Ninguno;
        public decimal ValorDescuento { get; set; } = 0.0m;

        public decimal CalcularSubtotal() => Items.Sum(i => i.CalcularSubtotal());
    }
}
