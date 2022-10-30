using EasyNetQ;
using Fcx.Library.Application.Messages.Integration;
using Fcx.Library.Infrastructure.Rabbitmq;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using RabbitMQ.Client.Exceptions;
using Xunit;

namespace Fcx.Library.Infrrastructure.Rabbitmq.Tests
{
    public class MessageBusTests
    {
        private IMessageBus messageBus;
        private IAdvancedBus advancedMessageBus = Substitute.For<IAdvancedBus>();
        private IBus bus = Substitute.For<IBus>();

        public MessageBusTests()
        {

        }

        [Fact(DisplayName = "ConnectionString não informada.")]
        public void Create_ConnectionStringNaoInformada()
        {
            //Contexto
            IMessangerConnectionFactory connection = Substitute.For<MessangerConnectionFactory>(bus, advancedMessageBus, string.Empty);

            //Ação - alvo
            var exception = Assert.Throws<ApplicationException>(() => messageBus = new MessageBus(connection));

            //Verificação
            string mensagem = "ConnectionString não informada.";
            Assert.Equal(mensagem, exception.Message);
        }

        [Fact(DisplayName = "Publicando evento")]
        public void PublicandoEvento_Connectado()
        {
            //Contexto
            var connectionString = "teste";
            IMessangerConnectionFactory connection = Substitute.For<IMessangerConnectionFactory>();
            connection.Create().Returns(bus);
            connection.IsConnected.Returns(true);
            messageBus = new MessageBus(connection);

            var evento = Substitute.For<IntegrationEvent>();

            //Ação - alvo
            messageBus.Publish(evento);

            //Verificação
            bus.Received(1).PubSub.Publish(evento, evento.GetType());
            connection.Received(1).Create();
        }

        [Fact(DisplayName = "Publicando evento com o Bus desconectado")]
        public void PublicandoEvento_Desconectado()
        {
            //Contexto
            IMessangerConnectionFactory connection = Substitute.For<IMessangerConnectionFactory>();
            connection.IsConnected.Returns(false);
            connection.Create().Returns(bus);

            messageBus = new MessageBus(connection);
            var evento = Substitute.For<IntegrationEvent>();

            //Ação - alvo
            messageBus.Publish(evento);

            //Verificação
            bus.Received(1).PubSub.Publish(evento, evento.GetType());
            connection.Received(2).Create();
        }

        [Fact(DisplayName = "Publicando evento com o Bus desconectado - Erro após 3 tentativas")]
        public void PublicandoEvento_Retry()
        {
            //Contexto
            IMessangerConnectionFactory connection = Substitute.For<IMessangerConnectionFactory>();
            connection.IsConnected.Returns(false);

            var mensagemErro = "Limite de tentativas de conexão esgotou.";

            messageBus = new MessageBus(connection);
            
            var evento = Substitute.For<IntegrationEvent>();
            connection.Create().Throws(new EasyNetQException(mensagemErro));
            //Ação - alvo

            var exception = Assert.Throws<EasyNetQException>(() => messageBus.Publish(evento));

            //Verificação
            Assert.Equal(mensagemErro, exception.Message);
            connection.Received(5).Create();
        }
    }
}
