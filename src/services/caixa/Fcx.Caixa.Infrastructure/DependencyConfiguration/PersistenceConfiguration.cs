using Fcx.Caixa.Application.Ports.Repository;
using Fcx.Caixa.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fcx.Caixa.Infrastructure.DependencyConfiguration
{

    public static class PersistenceConfiguration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovimentoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SqlServer")));

            services.AddScoped<IMovimentoRepository, MovimentoRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<MovimentoContext>();

        }
    }
}
