using EasyNetQ;
using Polly;
using RabbitMQ.Client.Exceptions;

namespace Fcx.Library.Infrastructure.Rabbitmq
{
    public class MessangerConnectionFactory : IMessangerConnectionFactory
    {
        private readonly string connectionString;
        private IBus messanger;
        private IAdvancedBus advancedMessanger;

        public IAdvancedBus AdvancedMessanger => messanger?.Advanced;

        public bool IsConnected => messanger?.Advanced.IsConnected ?? false;

        public MessangerConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Construtor criado apenas para efeito de testes
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="advancedBus"></param>
        public MessangerConnectionFactory(IBus bus, IAdvancedBus advancedBus, string connectionString)
        {
            this.messanger = bus;
            this.advancedMessanger = advancedBus;
            this.connectionString = connectionString;
        }

        /// <summary>
        /// 
        /// </summary>
        public IBus Create()
        {
            if (string.IsNullOrEmpty(this.connectionString)) throw new ApplicationException("ConnectionString não informada.");

            messanger = RabbitHutch.CreateBus(connectionString);
            advancedMessanger = messanger.Advanced;

            return messanger;
        }



        public void Dispose()
        {
            messanger.Dispose();
        }

    }
}
