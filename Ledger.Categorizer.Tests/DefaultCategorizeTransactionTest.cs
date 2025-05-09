using Ledger.Categorizer.Domain.Entities;
using Ledger.Categorizer.Domain.ValueObjects;
using Ledger.Categorizer.Infrastructure;

namespace Ledger.Categorizer.Tests;

public class DefaultCategorizeTransactionTest
{
    [Fact]
    public void UberEatsIsFoodDelivery()
    {
        var categorizeTransaction = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Uber Eats Paris", 29.90m, DateTime.UtcNow);

        var result = categorizeTransaction.Execute(transaction);

        Assert.Equal(Category.FoodDelivery, result);
    }

    [Fact]
    public void EatsTakesPrecedenceOverUber()
    {
        var categorizeTransaction = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Uber Eats Bruxelles", 47.50m, DateTime.UtcNow);

        var result = categorizeTransaction.Execute(transaction);

        Assert.Equal(Category.FoodDelivery, result);
    }

    [Fact]
    public void DeliverooIsFoodDelivery()
    {
        var categorizeTransaction = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Deliveroo", 19.90m, DateTime.UtcNow);

        var result = categorizeTransaction.Execute(transaction);

        Assert.Equal(Category.FoodDelivery, result);
    }

    [Fact]
    public void UberIsTransport()
    {
        var categorizeTransaction = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Uber", 100.52m, DateTime.UtcNow);

        var result = categorizeTransaction.Execute(transaction);

        Assert.Equal(Category.Transport, result);
    }

    [Fact]
    public void GreaterThanAThousandIsHighExpense()
    {
        var categorizeTransaction = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Rental", 1050.47m, DateTime.UtcNow);

        var result = categorizeTransaction.Execute(transaction);

        Assert.Equal(Category.HighExpense, result);
    }

    [Fact]
    public void NoRulesMatchIsUncategorized()
    {
        var categorizeTransaction = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Carrefour", 52.42m, DateTime.UtcNow);

        var result = categorizeTransaction.Execute(transaction);

        Assert.Equal(Category.Uncategorized, result);
    }

    [Fact]
    public void UberEatsIsFoodDeliveryWhenDescriptionIsUppercase()
    {
        var categorizeTransaction = new DefaultCategorizeTransaction();

        var transaction = new Transaction("UBER EATS HAMBURG", 29.90m, DateTime.UtcNow);

        var result = categorizeTransaction.Execute(transaction);

        Assert.Equal(Category.FoodDelivery, result);
    }

    [Fact]
    public void UberIsTransportWhenThereAreExtraSpaces()
    {
        var categorizeTransaction = new DefaultCategorizeTransaction();

        var transaction = new Transaction("    Uber   Madrid    ", 100.52m, DateTime.UtcNow);

        var result = categorizeTransaction.Execute(transaction);

        Assert.Equal(Category.Transport, result);
    }
}