using OrderSystem.Core.Enums;
using OrderSystem.Core.Models;
using OrderSystem.Core.Services;
using OrderSystem.Core.Strategies;

namespace OrderSystem.Tests
{
    [TestFixture]
    public class CalculadoraTests
    {
        private CalculadoraTotal _calculator;

        [SetUp]
        public void Setup()
        {
            var strategies = new List<IDescuentoStrategy>
            {
                new DescuentoPorcentajeStrategy()
            };
            _calculator = new CalculadoraTotal(strategies);
        }

        private Pedido CrearPedidoSimple()
        {
            return new Pedido
            {
                Items = new List<DetallePedido>
                {
                    new DetallePedido { PrecioUnitario = 50.00m, Cantidad = 2, ProductoNombre = "Producto A" }
                },
                TasaImpuestos = 0.15m // Ejemplo del 15%
            };
        }

        [Test]
        public void CalcularTotal_SinDescuento_DebeAplicarSoloImpuestos()
        {
            // Arrange
            var pedido = CrearPedidoSimple();
            // 100 + (100 * 0.15) = 115.00
            decimal totalEsperado = 115.00m;

            // Act
            decimal totalActual = _calculator.CalcularTotal(pedido);

            // Assert
            Assert.That(totalActual, Is.EqualTo(totalEsperado));
        }

        [Test]
        public void CalcularTotal_ConDescuentoPorcentaje_DebeAplicarDescuentoEImpuestos()
        {
            // Arrange
            var pedido = CrearPedidoSimple();
            pedido.DescuentoAplicado = TipoDescuento.Porcentaje;
            pedido.ValorDescuento = 0.10m; // Ejemplo del 10%

            // Cálculo:
            // 1. Subtotal: 100.00
            // 2. Descuento: 100 * 0.10 = 10.00
            // 3. Subtotal con Descuento: 90.00
            // 4. Impuesto: 90.00 * 0.15 = 13.50
            // 5. Total Final: 90.00 + 13.50 = 103.50
            decimal totalEsperado = 103.50m;

            // Act
            decimal totalActual = _calculator.CalcularTotal(pedido);

            // Assert
            Assert.That(totalActual, Is.EqualTo(totalEsperado));
        }

        [Test]
        public void CalcularTotal_PedidoNulo_DebeLanzarExcepcion()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => _calculator.CalcularTotal(null!));
        }
    }
}
