namespace NiceShop.Models;

public class Order
{
    public int Id { get; set; }
    public string Number { get; set; } = string.Empty;
    public string? Notes { get; set; }
    public int? Discount { get; set; }
    public decimal Subtotal { get; set; }
    public decimal ShippingCost { get; set; }
    public decimal Total { get; set; } // subtotal + shipping - discount
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public bool? IsCanceled{ get; set; }
    public string? CancellationReason { get; set; }

    public string CustomerId { get; set; }
    public virtual Customer Customer { get; set; } = default!;

    public int? CouponId { get; set; }
    public Coupon? Coupon { get; set; }

    public int AddressId { get; set; }
    public Address Address { get; set; } = null!;

    public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}