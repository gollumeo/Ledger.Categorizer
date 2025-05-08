namespace Ledger.Categorizer.Domain.ValueObjects;

public sealed class Category
{
    public static readonly Category Transport = new("Transport");
    public static readonly Category FoodDelivery = new("FoodDelivery");
    public static readonly Category HighExpense = new("HighExpense");
    public static readonly Category Uncategorized = new("Uncategorized");

    private Category(string value)
    {
        Value = value;
    }

    private string Value { get; }

    public override string ToString()
    {
        return Value;
    }
}