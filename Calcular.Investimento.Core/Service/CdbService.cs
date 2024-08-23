
namespace Calcular.Investimento.Core.Service
{
    public class CdbService : ICdbService
    {
        public decimal CalcularValorFinal(decimal valorInicial, int meses, decimal cdi, decimal taxaBanco)
        {
            var valor = CalcularValorFinalPorMeses(valorInicial, meses, cdi, taxaBanco);
            return valor;
        }
        public decimal CalcularValorFinalPorMeses(decimal valorInicial, int meses, decimal cdi, decimal taxaBanco)
        {
            decimal valor = valorInicial;

            for (int i = 0; i < meses; i++)
            {
                valor *= 1 + (cdi * taxaBanco);
            }
            return valor;
        }

    }
}
