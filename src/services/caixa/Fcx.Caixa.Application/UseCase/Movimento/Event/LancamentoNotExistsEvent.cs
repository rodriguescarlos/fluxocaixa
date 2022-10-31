
namespace Fcx.Caixa.Application.UseCase.Movimento
{
    public class LancamentoNotExistEvent : Library.Application.Messages.Event
    {
        public short CodigoLancamento { get; set; }

        public LancamentoNotExistEvent(Guid traceId, short codigoLancamento)
        {
            TraceId = traceId;
            CodigoLancamento = codigoLancamento;
        }
    }
}
