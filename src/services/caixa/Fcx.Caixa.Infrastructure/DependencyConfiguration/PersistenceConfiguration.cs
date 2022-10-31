using Fcx.Caixa.Application.Ports.Repository;
using Fcx.Caixa.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Fcx.Caixa.Infrastructure.DependencyConfiguration
{

    public static class PersistenceConfiguration
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("SqlServer");
            services.AddDbContext<MovimentoContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IMovimentoRepository, MovimentoRepository>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<MovimentoContext>();

            services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));
        }
    }
}
