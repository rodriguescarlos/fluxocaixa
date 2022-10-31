namespace Fcx.Caixa.API.Model
{
    public class MovimentacaoDTO
    {
        public decimal Valor { get; set; }
        public short CodigoLancamento { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}
