using MediatR;

namespace Fcx.Caixa.Application.UseCase.Movimento
{
    public class MovimentacaoRegistradaEventHandler : INotificationHandler<MovimentacaoRegistradaEvent>
    {
        public Task Handle(MovimentacaoRegistradaEvent notification, CancellationToken cancellationToken)
        {
            // Enviar evento de confirmação
            return Task.CompletedTask;
        }
    }
}
