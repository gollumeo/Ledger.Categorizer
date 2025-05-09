using Ledger.Categorizer.Api.Http;
using Ledger.Categorizer.Application.Contracts;
using Ledger.Categorizer.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategorizeTransaction, DefaultCategorizeTransaction>();

var app = builder.Build();


app.MapTransactionEndpoints();

app.Run();

public partial class Program
{
}