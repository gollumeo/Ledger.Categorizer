using Ledger.Categorizer.Application.Contracts;
using Ledger.Categorizer.Domain.Entities;
using Ledger.Categorizer.Presentation.Dto;

namespace Ledger.Categorizer.Api.Http;

public static class TransactionEndpoints
{
    public static void MapTransactionEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/transactions", (TransactionRequest request, ICategorizeTransaction service) =>
        {
            var transaction = new Transaction(request.Description, request.Amount, request.Date);

            var category = service.Categorize(transaction);

            var response = new TransactionResponse
            {
                Status = 200,
                Message = "Transaction categorized successfully",
                Category = category.ToString()
            };

            return Results.Ok(response);
        });
    }
}