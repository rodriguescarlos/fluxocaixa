using EasyNetQ;
using Polly;
using RabbitMQ.Client.Exceptions;
using Fcx.Library.Application.Messages;
using Fcx.Library.Infrastructure.Rabbitmq.Factory;

namespace Fcx.Library.Infrastructure.Rabbitmq
{
    public class MessageBus : IMessageBus
    {
        private readonly IMessangerConnectionFactory factory;
        private IBus messanger;

        public IAdvancedBus AdvancedBus => this.messanger.Advanced;

        public MessageBus(IMessangerConnectionFactory factory)
        {
            this.factory = factory;
            TryConnect();
        }

        public void Publish<T>(T message) where T : EventBase
        {
            TryConnect();
            messanger.PubSub.Publish(message);
        }

        public async Task PublishAsync<T>(T message) where T : EventBase
        {
            TryConnect();
            await messanger.PubSub.PublishAsync(message);
        }

        public void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
        {
            TryConnect();
            messanger.PubSub.Subscribe(subscriptionId, onMessage);
        }

        public void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            TryConnect();
            messanger.PubSub.SubscribeAsync(subscriptionId, onMessage);
        }

        public TResponse Request<TRequest, TResponse>(TRequest request) where TRequest : EventBase
            where TResponse : ResponseMessage
        {
            TryConnect();
            return messanger.Rpc.Request<TRequest, TResponse>(request);
        }

        public async Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : EventBase where TResponse : ResponseMessage
        {
            TryConnect();
            return await messanger.Rpc.RequestAsync<TRequest, TResponse>(request);
        }

        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : EventBase where TResponse : ResponseMessage
        {
            TryConnect();
            return messanger.Rpc.Respond(responder);
        }

        public IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : EventBase where TResponse : ResponseMessage
        {
            TryConnect();
            return messanger.Rpc.RespondAsync(responder).AsTask();
        }

        public void TryConnect()
        {
            if (factory.IsConnected && messanger != null) return;

            var policy = Policy.Handle<EasyNetQException>()
                .Or<BrokerUnreachableException>()
                .WaitAndRetry(3, retryAttempt =>
                    TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            policy.Execute(() =>
            {
                this.messanger = factory.Create();
                this.factory.AdvancedMessanger.Disconnected += OnDisconnect;
            });
        }

        private void OnDisconnect(object s, EventArgs e)
        {
            var policy = Policy.Handle<EasyNetQException>()
                .Or<BrokerUnreachableException>()
                .RetryForever();

            policy.Execute(TryConnect);
        }

        public void Dispose()
        {
            factory.Dispose();
        }
    }
}