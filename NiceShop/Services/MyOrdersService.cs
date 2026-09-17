using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.ViewModels.Orders;

namespace NiceShop.Services;

// same idea as the admin OrdersService, but this one only ever looks at
// one customer's own orders, so a customer can never see someone else's
public class MyOrdersService(ApplicationDbContext context)
{
    public async Task<List<MyOrdersVm.OrderSummaryVm>> GetMyOrdersAsync(string customerId)
    {
        return await context.Orders
            .Where(o => o.CustomerId == customerId)
            .OrderByDescending(o => o.OrderDate)
            .Select(o => new MyOrdersVm.OrderSummaryVm
            {
                Id = o.Id,
                Number = o.Number,
                OrderDate = o.OrderDate,
                Total = o.Total,
                Status = o.Status
            })
            .ToListAsync();
    }

    public async Task<MyOrdersVm.OrderDetailsVm?> GetMyOrderDetailsAsync(int id, string customerId)
    {
        var order = await context.Orders
            .Include(o => o.Address)
            .Include(o => o.Coupon)
            .Include(o => o.OrderItems)
            .FirstOrDefaultAsync(o => o.Id == id && o.CustomerId == customerId);

        // either it doesnt exist, or it belongs to someone else, treat it the same either way
        if (order == null) return null;

        return new MyOrdersVm.OrderDetailsVm
        {
            Id = order.Id,
            Number = order.Number,
            OrderDate = order.OrderDate,
            Status = order.Status,

            Subtotal = order.Subtotal,
            ShippingCost = order.ShippingCost,
            Discount = order.Discount,
            Total = order.Total,

            CouponCode = order.Coupon?.Code,
            Percentage = order.Coupon?.Percentage,

            IsCanceled = order.IsCanceled,
            CancellationReason = order.CancellationReason,
            Notes = order.Notes,

            ShippingAddress = $"{order.Address.Building}, {order.Address.Street}, {order.Address.City}, {order.Address.Government} ({order.Address.AddressType})",

            Items = order.OrderItems.Select(i => new MyOrdersVm.OrderItemVm
            {
                ProductId = i.ProductId,
                Name = i.Name,
                Price = i.Price,
                Quantity = i.Quantity,
                Size = i.Size,
                Color = i.Color
            }).ToList()
        };
    }

    // used by "Track Order" - customer types in the order number instead of picking from the list
    public async Task<int?> FindMyOrderIdByNumberAsync(string orderNumber, string customerId)
    {
        var order = await context.Orders
            .Where(o => o.Number == orderNumber && o.CustomerId == customerId)
            .Select(o => new { o.Id })
            .FirstOrDefaultAsync();

        return order?.Id;
    }
}