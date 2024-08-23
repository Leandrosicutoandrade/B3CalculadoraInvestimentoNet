
namespace Calcular.Investimento.Domain.Model
{
    public class CdbResponse
    {
        public decimal? ValorInicial { get; set; }
        public int PrazoMes { get; set; }
        public decimal? ValorBruto { get; set; }
        public decimal? ValorImposto { get; set; }
        public decimal? ValorLiquido { get; set; }
        public decimal? Cdi { get; set; }
        public decimal? TaxaBanco { get; set; }
    }
}
