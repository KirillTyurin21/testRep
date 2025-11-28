using IikoOrderPricing.Models;

namespace IikoOrderPricing.Services;

public sealed class OrderTotals
{
    public decimal Subtotal { get; }
    public decimal DiscountTotal { get; }
    public decimal ServiceChargeAmount { get; }
    public decimal Total { get; }

    public OrderTotals(decimal subtotal, decimal discountTotal, decimal serviceChargeAmount, decimal total)
    {
        Subtotal = subtotal;
        DiscountTotal = discountTotal;
        ServiceChargeAmount = serviceChargeAmount;
        Total = total;
    }
}

public sealed class OrderPricingService
{
    /// <summary>
    /// Рассчитывает итоговые суммы заказа:
    /// - Subtotal: сумма по позициям без скидок;
    /// - DiscountTotal: общая сумма скидок;
    /// - ServiceChargeAmount: сервисный сбор в денежном выражении;
    /// - Total: итоговая сумма к оплате.
    /// </summary>
    public OrderTotals CalculateTotals(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);

        decimal subtotal = 0m;
        decimal discountTotal = 0m;

        foreach (var item in order.Items)
        {
            subtotal += item.GetSubtotal();
            discountTotal += item.GetDiscountAmount();
        }

        // Сумма после скидок.
        var afterDiscounts = subtotal - discountTotal;

        if (afterDiscounts < 0)
        {
            // На всякий случай не уходим в отрицательные значения.
            afterDiscounts = 0m;
        }

        var serviceChargeAmount = decimal.Round(
            afterDiscounts * (order.ServiceChargePercent / 100m),
            2,
            MidpointRounding.AwayFromZero);

        var total = afterDiscounts + serviceChargeAmount;

        return new OrderTotals(
            subtotal: decimal.Round(subtotal, 2, MidpointRounding.AwayFromZero),
            discountTotal: decimal.Round(discountTotal, 2, MidpointRounding.AwayFromZero),
            serviceChargeAmount: serviceChargeAmount,
            total: decimal.Round(total, 2, MidpointRounding.AwayFromZero));
    }
}
