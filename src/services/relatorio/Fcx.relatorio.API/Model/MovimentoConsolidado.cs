using Fcx.Library.Infrastructure.MongoDB;

namespace Fcx.relatorio.API.Model
{
    [BsonCollection("MovimentoConsolidado")]
    public class MovimentoConsolidado : Document
    {
        public DateTime DataMovimento { get; set; }
        public decimal Debito { get; set; }
        public decimal Credito { get; set; }
        public decimal Saldo { get; set; }
        public char TipoDC { get; set; }

        public MovimentoConsolidado(DateTime dataMovimento, decimal debito, decimal credito, decimal saldo, char tipoDC)
        {
            DataMovimento = dataMovimento;
            Debito = debito;
            Credito = credito;
            Saldo = saldo;
            TipoDC = tipoDC;
        }
    }
}
