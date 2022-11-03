using EasyNetQ;
using Fcx.Library.Application.Messages;

namespace Fcx.Library.Infrastructure.Rabbitmq
{
    public interface IMessageBus : IDisposable
    {
        IAdvancedBus AdvancedBus { get; }

        void Publish<T>(T message) where T : EventBase;

        Task PublishAsync<T>(T message) where T : EventBase;

        void Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class;

        void SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class;

        TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : EventBase
            where TResponse : ResponseMessage;

        Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : EventBase
            where TResponse : ResponseMessage;

        IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : EventBase
            where TResponse : ResponseMessage;

        IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : EventBase
            where TResponse : ResponseMessage;
    }
}