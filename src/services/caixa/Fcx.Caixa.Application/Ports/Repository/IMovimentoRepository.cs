using Fcx.Caixa.Domain;
using Fcx.Library.Application.Messages.Event;
using Fcx.Library.Application.Port;

namespace Fcx.Caixa.Application.Ports.Repository
{
    public interface IMovimentoRepository : IRepository<Movimento>
    {
        void Adicionar(Movimento movimento);

        Task<IEnumerable<Movimento>> ObterTodos();

        Task<MovimentoConsolidadoEvent> ObterConsolidadoDia(DateTime dataMovimento);
    }

}
