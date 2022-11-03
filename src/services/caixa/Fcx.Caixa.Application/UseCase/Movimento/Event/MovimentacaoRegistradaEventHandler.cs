using Fcx.Library.Application.Messages.Event;
using MediatR;

namespace Fcx.Caixa.Application.UseCase.Movimento
{
    public class MovimentacaoRegistradaEventHandler : INotificationHandler<MovimentoRegistradoEvent>
    {
        public Task Handle(MovimentoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            // Enviar evento de confirmação
            return Task.CompletedTask;
        }
    }
}
