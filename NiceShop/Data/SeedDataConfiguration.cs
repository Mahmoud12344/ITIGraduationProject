using Microsoft.EntityFrameworkCore;
using NiceShop.Models;

namespace NiceShop.Data;

public static class SeedDataConfiguration
{
    public static void Apply(ModelBuilder builder)
    {
        // 1. Seed Categories Images (Added images for the new footwear categories)
        builder.Entity<Image>().HasData(
            new Image { Id = 10, Name = "men.png", FilePath = "/assets/seed/categories/men.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 11, Name = "women.png", FilePath = "/assets/seed/categories/women.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 12, Name = "kids.png", FilePath = "/assets/seed/categories/kids.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 13, Name = "footwere.png", FilePath = "/assets/seed/categories/footwere.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 14, Name = "mens-footwear.png", FilePath = "/assets/seed/categories/mens-footwear.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 15, Name = "womens-footwear.png", FilePath = "/assets/seed/categories/womens-footwear.png", IsDefault = true, Type = ImageType.Thumbnail }
        );

        // 2. Seed Categories (Added Men's Footwear and Women's Footwear)
        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Men's Fashion", Slug = "mens-fashion", ImageId = 10 },
            new Category { Id = 2, Name = "Women's Fashion", Slug = "womens-fashion", ImageId = 11 },
            new Category { Id = 3, Name = "Kids' Wear", Slug = "kids-wear", ImageId = 12 },
            new Category { Id = 4, Name = "Unisex Footwear", Slug = "unisex-footwear", ImageId = 13 },
            new Category { Id = 5, Name = "Men's Footwear", Slug = "mens-footwear", ImageId = 14 },
            new Category { Id = 6, Name = "Women's Footwear", Slug = "womens-footwear", ImageId = 15 }
        );

        // 3. Seed Brands Images
        builder.Entity<Image>().HasData(
            new Image { Id = 21, Name = "nike.png", FilePath = "/assets/seed/brands/nike.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 22, Name = "Adidas_Logo.svg.webp", FilePath = "/assets/seed/brands/Adidas_Logo.svg.webp", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 23, Name = "zara-logo-png_seeklogo-351594.png", FilePath = "/assets/seed/brands/zara-logo-png_seeklogo-351594.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 24, Name = "gucci.jpg", FilePath = "/assets/seed/brands/gucci.jpg", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 25, Name = "AmericanEagle.png", FilePath = "/assets/seed/brands/AmericanEagle.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 26, Name = "andora.jpg", FilePath = "/assets/seed/brands/andora.jpg", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 27, Name = "atik.jpg", FilePath = "/assets/seed/brands/atik.jpg", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 28, Name = "jaket&jeens.jpg", FilePath = "/assets/seed/brands/jaket&jeens.jpg", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 29, Name = "lavi's.jpg", FilePath = "/assets/seed/brands/lavi's.jpg", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 30, Name = "lc_wakiki.jpg", FilePath = "/assets/seed/brands/lc_wakiki.jpg", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 31, Name = "puma.jpg", FilePath = "/assets/seed/brands/puma.jpg", IsDefault = true, Type = ImageType.Thumbnail }
        );

        // 4. Seed Brands
        builder.Entity<Brand>().HasData(
            new Brand { Id = 1, Name = "Nike", Country = "USA", ProductCount = 0, ImageId = 21 },
            new Brand { Id = 2, Name = "Adidas", Country = "Germany", ProductCount = 0, ImageId = 22 },
            new Brand { Id = 3, Name = "Zara", Country = "Spain", ProductCount = 0, ImageId = 23 },
            new Brand { Id = 4, Name = "Gucci", Country = "Italy", ProductCount = 0, ImageId = 24 },
            new Brand { Id = 5, Name = "American Eagle", Country = "USA", ProductCount = 0, ImageId = 25 },
            new Brand { Id = 6, Name = "Andora", Country = "Egypt", ProductCount = 0, ImageId = 26 },
            new Brand { Id = 7, Name = "ASTK", Country = "Egypt", ProductCount = 0, ImageId = 27 },
            new Brand { Id = 8, Name = "Jack & Jones", Country = "Denmark", ProductCount = 0, ImageId = 28 },
            new Brand { Id = 9, Name = "Levi's", Country = "USA", ProductCount = 0, ImageId = 29 },
            new Brand { Id = 10, Name = "LC Waikiki", Country = "Turkey", ProductCount = 0, ImageId = 30 },
            new Brand { Id = 11, Name = "PUMA", Country = "Germany", ProductCount = 0, ImageId = 31 }
        );
        
        // Seed Colors and Sizes
        builder.Entity<Color>().HasData(
            new Color { Id = 1, Name = "Black", HexCode = "#000000" },
            new Color { Id = 2, Name = "White", HexCode = "#FFFFFF" },
            new Color { Id = 3, Name = "Red", HexCode = "#EF4444" },
            new Color { Id = 4, Name = "Blue", HexCode = "#3B82F6" },
            new Color { Id = 5, Name = "Green", HexCode = "#10B981" },
            new Color { Id = 6, Name = "Navy", HexCode = "#1E3A8A" },
            new Color { Id = 7, Name = "Beige", HexCode = "#F5F5DC" },
            new Color { Id = 8, Name = "Burgundy", HexCode = "#800020" },
            new Color { Id = 9, Name = "Olive", HexCode = "#4B5320" },
            new Color { Id = 10, Name = "Gray", HexCode = "#6B7280" },
            new Color { Id = 11, Name = "Pink", HexCode = "#EC4899" },
            new Color { Id = 12, Name = "Gold", HexCode = "#D4AF37" },
            new Color { Id = 13, Name = "Silver", HexCode = "#C0C0C0" },
            new Color { Id = 14, Name = "Brown", HexCode = "#8B4513" },
            new Color { Id = 15, Name = "Purple", HexCode = "#8B5CF6" }
        );

        builder.Entity<Size>().HasData(
            new Size { Id = 1, Name = "Small", Code = "S" },
            new Size { Id = 2, Name = "Medium", Code = "M" },
            new Size { Id = 3, Name = "Large", Code = "L" },
            new Size { Id = 4, Name = "Extra Large", Code = "XL" },
            new Size { Id = 5, Name = "Extra Extra Small", Code = "XXS" },
            new Size { Id = 6, Name = "Extra Small", Code = "XS" },
            new Size { Id = 7, Name = "Double Extra Large", Code = "XXL" }
        );

        // 5. Seed Products (Corrected Categories & Added Descriptions)
        builder.Entity<Product>().HasData(
            new Product { 
                Id = 1, Name = "ASTKWomens Cape Trenchcoat", Description = "Experience ultimate comfort and style with the Astkwomens Cape Trenchcoat. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 1250.00m, Stock = 0, CategoryId = 2, BrandId = 7,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 250.00m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 2, Name = "ASTKWomens Essential Puff Jacket", Description = "Experience ultimate comfort and style with the Astkwomens Essential Puff Jacket. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 850.00m, Stock = 0, CategoryId = 2, BrandId = 7,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 150.00m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 3, Name = "Alimens Gentle Slim Fit Mens Dress Shirtsfor Men Button Down Long Sleeve Dress Shirts Wrinkle Free Formal Stain Proof", Description = "Experience ultimate comfort and style with the Alimens Gentle Slim Fit Mens Dress Shirtsfor Men Button Down Long Sleeve Dress Shirts Wrinkle Free Formal Stain Proof. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 550.00m, Stock = 0, CategoryId = 1, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 4, Name = "American Eagle Mens AEFlex12Khaki Short", Description = "Experience ultimate comfort and style with the American Eagle Mens Aeflex12Khaki Short. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 450.00m, Stock = 0, CategoryId = 1, BrandId = 5,
                IsFeatured = false, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 5, Name = "American Eagle Mens Slim Fit Everyday Oxford Button Up Shirt Slim Fit Everyday Oxford Button Up Shirt", Description = "Experience ultimate comfort and style with the American Eagle Mens Slim Fit Everyday Oxford Button Up Shirt Slim Fit Everyday Oxford Button Up Shirt. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 91.76m, Stock = 2, CategoryId = 1, BrandId = 5,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 18.35m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 6, Name = "American Eagle Womens Stretch Barrel Jean", Description = "Experience ultimate comfort and style with the American Eagle Womens Stretch Barrel Jean. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 132.63m, Stock = 4, CategoryId = 2, BrandId = 5,
                IsFeatured = false, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 7, Name = "American Eagle Womens Strigid Barrel Jean", Description = "Experience ultimate comfort and style with the American Eagle Womens Strigid Barrel Jean. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 54.7m, Stock = 0, CategoryId = 2, BrandId = 5,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 10.94m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 8, Name = "Andora Mens Oxford Cotton", Description = "Experience ultimate comfort and style with the Andora Mens Oxford Cotton. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 49.77m, Stock = 0, CategoryId = 2, BrandId = 6,
                IsFeatured = false, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 9, Name = "Andora Mens Solid Pattern Hall Sleeve Wester", Description = "Experience ultimate comfort and style with the Andora Mens Solid Pattern Hall Sleeve Wester. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 47.63m, Stock = 1, CategoryId = 2, BrandId = 6,
                IsFeatured = false, IsBestseller = false, IsOnSale = true,
                Discount = 9.53m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 10, Name = "Dubinik Flannel Shirt Mens Checked Button Down Outdoor Cotton Casual Shirts Flannel Shirts Mens Long Sleeve", Description = "Experience ultimate comfort and style with the Dubinik Flannel Shirt Mens Checked Button Down Outdoor Cotton Casual Shirts Flannel Shirts Mens Long Sleeve. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 136.71m, Stock = 50, CategoryId = 2, BrandId = 1,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 27.34m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 11, Name = "Short Sleeve Basic Top6229000006", Description = "Experience ultimate comfort and style with the Short Sleeve Basic Top6229000006. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 40.79m, Stock = 50, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 12, Name = "ESKINOWomens Winter Long Coat Slim Waist Broadcloth Jacketwith Button Frontand Elegant Belt Multi Color Size", Description = "Experience ultimate comfort and style with the Eskinowomens Winter Long Coat Slim Waist Broadcloth Jacketwith Button Frontand Elegant Belt Multi Color Size. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 113.68m, Stock = 100, CategoryId = 2, BrandId = 1,
                IsFeatured = false, IsBestseller = false, IsOnSale = true,
                Discount = 22.74m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 13, Name = "Long Women Coat Gray", Description = "Experience ultimate comfort and style with the Long Women Coat Gray. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 133.85m, Stock = 20, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = true, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 14, Name = "Womens Dark Brown Wide Leg High Waist Casual Fashion Pants", Description = "Experience ultimate comfort and style with the Womens Dark Brown Wide Leg High Waist Casual Fashion Pants. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 97.85m, Stock = 50, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = true, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 15, Name = "Womens Plush Faux Fur Hooded Jacket Black Cropped Design Zip Up Front Winter Casual Wear", Description = "Experience ultimate comfort and style with the Womens Plush Faux Fur Hooded Jacket Black Cropped Design Zip Up Front Winter Casual Wear. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 31.12m, Stock = 50, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 6.22m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 16, Name = "Womens Wide Leg Trousers High Waist Pleated111Tailored Fit Smart Casual Full Length Straight Cut Womens Fashion", Description = "Experience ultimate comfort and style with the Womens Wide Leg Trousers High Waist Pleated111Tailored Fit Smart Casual Full Length Straight Cut Womens Fashion. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 140.75m, Stock = 10, CategoryId = 2, BrandId = 1,
                IsFeatured = false, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 17, Name = "JACKJONESMens Marco Sunny Chino Shorts", Description = "Experience ultimate comfort and style with the Jackjonesmens Marco Sunny Chino Shorts. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 63.94m, Stock = 100, CategoryId = 1, BrandId = 8,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 12.79m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 18, Name = "LCWAIKIKIBaby Girls Hooded Cardiganand Bootie Bottom Set", Description = "Experience ultimate comfort and style with the Lcwaikikibaby Girls Hooded Cardiganand Bootie Bottom Set. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 131.74m, Stock = 0, CategoryId = 3, BrandId = 10,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 19, Name = "LCWAIKIKIEmbroidered Baby Girls Set", Description = "Experience ultimate comfort and style with the Lcwaikikiembroidered Baby Girls Set. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 124.96m, Stock = 10, CategoryId = 3, BrandId = 10,
                IsFeatured = true, IsBestseller = true, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 20, Name = "AWide Fit POPLINShirt For Women With", Description = "Experience ultimate comfort and style with the Awide Fit Poplinshirt For Women With. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 104.94m, Stock = 0, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 21, Name = "Levis Mens CLASSICWESTERNSTANDARDWoven Tops", Description = "Experience ultimate comfort and style with the Levis Mens Classicwesternstandardwoven Tops. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 89.71m, Stock = 10, CategoryId = 2, BrandId = 9,
                IsFeatured = false, IsBestseller = true, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 22, Name = "Levis Women Seasonal Fashion Jacket", Description = "Experience ultimate comfort and style with the Levis Women Seasonal Fashion Jacket. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 26.57m, Stock = 100, CategoryId = 2, BrandId = 9,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 5.31m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 23, Name = "PUMAMens F1ESSLogo Polo180g Black Classic", Description = "Experience ultimate comfort and style with the Pumamens F1Esslogo Polo180G Black Classic. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 132.39m, Stock = 0, CategoryId = 1, BrandId = 11,
                IsFeatured = true, IsBestseller = false, IsOnSale = true,
                Discount = 26.48m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 24, Name = "Visittheadidas Storeadidas Mens Essentials Small Logo PiquéPolo Shirt T Shirt", Description = "Experience ultimate comfort and style with the Visittheadidas Storeadidas Mens Essentials Small Logo Piquépolo Shirt T Shirt. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 144.44m, Stock = 100, CategoryId = 2, BrandId = 2,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 28.89m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 25, Name = "adidas Copa Pure3League Firm Multi Ground Bootsunisexadult Shoes", Description = "Experience ultimate comfort and style with the Adidas Copa Pure3League Firm Multi Ground Bootsunisexadult Shoes. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 27.42m, Stock = 100, CategoryId = 4, BrandId = 2,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 5.48m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 26, Name = "adidas UNISEXADULTRESPONSERUNNER2SHOES", Description = "Experience ultimate comfort and style with the Adidas Unisexadultresponserunner2Shoes. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 107.77m, Stock = 10, CategoryId = 4, BrandId = 2,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 21.55m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 27, Name = "adidas Mens", Description = "Experience ultimate comfort and style with the Adidas Mens. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 107.05m, Stock = 20, CategoryId = 1, BrandId = 2,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 28, Name = "adidas Womens Ultrarun5Running Shoes", Description = "Experience ultimate comfort and style with the Adidas Womens Ultrarun5Running Shoes. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 21.2m, Stock = 100, CategoryId = 2, BrandId = 2,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 4.24m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 29, Name = "adidaswomens COURTFUNKSneaker", Description = "Experience ultimate comfort and style with the Adidaswomens Courtfunksneaker. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 57.04m, Stock = 50, CategoryId = 2, BrandId = 2,
                IsFeatured = false, IsBestseller = true, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 30, Name = "adidaswomens ULTRADREAMDNASHOES", Description = "Experience ultimate comfort and style with the Adidaswomens Ultradreamdnashoes. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 116.5m, Stock = 10, CategoryId = 2, BrandId = 2,
                IsFeatured = false, IsBestseller = false, IsOnSale = true,
                Discount = 23.3m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 31, Name = "black Graphic T Shirt Short Sleeve Crew Neck Casual Topfor Menand Women,Stylish Everyday Shirtfor Outings,University,Traveland Casual Wea...", Description = "Experience ultimate comfort and style with the Black Graphic T Shirt Short Sleeve Crew Neck Casual Topfor Menand Women,Stylish Everyday Shirtfor Outings,University,Traveland Casual Wear Byhouseof Black. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 137.68m, Stock = 0, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 32, Name = "kidstown Boys2Piece Summer Set High Quality Cotton Sizes2to5Years Modern Designand Unique Colors", Description = "Experience ultimate comfort and style with the Kidstown Boys2Piece Summer Set High Quality Cotton Sizes2To5Years Modern Designand Unique Colors. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 102.81m, Stock = 20, CategoryId = 3, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );

        // 6. Seed Product Images

        builder.Entity<Image>().HasData(

        new Image { Id = 50, Name = "71Tv6b-uu0L._AC_SY741_.jpg", FilePath = "/assets/seed/products/ASTK_women_ASTKWomensCapeTrenchcoat/71Tv6b-uu0L._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 1 },

        new Image { Id = 51, Name = "71i81TMayhL._AC_SY741_.jpg", FilePath = "/assets/seed/products/ASTK_women_ASTKWomensCapeTrenchcoat/71i81TMayhL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 1 },

        new Image { Id = 52, Name = "71ZQ6hd7StL._AC_SY741_.jpg", FilePath = "/assets/seed/products/ASTK_women_ASTKWomensEssentialPuffJacket/71ZQ6hd7StL._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 2 },

        new Image { Id = 53, Name = "71cvCIRw0cL._AC_SY741_.jpg", FilePath = "/assets/seed/products/ASTK_women_ASTKWomensEssentialPuffJacket/71cvCIRw0cL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 2 },

        new Image { Id = 54, Name = "51K5NCVcF0L._AC_SX679_.jpg", FilePath = "/assets/seed/products/AlimensGentle_mens_AlimensGentleSlimFitMensDressShirtsforMenButtonDownLongSleeveDressShirtsWrinkleFreeFormalStainProof/51K5NCVcF0L._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 3 },

        new Image { Id = 55, Name = "714eddH2ewL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AlimensGentle_mens_AlimensGentleSlimFitMensDressShirtsforMenButtonDownLongSleeveDressShirtsWrinkleFreeFormalStainProof/714eddH2ewL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 3 },

        new Image { Id = 56, Name = "71RaeOTscyL._AC_SX569_ (1).jpg", FilePath = "/assets/seed/products/AlimensGentle_mens_AlimensGentleSlimFitMensDressShirtsforMenButtonDownLongSleeveDressShirtsWrinkleFreeFormalStainProof/71RaeOTscyL._AC_SX569_ (1).jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 3 },

        new Image { Id = 57, Name = "71RaeOTscyL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AlimensGentle_mens_AlimensGentleSlimFitMensDressShirtsforMenButtonDownLongSleeveDressShirtsWrinkleFreeFormalStainProof/71RaeOTscyL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 3 },

        new Image { Id = 58, Name = "61Tv6X+r1dL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/61Tv6X+r1dL._AC_SX569_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 4 },

        new Image { Id = 59, Name = "61eEOHexKHL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/61eEOHexKHL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 4 },

        new Image { Id = 60, Name = "61l7AKAe6XL._AC_SX569_ (1).jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/61l7AKAe6XL._AC_SX569_ (1).jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 4 },

        new Image { Id = 61, Name = "61l7AKAe6XL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/61l7AKAe6XL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 4 },

        new Image { Id = 62, Name = "71ZGKUkfuWL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/71ZGKUkfuWL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 4 },

        new Image { Id = 63, Name = "51bEHcCQE0L._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_SlimFitEverydayOxfordShirt/51bEHcCQE0L._AC_SX569_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 5 },

        new Image { Id = 64, Name = "61RGI5JEkQL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_SlimFitEverydayOxfordShirt/61RGI5JEkQL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 5 },

        new Image { Id = 65, Name = "61ucX1Z4TGL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_SlimFitEverydayOxfordShirt/61ucX1Z4TGL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 5 },

        new Image { Id = 66, Name = "710MuP+3MbL._AC_SX466_.jpg", FilePath = "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStretchBarrelJean/710MuP+3MbL._AC_SX466_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 6 },

        new Image { Id = 67, Name = "81OgKdiATwL._AC_SX466_.jpg", FilePath = "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStretchBarrelJean/81OgKdiATwL._AC_SX466_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 6 },

        new Image { Id = 68, Name = "61Wc1zcwhpL._AC_SX466_.jpg", FilePath = "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStrigidBarrelJean/61Wc1zcwhpL._AC_SX466_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 7 },

        new Image { Id = 69, Name = "71R2u84ujwL._AC_SX466_.jpg", FilePath = "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStrigidBarrelJean/71R2u84ujwL._AC_SX466_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 7 },

        new Image { Id = 70, Name = "71nOqpeJLML._AC_SX466_.jpg", FilePath = "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStrigidBarrelJean/71nOqpeJLML._AC_SX466_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 7 },

        new Image { Id = 71, Name = "618Z3nUCUzL._AC_SX679_.jpg", FilePath = "/assets/seed/products/AndoraMensOxfordCotton/618Z3nUCUzL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 8 },

        new Image { Id = 72, Name = "618myyjIRLL._AC_SX679_.jpg", FilePath = "/assets/seed/products/AndoraMensOxfordCotton/618myyjIRLL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 8 },

        new Image { Id = 73, Name = "61UDkcqc+CL._AC_SX679_.jpg", FilePath = "/assets/seed/products/AndoraMensOxfordCotton/61UDkcqc+CL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 8 },

        new Image { Id = 74, Name = "611tOusi66L._AC_SX679_.jpg", FilePath = "/assets/seed/products/AndoraMensSolidPatternHallSleeveWester/611tOusi66L._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 9 },

        new Image { Id = 75, Name = "61ZxB3vTf4L._AC_SX679_.jpg", FilePath = "/assets/seed/products/AndoraMensSolidPatternHallSleeveWester/61ZxB3vTf4L._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 9 },

        new Image { Id = 76, Name = "61xjiObk7vL._AC_SX679_.jpg", FilePath = "/assets/seed/products/AndoraMensSolidPatternHallSleeveWester/61xjiObk7vL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 9 },

        new Image { Id = 77, Name = "81o4U3pfCGL._AC_SX679_.jpg", FilePath = "/assets/seed/products/DubinikFlannelShirtMensCheckedButtonDownOutdoorCottonCasualShirtsFlannelShirtsMensLongSleeve/81o4U3pfCGL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 10 },

        new Image { Id = 78, Name = "91dDWgfHgHL._AC_SX679_.jpg", FilePath = "/assets/seed/products/DubinikFlannelShirtMensCheckedButtonDownOutdoorCottonCasualShirtsFlannelShirtsMensLongSleeve/91dDWgfHgHL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 10 },

        new Image { Id = 79, Name = "91z0Xf8MK2L._AC_SX679_.jpg", FilePath = "/assets/seed/products/DubinikFlannelShirtMensCheckedButtonDownOutdoorCottonCasualShirtsFlannelShirtsMensLongSleeve/91z0Xf8MK2L._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 10 },

        new Image { Id = 80, Name = "31DQxnVYCOL._AC_.jpg", FilePath = "/assets/seed/products/FRESKASTORE_women_ShortSleeveBasicTop6229000006/31DQxnVYCOL._AC_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 11 },

        new Image { Id = 81, Name = "41N34DcpLvL._AC_SX569_.jpg", FilePath = "/assets/seed/products/FRESKASTORE_women_ShortSleeveBasicTop6229000006/41N34DcpLvL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 11 },

        new Image { Id = 82, Name = "41lYW4DS5EL._AC_SX569_.jpg", FilePath = "/assets/seed/products/FRESKASTORE_women_ShortSleeveBasicTop6229000006/41lYW4DS5EL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 11 },

        new Image { Id = 83, Name = "51KMPUGFdOL._AC_SX569_.jpg", FilePath = "/assets/seed/products/FRESKASTORE_women_ShortSleeveBasicTop6229000006/51KMPUGFdOL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 11 },

        new Image { Id = 84, Name = "41ivaZqDgsL._AC_SY741_.jpg", FilePath = "/assets/seed/products/Generic_women_ESKINOWomensWinterLongCoatSlimWaistBroadclothJacketwithButtonFrontandElegantBeltMultiColorSize/41ivaZqDgsL._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 12 },

        new Image { Id = 85, Name = "611dbxlkzhL._AC_SX679_.jpg", FilePath = "/assets/seed/products/Generic_women_ESKINOWomensWinterLongCoatSlimWaistBroadclothJacketwithButtonFrontandElegantBeltMultiColorSize/611dbxlkzhL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 12 },

        new Image { Id = 86, Name = "61zMIlPw4PL._AC_SY741_.jpg", FilePath = "/assets/seed/products/Generic_women_ESKINOWomensWinterLongCoatSlimWaistBroadclothJacketwithButtonFrontandElegantBeltMultiColorSize/61zMIlPw4PL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 12 },

        new Image { Id = 87, Name = "51MLt95IRvL._AC_SX569_.jpg", FilePath = "/assets/seed/products/Generic_women_LongWomenCoatGray/51MLt95IRvL._AC_SX569_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 13 },

        new Image { Id = 88, Name = "61ycJHorzvL._AC_SX679_.jpg", FilePath = "/assets/seed/products/Generic_women_LongWomenCoatGray/61ycJHorzvL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 13 },

        new Image { Id = 89, Name = "71Tf1MgZAJL._AC_SY741_.jpg", FilePath = "/assets/seed/products/Generic_women_LongWomenCoatGray/71Tf1MgZAJL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 13 },

        new Image { Id = 90, Name = "310L1CYTxuL._AC_.jpg", FilePath = "/assets/seed/products/Generic_women_WomensPlushFauxFurHoodedJacketBlackCroppedDesignZipUpFrontWinterCasualWear/310L1CYTxuL._AC_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 15 },

        new Image { Id = 91, Name = "31RQ-6P7lWL._AC_SX569_.jpg", FilePath = "/assets/seed/products/Generic_women_WomensPlushFauxFurHoodedJacketBlackCroppedDesignZipUpFrontWinterCasualWear/31RQ-6P7lWL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 15 },

        new Image { Id = 92, Name = "41ad9TXIBJL._AC_SY741_.jpg", FilePath = "/assets/seed/products/Generic_women_WomensPlushFauxFurHoodedJacketBlackCroppedDesignZipUpFrontWinterCasualWear/41ad9TXIBJL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 15 },

        new Image { Id = 93, Name = "51zV68b-ISL._AC_SY741_.jpg", FilePath = "/assets/seed/products/Generic_women_WomensPlushFauxFurHoodedJacketBlackCroppedDesignZipUpFrontWinterCasualWear/51zV68b-ISL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 15 },

        new Image { Id = 94, Name = "31zRDa68EJL._AC_.jpg", FilePath = "/assets/seed/products/Generic_women_WomensWideLegTrousersHighWaistPleated111TailoredFitSmartCasualFullLengthStraightCutWomensFashion/31zRDa68EJL._AC_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 16 },

        new Image { Id = 95, Name = "41JfCFjjDaL._AC_SY741_.jpg", FilePath = "/assets/seed/products/Generic_women_WomensWideLegTrousersHighWaistPleated111TailoredFitSmartCasualFullLengthStraightCutWomensFashion/41JfCFjjDaL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 16 },

        new Image { Id = 96, Name = "71YqESc2BqL._AC_SX569_.jpg", FilePath = "/assets/seed/products/JACKJONES_mens_JACKJONESMensMarcoSunnyChinoShorts/71YqESc2BqL._AC_SX569_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 17 },

        new Image { Id = 97, Name = "71oKHsfF-3L._AC_SX569_.jpg", FilePath = "/assets/seed/products/JACKJONES_mens_JACKJONESMensMarcoSunnyChinoShorts/71oKHsfF-3L._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 17 },

        new Image { Id = 98, Name = "61fKx6h3OEL._AC_SY741_.jpg", FilePath = "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIBabyGirlsHoodedCardiganandBootieBottomSet/61fKx6h3OEL._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 18 },

        new Image { Id = 99, Name = "61nL1Q9eFDL._AC_SY741_.jpg", FilePath = "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIBabyGirlsHoodedCardiganandBootieBottomSet/61nL1Q9eFDL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 18 },

        new Image { Id = 100, Name = "61p48jb9qAL._AC_SY741_.jpg", FilePath = "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIBabyGirlsHoodedCardiganandBootieBottomSet/61p48jb9qAL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 18 },

        new Image { Id = 101, Name = "41oaWVfmf5L._AC_SY741_.jpg", FilePath = "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIEmbroideredBabyGirlsSet/41oaWVfmf5L._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 19 },

        new Image { Id = 102, Name = "51LmMK8TGfL._AC_SY741_.jpg", FilePath = "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIEmbroideredBabyGirlsSet/51LmMK8TGfL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 19 },

        new Image { Id = 103, Name = "61VTz6tMvHL._AC_SY741_.jpg", FilePath = "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIEmbroideredBabyGirlsSet/61VTz6tMvHL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 19 },

        new Image { Id = 104, Name = "81DgYc28mcL._AC_SY741_.jpg", FilePath = "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIEmbroideredBabyGirlsSet/81DgYc28mcL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 19 },

        new Image { Id = 105, Name = "31i5NOfxavL._AC_.jpg", FilePath = "/assets/seed/products/LaBEAUTE_women_AWideFitPOPLINShirtForWomenWith/31i5NOfxavL._AC_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 20 },

        new Image { Id = 106, Name = "51d1qu0K5mL._AC_SX679_.jpg", FilePath = "/assets/seed/products/LaBEAUTE_women_AWideFitPOPLINShirtForWomenWith/51d1qu0K5mL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 20 },

        new Image { Id = 107, Name = "816b+px-riL._AC_SX679_.jpg", FilePath = "/assets/seed/products/LevisMensCLASSICWESTERNSTANDARDWovenTops/816b+px-riL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 21 },

        new Image { Id = 108, Name = "81YfIJ+CNeL._AC_SX679_.jpg", FilePath = "/assets/seed/products/LevisMensCLASSICWESTERNSTANDARDWovenTops/81YfIJ+CNeL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 21 },

        new Image { Id = 109, Name = "81dPG-5hOQL._AC_SX679_.jpg", FilePath = "/assets/seed/products/LevisMensCLASSICWESTERNSTANDARDWovenTops/81dPG-5hOQL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 21 },

        new Image { Id = 110, Name = "91CnONjElrL._AC_SX679_.jpg", FilePath = "/assets/seed/products/LevisMensCLASSICWESTERNSTANDARDWovenTops/91CnONjElrL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 21 },

        new Image { Id = 111, Name = "51T0ciE+XhL._AC_SX679_.jpg", FilePath = "/assets/seed/products/PUMA_mens_PUMAMensF1ESSLogoPolo180gBlackClassic/51T0ciE+XhL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 23 },

        new Image { Id = 112, Name = "51oKwvsVsTL._AC_SX679_.jpg", FilePath = "/assets/seed/products/PUMA_mens_PUMAMensF1ESSLogoPolo180gBlackClassic/51oKwvsVsTL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 23 },

        new Image { Id = 113, Name = "51pQf4TcjYL._AC_SX679_.jpg", FilePath = "/assets/seed/products/PUMA_mens_PUMAMensF1ESSLogoPolo180gBlackClassic/51pQf4TcjYL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 23 },

        new Image { Id = 114, Name = "51ykfRDU6jL._AC_SX679_.jpg", FilePath = "/assets/seed/products/PUMA_mens_PUMAMensF1ESSLogoPolo180gBlackClassic/51ykfRDU6jL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 23 },

        new Image { Id = 115, Name = "71-hHXwye6L._AC_SX679_.jpg", FilePath = "/assets/seed/products/VisittheadidasStoreadidasMensEssentialsSmallLogoPiquéPoloShirtT-Shirt/71-hHXwye6L._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 24 },

        new Image { Id = 116, Name = "710jRKOOSuL._AC_SX679_.jpg", FilePath = "/assets/seed/products/VisittheadidasStoreadidasMensEssentialsSmallLogoPiquéPoloShirtT-Shirt/710jRKOOSuL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 24 },

        new Image { Id = 117, Name = "81nCNaeExPL._AC_SX679_.jpg", FilePath = "/assets/seed/products/VisittheadidasStoreadidasMensEssentialsSmallLogoPiquéPoloShirtT-Shirt/81nCNaeExPL._AC_SX679_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 24 },

        new Image { Id = 118, Name = "71BZTgWpGhL._AC_SY625_ (1).jpg", FilePath = "/assets/seed/products/adidas_footwear_adidasCopaPure3LeagueFirmMultiGroundBootsunisexadultShoes/71BZTgWpGhL._AC_SY625_ (1).jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 25 },

        new Image { Id = 119, Name = "71BZTgWpGhL._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_footwear_adidasCopaPure3LeagueFirmMultiGroundBootsunisexadultShoes/71BZTgWpGhL._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 25 },

        new Image { Id = 120, Name = "71vvjUel52L._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_footwear_adidasCopaPure3LeagueFirmMultiGroundBootsunisexadultShoes/71vvjUel52L._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 25 },

        new Image { Id = 121, Name = "812LfWM33-L._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_footwear_adidasCopaPure3LeagueFirmMultiGroundBootsunisexadultShoes/812LfWM33-L._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 25 },

        new Image { Id = 122, Name = "51HJ3l10kJL._AC_SX625_.jpg", FilePath = "/assets/seed/products/adidas_footwear_adidasUNISEXADULTRESPONSERUNNER2SHOES/51HJ3l10kJL._AC_SX625_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 26 },

        new Image { Id = 123, Name = "815FkWPHb9L._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_footwear_adidasUNISEXADULTRESPONSERUNNER2SHOES/815FkWPHb9L._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 26 },

        new Image { Id = 124, Name = "819HbjYgE8L._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_footwear_adidasUNISEXADULTRESPONSERUNNER2SHOES/819HbjYgE8L._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 26 },

        new Image { Id = 125, Name = "91h-sP1VFYL._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_footwear_adidasUNISEXADULTRESPONSERUNNER2SHOES/91h-sP1VFYL._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 26 },

        new Image { Id = 126, Name = "414h8y8rQvL._AC_SY695_.jpg", FilePath = "/assets/seed/products/adidas_mens_adidasMens/414h8y8rQvL._AC_SY695_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 27 },

        new Image { Id = 127, Name = "71KReCiVO-L._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_mens_adidasMens/71KReCiVO-L._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 27 },

        new Image { Id = 128, Name = "71YMW58eXeL._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_mens_adidasMens/71YMW58eXeL._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 27 },

        new Image { Id = 129, Name = "81Gm3ktsxIL._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_mens_adidasMens/81Gm3ktsxIL._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 27 },

        new Image { Id = 130, Name = "71V4YxrFg8L._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidasWomensUltrarun5RunningShoes/71V4YxrFg8L._AC_SY625_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 28 },

        new Image { Id = 131, Name = "71qdcGuzEmL._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidasWomensUltrarun5RunningShoes/71qdcGuzEmL._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 28 },

        new Image { Id = 132, Name = "71rZIyBErmL._AC_SY695_.jpg", FilePath = "/assets/seed/products/adidas_women_adidasWomensUltrarun5RunningShoes/71rZIyBErmL._AC_SY695_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 28 },

        new Image { Id = 133, Name = "81rHwe5GmyL._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidasWomensUltrarun5RunningShoes/81rHwe5GmyL._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 28 },

        new Image { Id = 134, Name = "51JWnAJ2fmL._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidaswomensCOURTFUNKSneaker/51JWnAJ2fmL._AC_SY625_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 29 },

        new Image { Id = 135, Name = "51oOMEiFRVL._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidaswomensCOURTFUNKSneaker/51oOMEiFRVL._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 29 },

        new Image { Id = 136, Name = "61ApGjmcR-L._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidaswomensCOURTFUNKSneaker/61ApGjmcR-L._AC_SY625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 29 },

        new Image { Id = 137, Name = "61H70Z36RCL._AC_SX625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidaswomensULTRADREAMDNASHOES/61H70Z36RCL._AC_SX625_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 30 },

        new Image { Id = 138, Name = "71+iCz5PyuL._AC_SX625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidaswomensULTRADREAMDNASHOES/71+iCz5PyuL._AC_SX625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 30 },

        new Image { Id = 139, Name = "71Q8K792gqL._AC_SX625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidaswomensULTRADREAMDNASHOES/71Q8K792gqL._AC_SX625_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 30 },

        new Image { Id = 140, Name = "61CB4aRY1OL._AC_SY741_.jpg", FilePath = "/assets/seed/products/blackGraphicT-ShirtShortSleeveCrewNeckCasualTopforMenandWomen,StylishEverydayShirtforOutings,University,TravelandCasualWearBYHouseofBlack/61CB4aRY1OL._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 31 },

        new Image { Id = 141, Name = "61LKWnqmE8L._AC_SY741_.jpg", FilePath = "/assets/seed/products/blackGraphicT-ShirtShortSleeveCrewNeckCasualTopforMenandWomen,StylishEverydayShirtforOutings,University,TravelandCasualWearBYHouseofBlack/61LKWnqmE8L._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 31 },

        new Image { Id = 142, Name = "61RaJasKrJL._AC_SY741_.jpg", FilePath = "/assets/seed/products/blackGraphicT-ShirtShortSleeveCrewNeckCasualTopforMenandWomen,StylishEverydayShirtforOutings,University,TravelandCasualWearBYHouseofBlack/61RaJasKrJL._AC_SY741_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 31 },

        new Image { Id = 143, Name = "51TzrEe7lEL._AC_SX679_.jpg", FilePath = "/assets/seed/products/kidstown_kids-wear_kidstownBoys2PieceSummerSetHighQualityCottonSizes2to5YearsModernDesignandUniqueColors/51TzrEe7lEL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 32 },
        
        new Image { Id = 144, Name = "71GjGE4DikL._AC_SY550_.jpg", FilePath = "/assets/seed/products/71GjGE4DikL._AC_SY550_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 14 },
        new Image { Id = 145, Name = "71wwFYwHetL._AC_SY550_.jpg", FilePath = "/assets/seed/products/71wwFYwHetL._AC_SY550_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 14 },
        new Image { Id = 146, Name = "W_OUTERWEAR_DENIM_JACKETS_29945-0265-1.png", FilePath = "/assets/seed/products/W_OUTERWEAR_DENIM_JACKETS_29945-0265-1.png", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 22 }

        );
        
        // 7. Seed Many-to-Many Join Tables (Expanded massively for variety)
        var productColors = new List<object>();
        var productSizes = new List<object>();

        // Expanded Color Variety (Giving almost every product Black, White, Navy, Gray, Red, Blue, Beige)
        int[] standardColors = { 1, 2, 3, 4, 6, 7, 10 }; 
        for (int i = 1; i <= 32; i++)
        {
            for(int j = 0; j < 7; j++)
            {
                 productColors.Add(new { ProductsId = i, ColorsId = standardColors[j] }); // Black
            }
            
            if (i % 2 == 0) productColors.Add(new { ProductsId = i, ColorsId = 5 }); // Navy
            if (i % 3 == 0) productColors.Add(new { ProductsId = i, ColorsId = 11 }); // Red
            if (i % 4 == 0) productColors.Add(new { ProductsId = i, ColorsId = 12 }); // Beige
            if (i % 5 == 0) productColors.Add(new { ProductsId = i, ColorsId = 13 }); // Green
        }
        
        // Expanded Size Variety (Giving almost every product XS, S, M, L, XL, XXL)
        for (int i = 1; i <= 32; i++)
        {
            productSizes.Add(new { ProductsId = i, SizesId = 6 }); // XS
            productSizes.Add(new { ProductsId = i, SizesId = 1 }); // S
            productSizes.Add(new { ProductsId = i, SizesId = 2 }); // M
            productSizes.Add(new { ProductsId = i, SizesId = 3 }); // L
            productSizes.Add(new { ProductsId = i, SizesId = 4 }); // XL
            
            // Give every other product XXL just for variety
            if (i % 2 == 0) productSizes.Add(new { ProductsId = i, SizesId = 7 }); 
        }

        builder.Entity("ColorProduct").HasData(productColors.ToArray());
        builder.Entity("ProductSize").HasData(productSizes.ToArray());

        // ==========================================
        // SEED DATA FOR DASHBOARD
        // ==========================================

        var testUserId = "dashboard-test-user-id";

        // Seed ApplicationUser
        builder.Entity<ApplicationUser>().HasData(
            new ApplicationUser 
            { 
                Id = testUserId, 
                UserName = "test@dashboard.com", 
                NormalizedUserName = "TEST@DASHBOARD.COM",
                Email = "test@dashboard.com",
                NormalizedEmail = "TEST@DASHBOARD.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEA==...", // dummy hash
                SecurityStamp = "00000000-0000-0000-0000-000000000000",
                ConcurrencyStamp = "00000000-0000-0000-0000-000000000000"
            }
        );

        // Seed Customer
        builder.Entity<Customer>().HasData(
            new Customer { Id = testUserId, FName = "Dashboard", LName = "Tester" }
        );

        // Seed Address — tied to the dashboard test customer above,
        // so the dashboard's fake Orders (which reference AddressId = 1) still work.
        // CustomerId used to be a plain int (1) which broke once we made it a real
        // string FK to Customer.Id — using testUserId here instead since that
        // customer actually exists.
        builder.Entity<Address>().HasData(
            new Address
            {
                Id = 1,
                CustomerId = testUserId,
                Government = "Cairo",
                City = "Cairo",
                Street = "Test Street",
                Building = "1A",
                AddressType = AddressType.Home
            }
        );


        // Seed Orders
        builder.Entity<Order>().HasData(
            new Order { Id = 1, Number = "ORD-001", CustomerId = testUserId, AddressId = 1, Status = OrderStatus.Confirmed, OrderDate = new DateTime(2026, 9, 15, 0, 0, 0, DateTimeKind.Utc), Subtotal = 2400.00m, ShippingCost = 0m, Total = 2400.00m },
            new Order { Id = 2, Number = "ORD-002", CustomerId = testUserId, AddressId = 1, Status = OrderStatus.Pending, OrderDate = new DateTime(2026, 9, 15, 0, 0, 0, DateTimeKind.Utc), Subtotal = 550.00m, ShippingCost = 0m, Total = 550.00m },
            new Order { Id = 3, Number = "ORD-003", CustomerId = testUserId, AddressId = 1, Status = OrderStatus.Confirmed, OrderDate = new DateTime(2026, 9, 1, 0, 0, 0, DateTimeKind.Utc), Subtotal = 1450.00m, ShippingCost = 0m, Total = 1450.00m },
            new Order { Id = 4, Number = "ORD-004", CustomerId = testUserId, AddressId = 1, Status = OrderStatus.Confirmed, OrderDate = new DateTime(2026, 8, 15, 0, 0, 0, DateTimeKind.Utc), Subtotal = 5600.00m, ShippingCost = 0m, Total = 5600.00m },
            new Order { Id = 5, Number = "ORD-005", CustomerId = testUserId, AddressId = 1, Status = OrderStatus.Confirmed, OrderDate = new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Utc), Subtotal = 3000.00m, ShippingCost = 0m, Total = 3000.00m },
            new Order { Id = 6, Number = "ORD-006", CustomerId = testUserId, AddressId = 1, Status = OrderStatus.Confirmed, OrderDate = new DateTime(2026, 5, 15, 0, 0, 0, DateTimeKind.Utc), Subtotal = 4500.00m, ShippingCost = 0m, Total = 4500.00m }
        );

        // Seed OrderItems
        builder.Entity<OrderItem>().HasData(
            // Order 1 (Total: 2400)
            new OrderItem { Id = 1, OrderId = 1, ProductId = 1, Name = "ASTKWomens Cape Trenchcoat", Quantity = 1, Price = 1000.00m, Color = "Black" },
            new OrderItem { Id = 2, OrderId = 1, ProductId = 2, Name = "ASTKWomens Essential Puff Jacket", Quantity = 2, Price = 700.00m, Color = "Red" },
            // Order 2 (Total: 550)
            new OrderItem { Id = 3, OrderId = 2, ProductId = 3, Name = "Alimens Gentle Slim Fit Mens Dress", Quantity = 1, Price = 550.00m, Color = "White" },
            // Order 3 (Total: 1450)
            new OrderItem { Id = 4, OrderId = 3, ProductId = 1, Name = "ASTKWomens Cape Trenchcoat", Quantity = 1, Price = 1000.00m, Color = "Black" },
            new OrderItem { Id = 5, OrderId = 3, ProductId = 4, Name = "American Eagle Mens AEFlex12Khaki", Quantity = 1, Price = 450.00m, Color = "Blue" },
            // Order 4 (Total: 5600)
            new OrderItem { Id = 6, OrderId = 4, ProductId = 2, Name = "ASTKWomens Essential Puff Jacket", Quantity = 8, Price = 700.00m, Color = "Red" },
            // Order 5 (Total: 3000)
            new OrderItem { Id = 7, OrderId = 5, ProductId = 1, Name = "ASTKWomens Cape Trenchcoat", Quantity = 3, Price = 1000.00m, Color = "Black" },
            // Order 6 (Total: 4500)
            new OrderItem { Id = 8, OrderId = 6, ProductId = 4, Name = "American Eagle Mens AEFlex12Khaki", Quantity = 10, Price = 450.00m, Color = "Blue" }
        );
    }
}