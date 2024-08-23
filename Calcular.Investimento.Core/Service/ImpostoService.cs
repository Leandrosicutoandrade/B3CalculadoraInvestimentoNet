
namespace Calcular.Investimento.Core.Service
{
    public class ImpostoService : IImpostoService
    {
        public decimal CalcularImposto(decimal rendimento, int meses)
        {
            decimal aliquota;

            if (meses <= 6)
                aliquota = 0.225m; // 22,5%
            else if (meses <= 12)
                aliquota = 0.20m; // 20%
            else if (meses <= 24)
                aliquota = 0.175m; // 17,5%
            else
                aliquota = 0.15m; // 15%

            return rendimento * aliquota;
        }
    }
}
