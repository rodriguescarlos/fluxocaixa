using Fcx.Caixa.Infrastructure;
using System.Data.Entity;

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

app.MapGet("/cfx/relatorio/movimentacao",
    async (MovimentoContext context) =>
    {
        await context.Movimentos.ToListAsync();
    }
).WithName("ConsolidadoDia")
.WithTags("MovimentacaoCaixa");

app.Run();

