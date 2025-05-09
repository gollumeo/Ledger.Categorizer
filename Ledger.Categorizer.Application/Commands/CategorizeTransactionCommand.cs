namespace Ledger.Categorizer.Application.Commands;

public class CategorizeTransactionCommand(string description, decimal amount, DateTime date)
{
    public string Description { get; } = description;
    public decimal Amount { get; } = amount;
    public DateTime Date { get; } = date;
}