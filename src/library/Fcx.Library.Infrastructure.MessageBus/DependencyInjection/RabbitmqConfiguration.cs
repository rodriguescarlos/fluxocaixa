using Fcx.Library.Infrastructure.Rabbitmq.Factory;
using Microsoft.Extensions.DependencyInjection;

namespace Fcx.Library.Infrastructure.Rabbitmq.DependencyInjection
{
    public static class RabbitmqConfiguration
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
        {
            if (string.IsNullOrEmpty(connection)) throw new ArgumentNullException(nameof(connection));

            services.AddSingleton<IMessageBus, MessageBus>();
            services.AddSingleton<IMessangerConnectionFactory>(new MessangerConnectionFactory(connection));

            return services;
        }
    }
}