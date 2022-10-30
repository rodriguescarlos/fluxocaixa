using System.Threading.Tasks;
using Fcx.Library.Application.Messages;
using FluentValidation.Results;

namespace Fcx.Library.Application.Mediator
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
    }
}