using System.Drawing;

namespace NiceShop.Models;

// just a temp class so the cart code can run
// dev1 will make the real one with all the details /:  like really?
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public decimal Price { get; set; }
    public decimal Rating { get; set; }        // calculated - avg of Reviews
    public bool IsFeatured { get; set; }
    public bool IsBestseller { get; set; }
    public bool IsOnSale { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; } = default!;
    public int ReviewCount { get; set; }      // calculated - count of Reviews
    public bool IsActive { get; set; }
    public decimal? Discount { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = default!;

    public int? BrandId { get; set; } // see note #1 below
    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<Color> Colors { get; set; } = new List<Color>(); // many-to-many
    public virtual ICollection<Size> Sizes { get; set; } = new List<Size>();}
