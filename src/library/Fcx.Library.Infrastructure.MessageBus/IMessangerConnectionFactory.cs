using EasyNetQ;

namespace Fcx.Library.Infrastructure.Rabbitmq
{
    public interface IMessangerConnectionFactory : IDisposable
    {
        IAdvancedBus AdvancedMessanger { get; }

        bool IsConnected { get; }

        IBus Create();
    }
}