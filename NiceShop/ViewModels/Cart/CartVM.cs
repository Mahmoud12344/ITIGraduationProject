namespace NiceShop.ViewModels.Cart;

public class CartLineVM
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string? Size { get; set; }
    public string? Color { get; set; }
    public decimal LineTotal => Price * Quantity;
}

public class CartVM
{
    public List<CartLineVM> Items { get; set; } = new List<CartLineVM>();
    public decimal Subtotal => Items.Sum(i => i.LineTotal);
}