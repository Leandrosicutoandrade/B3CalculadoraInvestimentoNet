using Calcular.Investimento.Core.Application;
using Calcular.Investimento.Core.Service;
using Calcular.Investimento.Domain.Model;
using Moq;
using NUnit.Framework;
using System;

namespace Calcular.Investimento.Test
{
    [TestFixture]
    public class CdbApplicationTests
    {
        private Mock<ICdbService> _cdbServiceMock;
        private Mock<IImpostoService> _impostoServiceMock;
        private CdbApplication _cdbApplication;

        [SetUp]
        public void SetUp()
        {
            _cdbServiceMock = new Mock<ICdbService>();
            _impostoServiceMock = new Mock<IImpostoService>();

            _cdbApplication = new CdbApplication(_cdbServiceMock.Object, _impostoServiceMock.Object);
        }

        [Test]
        public void CalcularInvestimento_ValoresValidos_DeveRetornarResultadoEsperado()
        {
            // Arrange
            var request = new CdbRequest
            {
                ValorInicial = 1000m,
                PrazoMeses = 12
            };

            var valorFinalEsperado = 1200m;
            var impostoEsperado = 30m;

            _cdbServiceMock.Setup(s => s.CalcularValorFinal(request.ValorInicial, request.PrazoMeses, 0.009m, 1.08m))
                           .Returns(valorFinalEsperado);

            _impostoServiceMock.Setup(s => s.CalcularImposto(valorFinalEsperado - request.ValorInicial, request.PrazoMeses))
                               .Returns(impostoEsperado);

            // Act
            var result = _cdbApplication.CalcularInvestimento(request);

            // Assert
            Assert.AreEqual(valorFinalEsperado, result.ValorBruto);
            Assert.AreEqual(valorFinalEsperado - impostoEsperado, result.ValorLiquido);
            Assert.AreEqual(impostoEsperado, result.ValorImposto);
        }

        [Test]
        public void CalcularInvestimento_ValoresValidos_NaoDeveRetornarResultadoEsperado()
        {
            // Arrange
            var request = new CdbRequest
            {
                ValorInicial = 1000m,
                PrazoMeses = 12
            };

            var valorFinalEsperado = 1200m;
            var impostoEsperado = 30m;

            _cdbServiceMock.Setup(s => s.CalcularValorFinal(request.ValorInicial, request.PrazoMeses, 0.009m, 1.08m))
                           .Returns(valorFinalEsperado);

            _impostoServiceMock.Setup(s => s.CalcularImposto(valorFinalEsperado - request.ValorInicial, request.PrazoMeses))
                               .Returns(impostoEsperado);

            // Act
            var result = _cdbApplication.CalcularInvestimento(request);

            // Assert
            Assert.AreNotEqual(valorFinalEsperado, result.ValorBruto -1);
            Assert.AreNotEqual(valorFinalEsperado - impostoEsperado, result.ValorLiquido - 1);
            Assert.AreNotEqual(impostoEsperado, result.ValorImposto - 1);
        }
    }
}
