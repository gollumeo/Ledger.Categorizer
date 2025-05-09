namespace Ledger.Categorizer.Tests.Dto;

public record TestCategorizeCase(
    string Description,
    decimal Amount,
    string Date,
    string ExpectedCategory
);