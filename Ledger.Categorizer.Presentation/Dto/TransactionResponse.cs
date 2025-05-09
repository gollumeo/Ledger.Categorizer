namespace Ledger.Categorizer.Presentation.Dto;

public class TransactionResponse
{
    public required int Status { get; init; }
    public required string Message { get; init; }
    public required string Category { get; init; }
}