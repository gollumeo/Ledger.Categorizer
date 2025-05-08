using Ledger.Categorizer.Application.Contracts;
using Ledger.Categorizer.Domain.Entities;
using Ledger.Categorizer.Domain.ValueObjects;

namespace Ledger.Categorizer.Infrastructure;

public class DefaultCategorizeTransaction : ICategorizeTransaction
{
    private static readonly string[] FoodDeliveryKeywords = ["eats", "deliveroo"];
    private static readonly string[] TransportKeywords = ["uber", "taxi"];


    public Category Categorize(Transaction transaction)
    {
        if (IsFoodDelivery(transaction)) return Category.FoodDelivery;

        if (IsHighExpense(transaction)) return Category.HighExpense;

        if (IsTransport(transaction)) return Category.Transport;

        return Category.Uncategorized;
    }

    private static bool IsFoodDelivery(Transaction transaction)
    {
        var description = transaction.Description.ToLowerInvariant();
        return FoodDeliveryKeywords.Any(k => description.Contains(k));
    }

    private static bool IsHighExpense(Transaction transaction)
    {
        return transaction.Amount >= 1000;
    }

    private static bool IsTransport(Transaction transaction)
    {
        var description = transaction.Description.ToLowerInvariant();
        return TransportKeywords.Any(transportKeyWord => description.Contains(transportKeyWord)) &&
               !FoodDeliveryKeywords.Any(foodDeliveryKeyword => description.Contains(foodDeliveryKeyword));
    }
}