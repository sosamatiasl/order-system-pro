using OrderSystem.Core.Models;

namespace OrderSystem.Core.Strategies
{
    public class DescuentoPorcentajeStrategy : IDescuentoStrategy
    {
        public decimal AplicarDescuento(Pedido pedido)
        {
            if (pedido.DescuentoAplicado != Enums.TipoDescuento.Porcentaje)
                return 0.0m;

            // ValorDescuento es el porcentaje (ej: 0.10 para 10%)
            return pedido.CalcularSubtotal() * pedido.ValorDescuento;
        }
    }
}
