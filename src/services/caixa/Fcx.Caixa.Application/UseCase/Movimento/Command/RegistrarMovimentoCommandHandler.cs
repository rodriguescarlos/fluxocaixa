using Fcx.Caixa.Application.Ports.Repository;
using Fcx.Library.Application.Messages;
using FluentValidation.Results;
using MediatR;
using Fcx.Caixa.Domain;
using Fcx.Library.Application.Mediator;

namespace Fcx.Caixa.Application.UseCase.Movimento
{
    public class RegistrarMovimentoCommandHandler : CommandHandler,
        IRequestHandler<RegistrarMovimentoCommand, ValidationResult>
    {
        private readonly IMovimentoRepository movimentoRepository;
        private readonly ILancamentoRepository lancamentoRepository;
        private readonly IMediatorHandler mediatorHandler;

        public RegistrarMovimentoCommandHandler(IMovimentoRepository movimentoRepository, ILancamentoRepository lancamentoRepository, IMediatorHandler mediatorHandler)
        {
            this.movimentoRepository = movimentoRepository;
            this.lancamentoRepository = lancamentoRepository;
            this.mediatorHandler = mediatorHandler;
        }

        public async Task<ValidationResult> Handle(RegistrarMovimentoCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido()) return message.ValidationResult;

            var lancamento = await lancamentoRepository.ObterPorCodigo(message.CodigoLancamento);

            if (lancamento is null)
            {
                AdicionarErro("Lançamento não existe.");
                await mediatorHandler.PublicarEvento(new LancamentoNotExistEvent(message.TraceId, message.CodigoLancamento));
                return ValidationResult;
            }

            var movimento = new Domain.Movimento(message.CodigoMovimento, message.Valor, message.CodigoLancamento);

            movimentoRepository.Adicionar(movimento);

            await mediatorHandler.PublicarEvento(new MovimentacaoRegistradaEvent(
                movimento.Valor,
                lancamento.TipoDC,
                movimento.DataMovimento
                ));

            return await PersistirDados(movimentoRepository.UnitOfWork);
        }
    }
}
