using Fcx.Caixa.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcx.Caixa.Application.UseCase.Movimento.Queries
{
    public class MovimentoConsolidadoQuery : IRequest<IEnumerable<MovimentoConsolidado>>
    {
    }
}
