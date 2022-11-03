using Fcx.Caixa.Application.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fcx.Caixa.Infrastructure.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddServiceHandle(configuration);

            return services;
        }
    }
}
