using Fcx.Caixa.Domain;
using Fcx.Library.Application.Port;

namespace Fcx.Caixa.Application.Ports.Repository
{
    public interface ILancamentoRepository : IRepository<Lancamento>
    {
        void Adicionar(Lancamento lancamento);

        Task<IEnumerable<Lancamento>> ObterTodos();

        Task<Lancamento> ObterPorCodigo(int CodigoLancamento);
    }
}
