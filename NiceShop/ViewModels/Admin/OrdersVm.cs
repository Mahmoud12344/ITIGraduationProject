using NiceShop.Models;

namespace NiceShop.ViewModels.Admin;


public class OrdersVm
{
    public List<OrderSummaryVm> Orders { get; set; } = new();
    public OrderFilterVm Filter { get; set; } = new();  
    public class OrderSummaryVm
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty; 
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class OrderDetailsVm
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public DateTime OrderDate { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerEmail {get; set; } = string.Empty;
        
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public int? Discount { get; set; }
        public decimal Total { get; set; }

        public int? CouponId { get; set; }
        public string? CouponCode { get; set; }
        
        public OrderStatus Status { get; set; }
        public string? Notes { get; set; }
        public bool? IsCanceled { get; set; }
        public string? CancellationReason { get; set; }
        
        public string ShippingAddress { get; set; } = string.Empty;

        public List<OrderItemVm> Items { get; set; } = new();
    }

    public class OrderItemVm
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Price * Quantity;
        public SizeOption? Size { get; set; }
        public string? Color { get; set; }
    }

    public class OrderFilterVm
    {
        public OrderStatus? Status { get; set; }
        public string? SearchQuery { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
