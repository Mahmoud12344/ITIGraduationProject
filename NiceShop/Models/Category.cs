namespace NiceShop.Models;

public class Category {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Slug { get; set; } = default!;

    public int? ImageId { get; set; }
    public virtual Image? Image { get; set; } // thumbnail

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}