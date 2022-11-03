using Fcx.Caixa.Application.UseCase.Movimento;
using Fcx.Caixa.Application.UseCase.Movimento.Event;
using Fcx.Library.Application.Mediator;
using Fcx.Library.Application.Messages.Command;
using Fcx.Library.Application.Messages.Event;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace Fcx.Caixa.Application.DependencyInjection
{
    public static class ServiceHandleConfiguration
    {
        public static IServiceCollection AddServiceHandle(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<RegistrarMovimentoCommand, ValidationResult>, RegistrarMovimentoCommandHandler>();

            services.AddScoped<INotificationHandler<MovimentoRegistradoEvent>, MovimentacaoRegistradaEventHandler>();
            services.AddScoped<INotificationHandler<MovimentoConsolidadoEvent>, MovimentoConsolidadoEventHandler>();

            return services;
        }
    }
}
