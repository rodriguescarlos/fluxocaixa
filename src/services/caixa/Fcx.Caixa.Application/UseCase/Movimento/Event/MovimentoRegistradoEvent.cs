
namespace Fcx.Caixa.Application.UseCase.Movimento
{
    public class MovimentacaoRegistradaEvent : Library.Application.Messages.Event
    {
        public decimal Valor { get; set; }
        public char TipoDC { get; set; }
        public DateTime DataMovimento { get; set; }

        public MovimentacaoRegistradaEvent(decimal valor, char tipoDC, DateTime dataMovmento)
        {
            Valor = valor;
            TipoDC = tipoDC;
            DataMovimento = dataMovmento;

        }
    }
}
