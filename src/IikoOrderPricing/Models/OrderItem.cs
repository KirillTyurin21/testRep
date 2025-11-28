namespace IikoOrderPricing.Models;

public sealed class OrderItem
{
    public string Name { get; }
    public decimal UnitPrice { get; }
    public int Quantity { get; }
    /// <summary>
    /// Скидка на позицию в процентах (0–100).
    /// Например, 10 означает 10% скидки.
    /// </summary>
    public decimal DiscountPercent { get; }

    public OrderItem(string name, decimal unitPrice, int quantity, decimal discountPercent)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name must be specified.", nameof(name));

        if (unitPrice < 0)
            throw new ArgumentOutOfRangeException(nameof(unitPrice), "Unit price cannot be negative.");

        if (quantity <= 0)
            throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than zero.");

        if (discountPercent is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(discountPercent), "Discount percent must be between 0 and 100.");

        Name = name;
        UnitPrice = unitPrice;
        Quantity = quantity;
        DiscountPercent = discountPercent;
    }

    public decimal GetSubtotal() => UnitPrice * Quantity;

    public decimal GetDiscountAmount()
    {
        var subtotal = GetSubtotal();
        if (DiscountPercent <= 0)
            return 0m;

        return decimal.Round(subtotal * (DiscountPercent / 100m), 2, MidpointRounding.AwayFromZero);
    }
}
