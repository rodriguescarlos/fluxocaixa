using Fcx.Caixa.Domain;
using MediatR;

namespace Fcx.Caixa.Application.UseCase.Movimento.Queries
{
    public class MovimentoConsolidadoDiaQuery : IRequest<IEnumerable<MovimentoConsolidado>>
    {
        public DateTime DataMovimento { get; set; }
    }
}
