namespace NiceShop.Models;

public class Size{
    public int Id { get; set; }
    public string Name { get; set; } = default!;  // e.g. "Large", "42"
    public string? Code { get; set; }             // e.g. "L", "XL"
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}