using EasyNetQ;

namespace Fcx.Library.Infrastructure.Rabbitmq.Factory
{
    public interface IMessangerConnectionFactory : IDisposable
    {
        IAdvancedBus AdvancedMessanger { get; }

        bool IsConnected { get; }

        IBus Create();
    }
}