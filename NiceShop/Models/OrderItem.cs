namespace NiceShop.Models;

public class OrderItem
{
    public int Id { get; set; }
    public decimal Price { get; set; } // the price when it was bought, not the price now
    public int Quantity { get; set; }
    public SizeOption? Size { get; set; }
    public string? Color { get; set; }= default!;
    public string Name { get; set; } = string.Empty;

    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
}