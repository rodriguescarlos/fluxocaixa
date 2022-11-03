using Dapper;
using Fcx.Caixa.Application.Ports.Repository;
using Fcx.Caixa.Domain;
using Fcx.Library.Application.Messages.Event;
using Fcx.Library.Application.Port;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Fcx.Caixa.Infrastructure.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        public readonly MovimentoContext context;

        public IUnitOfWork UnitOfWork => context;


        public MovimentoRepository(MovimentoContext context)
        {
            this.context = context;
        }

        public void Adicionar(Movimento movimento)
        {
            context.Movimentos.Add(movimento);
        }

        public async Task<IEnumerable<Movimento>> ObterTodos()
        {
            return await context.Movimentos.ToListAsync();
        }

        public async Task<MovimentoConsolidadoEvent> ObterConsolidadoDia(DateTime dataMovimento)
        {
            var sql = @$"SELECT		CONVERT(VARCHAR(10), DataMovimento, 121) DataMovimento,
			            SUM(CASE WHEN LANC.TipoDC='D' THEN VALOR ELSE 0 END) Debito,
			            SUM(CASE WHEN LANC.TIPODC='C' THEN VALOR ELSE 0 END) Credito,
			            ABS(SUM(CASE WHEN LANC.TIPODC='D' THEN  VALOR * -1 ELSE VALOR END)) Saldo,
			            CASE WHEN (SUM(CASE WHEN LANC.TIPODC='D' THEN  VALOR * -1 ELSE VALOR END) < 0) THEN 'D' ELSE 'C' END TipoDC
                        FROM		Movimento MOV
                        INNER JOIN	Lancamento LANC
                        ON			MOV.LancamentoId = LANC.Identificador
                        WHERE       CONVERT(VARCHAR(10),DataMovimento,121) = CONVERT(VARCHAR(10), @DataMovimento, 121)
                        GROUP BY	TipoDC
			                        ,CONVERT(VARCHAR(10), DataMovimento, 121)
             ";

        var query = await context.Database.GetDbConnection().QueryAsync<MovimentoConsolidadoEvent>(sql, new { dataMovimento });

            return query.FirstOrDefault()!;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
