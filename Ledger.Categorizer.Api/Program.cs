using Ledger.Categorizer.Api.Http;
using Ledger.Categorizer.Application.Contracts;
using Ledger.Categorizer.Application.Handlers;
using Ledger.Categorizer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategorizeTransaction, DefaultCategorizeTransaction>();
builder.Services.AddScoped<HandleTransactionCategorization>();

var app = builder.Build();

app.MapTransactionEndpoints();

app.Run();

public abstract partial class Program
{
}