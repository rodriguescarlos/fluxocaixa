using Fcx.Caixa.Domain;
using MediatR;
using System.Data;
using Dapper;

namespace Fcx.Caixa.Application.UseCase.Movimento.Queries
{
    public class MovimentoConsolidadoQueryHandler : IRequestHandler<MovimentoConsolidadoQuery, IEnumerable<MovimentoConsolidado>>
    {
        private readonly IDbConnection dbConnection;

        public MovimentoConsolidadoQueryHandler(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        
        private async Task<IEnumerable<MovimentoConsolidado>> ObterConsolidado()
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

            var query = await dbConnection.QueryAsync<MovimentoConsolidado>(sql);

            return query;
        }

        public Task<IEnumerable<MovimentoConsolidado>> Handle(MovimentoConsolidadoQuery request, CancellationToken cancellationToken)
        {
            return ObterConsolidado();
        }
    }
}
