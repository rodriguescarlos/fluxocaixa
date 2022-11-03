using Fcx.Caixa.Application.Ports.Repository;
using Fcx.Library.Application.Messages;
using FluentValidation.Results;
using MediatR;
using Fcx.Library.Application.Mediator;
using Fcx.Library.Application.Messages.Command;
using Fcx.Library.Application.Messages.Event;

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
                AdicionarErro("Lançamento informado não existe.");
                return this.ValidationResult;
            }

            var movimento = new Domain.Movimento(message.Valor, message.CodigoLancamento);

            movimentoRepository.Adicionar(movimento);

            var result = await PersistirDados(movimentoRepository.UnitOfWork);

            if(result.Errors.Count > 0)
            {
                AdicionarErro(result.Errors);
                return this.ValidationResult;
            }

            //Notifica registro da movimentacao como ok
            await mediatorHandler.PublicarEvento(new MovimentoRegistradoEvent(
                movimento.Identificador,
                movimento.Valor,
                lancamento.TipoDC,
                movimento.DataMovimento
                ));

            try
            {
                //Obtem o consolidado até o momento e dispara o evento
                var consolidado = await movimentoRepository.ObterConsolidadoDia(movimento.DataMovimento);

                await mediatorHandler.PublicarEvento(new MovimentoConsolidadoEvent(
                    message.TraceId,
                    consolidado.DataMovimento.Date,
                    consolidado.Credito,
                    consolidado.Debito,
                    consolidado.Saldo,
                    consolidado.TipoDC
                ));
            }catch(Exception ex)
            {
                //registrar erro no log e não para o fluxo
            }

            return this.ValidationResult;
        }
    }
}
