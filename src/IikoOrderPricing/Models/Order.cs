using System.Collections.ObjectModel;

namespace IikoOrderPricing.Models;

public sealed class Order
{
    private readonly List<OrderItem> _items = new();

    public IReadOnlyCollection<OrderItem> Items => new ReadOnlyCollection<OrderItem>(_items);

    /// <summary>
    /// Сервисный сбор в процентах, который начисляется на сумму после скидок (0–100).
    /// Например, 10 означает 10% сервисного сбора.
    /// </summary>
    public decimal ServiceChargePercent { get; }

    public Order(decimal serviceChargePercent)
    {
        if (serviceChargePercent is < 0 or > 100)
            throw new ArgumentOutOfRangeException(nameof(serviceChargePercent), "Service charge percent must be between 0 and 100.");

        ServiceChargePercent = serviceChargePercent;
    }

    public void AddItem(OrderItem item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Add(item);
    }
}
