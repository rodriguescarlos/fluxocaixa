namespace Fcx.Library.Application.Messages.Event
{
    public class MovimentoRegistradoEvent : EventBase
    {
        public Guid Id { get; set; }
        public decimal Valor { get; set; }
        public char TipoDC { get; set; }
        public DateTime DataMovimento { get; set; }

        public MovimentoRegistradoEvent(Guid Id, decimal valor, char tipoDC, DateTime dataMovmento)
        {
            this.Id = Id;
            Valor = valor;
            TipoDC = tipoDC;
            DataMovimento = dataMovmento;

        }
    }
}
