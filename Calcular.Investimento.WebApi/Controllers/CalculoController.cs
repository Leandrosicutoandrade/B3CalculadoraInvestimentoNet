using Calcular.Investimento.Core.Application;
using Calcular.Investimento.Domain.Model;
using System.Web.Http;

namespace Calcular.Investimento.WebApi.Controllers
{
    public class CalculoController : ApiController
    {
        private readonly ICdbApplication _cdbApplication;

        public CalculoController(ICdbApplication cdbApplication)
        {
            _cdbApplication = cdbApplication;
        }

        [HttpGet]
        public IHttpActionResult Get(decimal valorInicial, int prazoMes)
        {
            if (valorInicial <= 0 || prazoMes < 1)
                return BadRequest("Valor inicial deve ser positivo e prazo maior que 1.");

            var request = new CdbRequest
            {
                ValorInicial = valorInicial,
                PrazoMeses = prazoMes
            };

            var result = _cdbApplication.CalcularInvestimento(request);

            return Ok(result);
        }

    }
}
