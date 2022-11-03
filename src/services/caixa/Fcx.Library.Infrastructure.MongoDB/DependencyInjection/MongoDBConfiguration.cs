using Fcx.Library.Infrastructure.MongoDB.Configuration;
using Fcx.Library.Infrastructure.MongoDB.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Fcx.Library.Infrastructure.MongoDB.DependencyInjection
{
    public static class MongoDBConfiguration
    {
        public static IServiceCollection AddMongoDB(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

            return services;
        }
    }
}
