using OrderSystem.Core.Models;

namespace OrderSystem.Core.Strategies
{
    public interface IDescuentoStrategy
    {
        decimal AplicarDescuento(Pedido pedido);
    }
}
