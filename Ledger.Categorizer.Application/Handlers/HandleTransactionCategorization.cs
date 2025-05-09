using Ledger.Categorizer.Application.Commands;
using Ledger.Categorizer.Application.Contracts;
using Ledger.Categorizer.Domain.Entities;
using Ledger.Categorizer.Domain.ValueObjects;

namespace Ledger.Categorizer.Application.Handlers;

public class HandleTransactionCategorization(ICategorizeTransaction categorizeTransaction)
{
    public Category Execute(CategorizeTransactionCommand command)
    {
        var transaction = new Transaction(command.Description, command.Amount, command.Date);

        return categorizeTransaction.Execute(transaction);
    }
}