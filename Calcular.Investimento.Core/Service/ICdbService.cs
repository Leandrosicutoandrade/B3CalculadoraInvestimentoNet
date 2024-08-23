using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calcular.Investimento.Core.Service
{
    public interface ICdbService
    {
        decimal CalcularValorFinal(decimal valorInicial, int meses, decimal cdi, decimal taxaBanco);
        decimal CalcularValorFinalPorMeses(decimal valorInicial, int meses, decimal cdi, decimal taxaBanco);
    }
}
