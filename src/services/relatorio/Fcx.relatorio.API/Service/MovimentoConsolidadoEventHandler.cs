using Fcx.Library.Application.Messages.Event;
using Fcx.Library.Infrastructure.MongoDB.Repository;
using Fcx.Library.Infrastructure.Rabbitmq;
using Fcx.relatorio.API.Model;

namespace Fcx.relatorio.API.Service
{
    public class MovimentoConsolidadoEventHandler : BackgroundService
    {
        private readonly IMessageBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public MovimentoConsolidadoEventHandler(IServiceProvider serviceProvider, IMessageBus bus)
        {
            _serviceProvider = serviceProvider;
            _bus = bus;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            SetSubscribers();
            return Task.CompletedTask;
        }

        private void SetSubscribers()
        {
            _bus.SubscribeAsync<MovimentoConsolidadoEvent>("MovimentoCaixa", async request =>
                await PersistirMovimento(request));
        }

        private async Task PersistirMovimento(MovimentoConsolidadoEvent message)
        {
            using var scope = _serviceProvider.CreateScope();
            var repository = scope.ServiceProvider.GetRequiredService<IMongoRepository<MovimentoConsolidado>>();

            var movimento = new MovimentoConsolidado(message.DataMovimento, message.Debito, message.Credito, message.Saldo, message.TipoDC);
            await repository.InsertOneAsync(movimento);
        }
    }
}
