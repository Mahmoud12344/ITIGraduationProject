namespace NiceShop.Models;

public class Cart
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    // the customer who owns this cart // changed to fit  the Identity
    public string CustomerId { get; set; }
    public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    public Customer? Customer{ get; set; }
}