using Fcx.Caixa.API.Model;
using Fcx.Library.Application.Mediator;
using Fcx.Library.Application.Messages.Command;
using MiniValidation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/cfx/controlecaixa/movimentacao", async (
    IMediatorHandler mediator,
    MovimentoDTO movimento) =>
{
    if (!MiniValidator.TryValidate(movimento, out var erros))
        return Results.ValidationProblem(erros);


    var result = await mediator.EnviarComando(new RegistrarMovimentoCommand(
        movimento.Valor,
        movimento.CodigoLancamento
        ));

    return result.Errors.Count > 0
        ? Results.BadRequest("Houve um problema ao salvar o movimento")
        : Results.CreatedAtRoute();

}).ProducesValidationProblem()
    .Produces<RegistrarMovimentoCommand>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound)
    .WithName("Registrar")
    .WithTags("MovimentoCaixa");

app.Run();
