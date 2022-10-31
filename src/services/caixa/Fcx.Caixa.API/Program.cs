using Fcx.Caixa.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MovimentoContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/cfx/controlecaixa/movimentacao", () =>
{

}).WithName("Registrar");

app.MapGet("/cfx/relatorio/movimentacao",
    async (MovimentoContext context) =>
{
    await context.Movimentos.ToListAsync();
}
).WithName("ConsolidadoDia")
.WithTags("MovimentacaoCaixa");

app.Run();
