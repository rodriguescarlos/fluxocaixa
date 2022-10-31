using Fcx.Library.Infrastructure.Rabbitmq;
using Microsoft.Extensions.DependencyInjection;

namespace Fcx.Library.Innfrastructure.Rabbitmq
{
    public static class DependencyInjectionExtensions
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