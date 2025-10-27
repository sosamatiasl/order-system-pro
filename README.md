# OrderSystem.Pro

## 🧪 Manual de Usuario: Sistema de Pedidos y Pruebas Unitarias

Este proyecto es una librería de clases, por lo que el manual se centra en cómo consumir la lógica y cómo ejecutar las pruebas de calidad.

**Objetivo:**
Demostrar la robustez y calidad de la lógica central de negocio (cálculo de totales, impuestos y descuentos) a través de pruebas unitarias exhaustivas.

Uso del Componente Core (OrderSystem.Core) 
La clase central es CalculadoraTotal, que debe ser inicializada con las estrategias de descuento disponibles.

Clase "Pedido" --> Método principal "CalcularSubtotal()": Obtiene la suma de todos los DetallePedido antes de descuentos e impuestos.

Clase "CalculadoraTotal" --> Método principal "CalcularTotal(Pedido pedido)": Calcula el valor final aplicando la Estrategia de Descuento definida en el Pedido y la Tasa de Impuestos fija.

### 💻 Consumo del Servicio (Ejemplo en una aplicación principal)
**C#**
```
// 1. Configurar las estrategias disponibles
var strategies = new List<IDescuentoStrategy>
{
    new DescuentoPorcentajeStrategy(),
    // Añadir DescuentoFijoStrategy, etc.
};

// 2. Crear el servicio de cálculo
var calculadora = new CalculadoraTotal(strategies);

// 3. Crear el pedido
var pedido = new Pedido 
{
    Items = { new DetallePedido { PrecioUnitario = 100m, Cantidad = 1 } },
    DescuentoAplicado = TipoDescuento.Porcentaje,
    ValorDescuento = 0.05m // 5%
};

// 4. Obtener el resultado
decimal total = calculadora.CalcularTotal(pedido);
```

Ejecución de Pruebas de Calidad (NUnit)
La calidad del sistema se verifica ejecutando las pruebas unitarias.
1. Abrir Visual Studio: Cargue la solución OrderSystem.Pro.
2. Acceder al Explorador de Pruebas: Vaya a Test (Prueba) → Test Explorer (Explorador de pruebas).
3. Ejecutar Pruebas:
   3.1 Haga clic derecho sobre el proyecto OrderSystem.Tests o sobre la clase CalculadoraTests.
   3.2 Seleccione Run (Ejecutar).

El resultado esperado es que todas las pruebas (incluyendo el manejo de excepciones como ArgumentNullException) pasen, lo que garantiza que la lógica de cálculo es precisa y robusta.
