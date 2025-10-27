using OrderSystem.Core.Models;
using OrderSystem.Core.Strategies;

namespace OrderSystem.Core.Services
{
    public class CalculadoraTotal
    {
        private readonly IEnumerable<IDescuentoStrategy> _descuentoStrategies;

        public CalculadoraTotal(IEnumerable<IDescuentoStrategy> descuentoStrategies)
        {
            _descuentoStrategies = descuentoStrategies;
        }

        public decimal CalcularTotal(Pedido pedido)
        {
            if (pedido == null || !pedido.Items.Any())
                throw new ArgumentNullException(nameof(pedido), "El pedido no puede ser nulo o vacío.");

            decimal subtotal = pedido.CalcularSubtotal();

            // 1) Aplicar Descuento
            decimal montoDescuento = _descuentoStrategies.Sum(strategy => strategy.AplicarDescuento(pedido));

            decimal subtotalConDescuento = subtotal - montoDescuento;

            // 2) Aplicar Impuestos
            decimal montoImpuestos = subtotalConDescuento * pedido.TasaImpuestos;

            // 3) Total Final
            return subtotalConDescuento + montoImpuestos;
        }
    }
}
