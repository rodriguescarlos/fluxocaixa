using Fcx.Library.Application.Messages.Event;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcx.Caixa.Application.UseCase.Movimento.Event
{
    internal class MovimentoConsolidadoEventHandler : INotificationHandler<MovimentoConsolidadoEvent>
    {
        public Task Handle(MovimentoConsolidadoEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
