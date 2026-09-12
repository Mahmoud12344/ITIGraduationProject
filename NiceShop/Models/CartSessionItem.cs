namespace NiceShop.Models;


// this is just a light version we store in session for guests (not logged in)  NOT the database CartItem
public class CartSessionItem
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public string? Size { get; set; }
    public string? Color { get; set; }
}