using Fcx.Caixa.Application.Ports.Repository;
using Fcx.Caixa.Application.UseCase.Movimento;
using Fcx.Caixa.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fcx.Caixa.Application.UseCase.Movimento
{
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
        }
    }
}
