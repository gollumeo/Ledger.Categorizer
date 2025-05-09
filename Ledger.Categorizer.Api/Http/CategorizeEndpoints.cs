using Ledger.Categorizer.Application.Commands;
using Ledger.Categorizer.Application.Handlers;
using Ledger.Categorizer.Presentation.Dto;

namespace Ledger.Categorizer.Api.Http;

public static class CategorizeEndpoints
{
    public static void MapTransactionEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/categorize", (CategorizeRequest request, HandleTransactionCategorization categorizeTransaction) =>
        {
            var command = new CategorizeTransactionCommand(
                request.Description,
                request.Amount,
                request.Date
            );

            var category = categorizeTransaction.Execute(command);

            var response = new CategorizeResponse
            {
                Status = 200,
                Message = "Transaction categorized successfully",
                Category = category.ToString()
            };

            return Results.Ok(response);
        });
    }
}