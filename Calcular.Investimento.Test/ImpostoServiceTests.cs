
using Calcular.Investimento.Core.Service;
using NUnit.Framework;

namespace Calcular.Investimento.Test
{
    [TestFixture]
    public class ImpostoServiceTests
    {
        private ImpostoService _impostoService;

        [SetUp]
        public void SetUp()
        {
            _impostoService = new ImpostoService();
        }

        [Test]
        public void CalcularImposto_MesesMenorOuIgualA6_DeveAplicarAliquotaDe225()
        {
            // Arrange
            decimal rendimento = 1000m;
            int meses = 6;
            decimal aliquotaEsperada = 0.225m;
            decimal impostoEsperado = rendimento * aliquotaEsperada;

            // Act
            var resultado = _impostoService.CalcularImposto(rendimento, meses);

            // Assert
            Assert.AreEqual(impostoEsperado, resultado);
        }

        [Test]
        public void CalcularImposto_MesesEntre7e12_DeveAplicarAliquotaDe20()
        {
            // Arrange
            decimal rendimento = 1000m;
            int meses = 12;
            decimal aliquotaEsperada = 0.20m;
            decimal impostoEsperado = rendimento * aliquotaEsperada;

            // Act
            var resultado = _impostoService.CalcularImposto(rendimento, meses);

            // Assert
            Assert.AreEqual(impostoEsperado, resultado);
        }

        [Test]
        public void CalcularImposto_MesesEntre13e24_DeveAplicarAliquotaDe175()
        {
            // Arrange
            decimal rendimento = 1000m;
            int meses = 24;
            decimal aliquotaEsperada = 0.175m;
            decimal impostoEsperado = rendimento * aliquotaEsperada;

            // Act
            var resultado = _impostoService.CalcularImposto(rendimento, meses);

            // Assert
            Assert.AreEqual(impostoEsperado, resultado);
        }

        [Test]
        public void CalcularImposto_MesesMaiorQue24_DeveAplicarAliquotaDe15()
        {
            // Arrange
            decimal rendimento = 1000m;
            int meses = 25;
            decimal aliquotaEsperada = 0.15m;
            decimal impostoEsperado = rendimento * aliquotaEsperada;

            // Act
            var resultado = _impostoService.CalcularImposto(rendimento, meses);

            // Assert
            Assert.AreEqual(impostoEsperado, resultado);
        }

        [Test]
        public void CalcularImposto_RendimentoZero_DeveRetornarZero()
        {
            // Arrange
            decimal rendimento = 0m;
            int meses = 10;

            // Act
            var resultado = _impostoService.CalcularImposto(rendimento, meses);

            // Assert
            Assert.AreEqual(0m, resultado);
        }
    }
}