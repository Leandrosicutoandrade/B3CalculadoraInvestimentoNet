
using Calcular.Investimento.Core.Application;
using Calcular.Investimento.Domain.Model;
using Calcular.Investimento.WebApi.Controllers;
using Moq;
using NUnit.Framework;
using System.Web.Http.Results;

namespace Calcular.Investimento.Test
{
    [TestFixture]
    public class CalculoControllerTests
    {
        private Mock<ICdbApplication> _cdbApplicationMock;
        private CalculoController _controller;

        [SetUp]
        public void SetUp()
        {
            _cdbApplicationMock = new Mock<ICdbApplication>();

            _controller = new CalculoController(_cdbApplicationMock.Object);
        }

        [Test]
        public void Get_ComParametros_ValoresInvalidos_DeveRetornarBadRequest()
        {
            // Act
            var result = _controller.Get(0, 0);

            // Assert
            Assert.IsInstanceOf<BadRequestErrorMessageResult>(result);
        }

        [Test]
        public void Get_ComParametros_ValoresValidos_DeveRetornarResultadoCalculo()
        {
            // Arrange
            var request = new CdbRequest { ValorInicial = 1000m, PrazoMeses = 12 };
            var expectedResponse = new CdbResponse { ValorLiquido = 1100m };
             
            _cdbApplicationMock.Setup(c => c.CalcularInvestimento(It.IsAny<CdbRequest>()))
                .Returns(expectedResponse);

            // Act
            var result = _controller.Get(1000m, 12) as OkNegotiatedContentResult<CdbResponse>;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(expectedResponse.ValorLiquido, result.Content.ValorLiquido);
        }
    }
}
