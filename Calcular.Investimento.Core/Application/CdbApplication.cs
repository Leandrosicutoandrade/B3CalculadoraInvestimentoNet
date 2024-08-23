using Calcular.Investimento.Core.Service;
using Calcular.Investimento.Domain.Model;

namespace Calcular.Investimento.Core.Application
{
    public class CdbApplication : ICdbApplication
    {
        private readonly ICdbService _cdbService;
        private readonly IImpostoService _impostoService;

        public CdbApplication(ICdbService cdbService, IImpostoService impostoService)
        {
            _cdbService = cdbService;
            _impostoService = impostoService;
        }

        public CdbResponse CalcularInvestimento(CdbRequest request)
        {
            decimal cdi = 0.009m; // 0,9%
            decimal taxaBanco = 1.08m; // 108%

            decimal valorFinal = _cdbService.CalcularValorFinal(request.ValorInicial, request.PrazoMeses, cdi, taxaBanco);
            decimal imposto = _impostoService.CalcularImposto(valorFinal - request.ValorInicial, request.PrazoMeses);
            decimal valorLiquido = valorFinal - imposto;

            var resultado = new CdbResponse
            {
                ValorBruto = valorFinal,
                ValorLiquido = valorLiquido,
                ValorImposto = imposto,
                ValorInicial = request.ValorInicial,
                Cdi = cdi,
                TaxaBanco = taxaBanco,
                PrazoMes = request.PrazoMeses
            };

            return resultado;
        }
    }
}
