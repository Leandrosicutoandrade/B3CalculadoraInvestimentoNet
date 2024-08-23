using Calcular.Investimento.Domain.Model;

namespace Calcular.Investimento.Core.Application
{
    public interface ICdbApplication
    {
        CdbResponse CalcularInvestimento(CdbRequest request);
    }
}
