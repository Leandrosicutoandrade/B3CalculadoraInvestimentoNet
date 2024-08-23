using Calcular.Investimento.Core.Service;
using NUnit.Framework;

namespace Calcular.Investimento.Test
{
    [TestFixture]
    public class CdbServiceTests
    {
        private CdbService _cdbService;

        [SetUp]
        public void SetUp()
        {
            _cdbService = new CdbService();
        }

        [Test]
        public void CalcularValorFinal_ValoresValidos_DeveRetornarResultadoEsperado()
        {
            // Arrange
            decimal valorInicial = 1000m;
            int meses = 12;
            decimal cdi = 0.009m;
            decimal taxaBanco = 1.08m;

            decimal valorEsperado = _cdbService.CalcularValorFinalPorMeses(valorInicial, meses, cdi, taxaBanco);

            // Act
            var resultado = _cdbService.CalcularValorFinal(valorInicial, meses, cdi, taxaBanco);

            // Assert
            Assert.AreEqual(valorEsperado, resultado);
        }

        [Test]
        public void CalcularValorFinalPorMeses_12Meses_DeveRetornarValorFinalCorreto()
        {
            // Arrange
            decimal valorInicial = 1000m;
            int meses = 12;
            decimal cdi = 0.009m;
            decimal taxaBanco = 1.08m;

            decimal valorEsperado = valorInicial;
            for (int i = 0; i < meses; i++)
            {
                valorEsperado *= 1 + (cdi * taxaBanco);
            }

            // Act
            var resultado = _cdbService.CalcularValorFinalPorMeses(valorInicial, meses, cdi, taxaBanco);

            // Assert
            Assert.AreEqual(valorEsperado, resultado);
        }

        [Test]
        public void CalcularValorFinalPorMeses_MesesZero_DeveRetornarValorInicial()
        {
            // Arrange
            decimal valorInicial = 1000m;
            int meses = 0;
            decimal cdi = 0.009m;
            decimal taxaBanco = 1.08m;

            // Act
            var resultado = _cdbService.CalcularValorFinalPorMeses(valorInicial, meses, cdi, taxaBanco);

            // Assert
            Assert.AreEqual(valorInicial, resultado);
        }

        [Test]
        public void CalcularValorFinalPorMeses_ValoresNegativos_DeveRetornarValorCorreto()
        {
            // Arrange
            decimal valorInicial = -1000m;
            int meses = 12;
            decimal cdi = 0.009m;
            decimal taxaBanco = 1.08m;

            decimal valorEsperado = valorInicial;
            for (int i = 0; i < meses; i++)
            {
                valorEsperado *= 1 + (cdi * taxaBanco);
            }

            // Act
            var resultado = _cdbService.CalcularValorFinalPorMeses(valorInicial, meses, cdi, taxaBanco);

            // Assert
            Assert.AreEqual(valorEsperado, resultado);
        }
    }
}
