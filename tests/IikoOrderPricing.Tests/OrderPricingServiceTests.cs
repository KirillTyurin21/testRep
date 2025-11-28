using IikoOrderPricing.Models;
using IikoOrderPricing.Services;
using Xunit;

namespace IikoOrderPricing.Tests;

public sealed class OrderPricingServiceTests
{
    private readonly OrderPricingService _service = new();

    [Fact]
    public void CalculateTotals_NoDiscounts_NoServiceCharge()
    {
        var order = new Order(serviceChargePercent: 0);
        order.AddItem(new OrderItem("Burger", 300m, 2, 0m)); // 600
        order.AddItem(new OrderItem("Fries", 150m, 1, 0m));  // 150

        var totals = _service.CalculateTotals(order);

        Assert.Equal(750m, totals.Subtotal);
        Assert.Equal(0m, totals.DiscountTotal);
        Assert.Equal(0m, totals.ServiceChargeAmount);
        Assert.Equal(750m, totals.Total);
    }

    [Fact]
    public void CalculateTotals_PerItemDiscounts_NoServiceCharge()
    {
        var order = new Order(serviceChargePercent: 0);
        order.AddItem(new OrderItem("Burger", 300m, 2, 10m)); // 600 - 10% = 540
        order.AddItem(new OrderItem("Fries", 150m, 1, 0m));   // 150

        var totals = _service.CalculateTotals(order);

        Assert.Equal(750m, totals.Subtotal);
        Assert.Equal(60m, totals.DiscountTotal); // 10% от 600
        Assert.Equal(0m, totals.ServiceChargeAmount);
        Assert.Equal(690m, totals.Total);
    }

    [Fact]
    public void CalculateTotals_DiscountsAndServiceCharge()
    {
        var order = new Order(serviceChargePercent: 10m);
        order.AddItem(new OrderItem("Pizza", 800m, 1, 0m));   // 800
        order.AddItem(new OrderItem("Cola", 200m, 2, 50m));   // 400 - 50% = 200

        var totals = _service.CalculateTotals(order);

        Assert.Equal(1200m, totals.Subtotal);

        // Скидка только на Cola: 400 * 50% = 200
        Assert.Equal(200m, totals.DiscountTotal);

        // После скидок: 1000, сервисный сбор 10% = 100
        Assert.Equal(100m, totals.ServiceChargeAmount);
        Assert.Equal(1100m, totals.Total);
    }

    [Fact]
    public void CalculateTotals_NegativeAfterDiscounts_IsClampedToZero()
    {
        var order = new Order(serviceChargePercent: 10m);
        // Теоретически странный кейс: 100 руб, 200% скидки.
        order.AddItem(new OrderItem("Test", 100m, 1, 100m));

        var totals = _service.CalculateTotals(order);

        Assert.Equal(100m, totals.Subtotal);
        Assert.Equal(100m, totals.DiscountTotal);
        Assert.Equal(0m, totals.ServiceChargeAmount);
        Assert.Equal(0m, totals.Total);
    }
}
