using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcx.Caixa.Application.UseCase.Movimento.Event
{

    public class LancamentoNotExistEventHandler : INotificationHandler<LancamentoNotExistEvent>
    {
        public Task Handle(LancamentoNotExistEvent notification, CancellationToken cancellationToken)
        {
            // Enviar evento de confirmação
            return Task.CompletedTask;
        }
    }
}
