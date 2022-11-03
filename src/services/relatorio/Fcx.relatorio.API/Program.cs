using Fcx.Library.Infrastructure.MongoDB.Repository;
using Fcx.Library.Infrastructure.Rabbitmq.DependencyInjection;
using Fcx.relatorio.API.Model;
using Fcx.relatorio.API.Service;
using Fcx.Library.Infrastructure.MongoDB.Configuration;
using Fcx.Library.Infrastructure.MongoDB.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddMessageBus(builder.Configuration.GetMessageQueueConnection("MessageBus"))
    .AddHostedService<MovimentoConsolidadoEventHandler>();

builder.Services.AddMongoDB();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/cfx/relatorio/movimentacao",
    (IMongoRepository<MovimentoConsolidado> repository, DateTime dataMovimento) =>
    {
        var movimentos = repository.FilterBy(a => a.DataMovimento.Date.Equals(dataMovimento.Date));
        if (movimentos != null)
            Results.Ok(movimentos);
        else
            Results.NotFound();
    }
)
.Produces<MovimentoConsolidado>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("ConsolidadoPorDia")
.WithTags("MovimentacaoCaixa");


app.MapGet("/cfx/relatorio/movimentacao",
     (IMongoRepository<MovimentoConsolidado> repository) =>
    {
        var movimentos = repository.AsQueryable().ToList();
        if (movimentos != null)
            Results.Ok(movimentos);
        else
            Results.NotFound();
    }
)
.Produces<IEnumerable<MovimentoConsolidado>>(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound)
.WithName("ConsolidadoTodos")
.WithTags("MovimentacaoCaixa");

app.Run();