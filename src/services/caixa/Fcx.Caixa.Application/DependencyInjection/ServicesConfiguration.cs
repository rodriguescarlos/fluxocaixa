using Fcx.Caixa.Application.UseCase.Movimento;
using Fcx.Caixa.Application.UseCase.Movimento.Event;
using Fcx.Library.Application.Mediator;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Fcx.Caixa.Application.DependencyInjection
{
    public static class ServicesConfiguration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<RegistrarMovimentoCommand, ValidationResult>, RegistrarMovimentoCommandHandler>();

            services.AddScoped<INotificationHandler<MovimentacaoRegistradaEvent>, MovimentacaoRegistradaEventHandler>();
            services.AddScoped<INotificationHandler<LancamentoNotExistEvent>, LancamentoNotExistEventHandler>();
        }
    }
}
