using Fcx.Caixa.Infrastructure.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

var config = configuration
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{environment}.json", optional: true)
    .AddEnvironmentVariables()
    .BuildAndReplacePlaceholders();

services.AddPersistence(configuration);
services.AddServices(configuration);

var app = builder.Build();

await app.RunAsync();