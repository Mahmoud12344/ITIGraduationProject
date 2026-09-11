namespace NiceShop.Models;

public class Image
{
    public int Id { get; set; }
    public bool IsDefault { get; set; }
    public string Name { get; set; }
    public string? Caption { get; set; }
    public string FilePath { get; set; }
    public ImageType Type { get; set; }

    public int? ProductId { get; set; } // nullable since ApplicationUser also uses Image
    public virtual Product? Product { get; set; }
}
