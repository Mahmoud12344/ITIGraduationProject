using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopMvc.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(50)]
        public string SKU { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? OriginalPrice { get; set; }

        public int Stock { get; set; }

        public bool IsActive { get; set; } = true;

        public string ImagesJson { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}