using Ledger.Categorizer.Domain.Entities;
using Ledger.Categorizer.Domain.ValueObjects;
using Ledger.Categorizer.Infrastructure;

namespace Ledger.Categorizer.Tests;

public class DefaultCategorizeTransactionTest
{
    [Fact]
    public void UberEatsIsFoodDelivery()
    {
        var service = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Uber Eats Paris", 29.90m, DateTime.UtcNow);

        var result = service.Categorize(transaction);

        Assert.Equal(Category.FoodDelivery, result);
    }

    [Fact]
    public void EatsTakesPrecedenceOverUber()
    {
        var service = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Uber Eats Bruxelles", 47.50m, DateTime.UtcNow);

        var result = service.Categorize(transaction);

        Assert.Equal(Category.FoodDelivery, result);
    }

    [Fact]
    public void DeliverooIsFoodDelivery()
    {
        var service = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Deliveroo", 19.90m, DateTime.UtcNow);

        var result = service.Categorize(transaction);

        Assert.Equal(Category.FoodDelivery, result);
    }

    [Fact]
    public void UberIsTransport()
    {
        var service = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Uber", 100.52m, DateTime.UtcNow);

        var result = service.Categorize(transaction);

        Assert.Equal(Category.Transport, result);
    }

    [Fact]
    public void GreaterThanAThousandIsHighExpense()
    {
        var service = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Rental", 1050.47m, DateTime.UtcNow);

        var result = service.Categorize(transaction);

        Assert.Equal(Category.HighExpense, result);
    }

    [Fact]
    public void NoRulesMatchIsUncategorized()
    {
        var service = new DefaultCategorizeTransaction();

        var transaction = new Transaction("Carrefour", 52.42m, DateTime.UtcNow);

        var result = service.Categorize(transaction);

        Assert.Equal(Category.Uncategorized, result);
    }

    [Fact]
    public void UberEatsIsFoodDeliveryWhenDescriptionIsUppercase()
    {
        var service = new DefaultCategorizeTransaction();

        var transaction = new Transaction("UBER EATS HAMBURG", 29.90m, DateTime.UtcNow);

        var result = service.Categorize(transaction);

        Assert.Equal(Category.FoodDelivery, result);
    }

    [Fact]
    public void UberIsTransportWhenThereAreExtraSpaces()
    {
        var service = new DefaultCategorizeTransaction();

        var transaction = new Transaction("    Uber   Madrid    ", 100.52m, DateTime.UtcNow);

        var result = service.Categorize(transaction);

        Assert.Equal(Category.Transport, result);
    }
}