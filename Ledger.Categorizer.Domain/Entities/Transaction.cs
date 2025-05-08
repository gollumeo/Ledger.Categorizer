namespace Ledger.Categorizer.Domain.Entities;

public record Transaction(string Description, decimal Amount, DateTime Date);