
namespace Calcular.Investimento.Core.Service
{
    public interface IImpostoService
    {
        decimal CalcularImposto(decimal rendimento, int meses);
    }
}
