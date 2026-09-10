namespace NiceShop.Models;

// just a temp class so the cart code can run
// dev1 will make the real one with all the details
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}