using Ledger.Categorizer.Domain.Entities;
using Ledger.Categorizer.Domain.ValueObjects;

namespace Ledger.Categorizer.Application.Contracts;

public interface ICategorizeTransaction
{
    Category Execute(Transaction transaction);
}