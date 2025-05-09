namespace Ledger.Categorizer.Presentation.Dto;

public class CategorizeRequest
{
    public required string Description { get; init; }
    public required decimal Amount { get; init; }
    public required DateTime Date { get; init; }
}