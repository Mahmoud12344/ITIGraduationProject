namespace NiceShop.Models;
public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Country { get; set; } = default!;
    public int ProductCount { get; set; } // denormalized/calculated

    public int? ImageId { get; set; }
    public virtual Image? Image { get; set; } // logo

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}