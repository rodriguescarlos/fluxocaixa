using Dapper;
using Fcx.Caixa.Application.Ports.Repository;
using Fcx.Caixa.Domain;
using Fcx.Library.Application.Port;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Fcx.Caixa.Infrastructure.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        public readonly MovimentoContext context;
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

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

        public async Task<IEnumerable<MovimentoConsolidado>> ObterConsolidado()
        {
            var sql = @$"SELECT		CONVERT(VARCHAR(10), DataMovimento, 121) DATAMOVIMENTO,
			            SUM(CASE WHEN LANC.TipoDC='D' THEN VALOR ELSE 0 END) DEBITO,
			            SUM(CASE WHEN LANC.TIPODC='C' THEN VALOR ELSE 0 END) CREDITO,
			            ABS(SUM(CASE WHEN LANC.TIPODC='D' THEN  VALOR * -1 ELSE VALOR END)) SALDO,
			            CASE WHEN (SUM(CASE WHEN LANC.TIPODC='D' THEN  VALOR * -1 ELSE VALOR END) < 0) THEN 'D' ELSE 'C' END TIPODC
                        FROM		Movimento MOV
                        INNER JOIN	Lancamento LANC
                        ON			MOV.LancamentoId = LANC.Identificador
                        GROUP BY	TipoDC
			                        ,CONVERT(VARCHAR(10), DataMovimento, 121)
            ";

            var query = await context.Database.GetDbConnection().QueryAsync<MovimentoConsolidado>(sql);

            return query;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
