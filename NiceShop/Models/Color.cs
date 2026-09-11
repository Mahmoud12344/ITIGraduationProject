namespace NiceShop.Models;

public class Color {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string HexCode { get; set; } = default!;
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}