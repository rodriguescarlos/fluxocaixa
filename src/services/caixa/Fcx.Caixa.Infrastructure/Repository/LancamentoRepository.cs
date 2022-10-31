using Fcx.Caixa.Domain;
using Fcx.Caixa.Application.Ports.Repository;
using Fcx.Library.Application.Port;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Fcx.Caixa.Infrastructure.Repository
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();
        public readonly MovimentoContext context;

        public LancamentoRepository(MovimentoContext context)
        {
            this.context = context;
        }

        public void Adicionar(Lancamento lancamento)
        {
            context.Lancamentos.Add(lancamento);
        }

        public async Task<Lancamento> ObterPorCodigo(int CodigoLancamento)
        {
            return await context.Lancamentos.FirstOrDefaultAsync(a => a.CodigoLancamento == CodigoLancamento);
        }

        public async Task<IEnumerable<Lancamento>> ObterTodos()
        {
            return await context.Lancamentos.ToListAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

}
