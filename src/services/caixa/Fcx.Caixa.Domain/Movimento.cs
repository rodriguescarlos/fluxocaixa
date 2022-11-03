using Fcx.Library.Domain;

namespace Fcx.Caixa.Domain
{
    public class Movimento : Entity, IAggregateRoot
    {
        public decimal Valor { get; set; }

        public DateTime DataMovimento { get; set; }

        public Guid LancamentoId { get; set; }

        public Lancamento Lancamento { get; private set; }

        public void AtribuirLancamento(int codigoLancamento)
        {
            Lancamento = new Lancamento(codigoLancamento);
        }

        public Movimento(decimal valor, int codigoLancamento)
        {
            this.Valor = valor;
            this.DataMovimento = DateTime.Now;
            this.AtribuirLancamento(codigoLancamento);
        }

        //Construtor para o EF

        public Movimento(){

        }
    }
}
