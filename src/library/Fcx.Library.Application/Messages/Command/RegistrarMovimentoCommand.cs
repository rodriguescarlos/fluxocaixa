using Fcx.Library.Application.Messages;
using FluentValidation;

namespace Fcx.Library.Application.Messages.Command
{
    public class RegistrarMovimentoCommand : CommandBase
    {
        public Guid Id { get; private set; }
        public decimal Valor { get; private set; }
        public int CodigoLancamento { get; set; }

        public RegistrarMovimentoCommand(decimal valor, short codigoLancamento, Guid? traceId = null, IDictionary<string,string>? headers = null)
        {
            TraceId = traceId ?? TraceId;
            additionalHeaders = headers ?? headers;

            Valor = valor;
            CodigoLancamento = codigoLancamento;
        }
        public override bool EhValido()
        {
            ValidationResult = new RegistrarMovimentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class RegistrarMovimentoValidation : AbstractValidator<RegistrarMovimentoCommand>
    {
        public RegistrarMovimentoValidation()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do movimento inválido");

            RuleFor(c => c.Valor)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("O Valor da movimentação deve ser maior que zero.");

            RuleFor(c => c.CodigoLancamento)
                .GreaterThan(0)
                .WithMessage("Campo CodigoLancamentoO deve ser informado.");
        }
    }
}
