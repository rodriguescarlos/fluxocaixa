using Fcx.Caixa.Domain;
using Fcx.Library.Application.Messages;

namespace Fcx.Caixa.Application.UseCase.Movimento
{
    public class RegistrarMovimentoCommand : Command
    {
        public Guid Id { get; private set; }
        public int CodigoMovimento { get; set; }
        public decimal Valor { get; private set; }
        public short CodigoLancamento { get; private set; }

        public RegistrarMovimentoCommand(Guid traceId, int codigoMovimento, decimal valor, short codigoLancamento)
        {
            TraceId = traceId;
            CodigoMovimento = codigoMovimento;
            Valor = valor;
            CodigoLancamento = codigoLancamento;
        }

        public override bool EhValido()
        {
            ValidationResult = new RegistrarMovimentoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
