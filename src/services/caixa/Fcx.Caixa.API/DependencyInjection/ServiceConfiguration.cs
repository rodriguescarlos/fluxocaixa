using Fcx.Library.Application.Mediator;

namespace Fcx.Caixa.API.DependencyInjection
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            return services;
        }
        
    }
}
