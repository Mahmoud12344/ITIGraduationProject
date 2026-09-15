using Microsoft.EntityFrameworkCore;
using NiceShop.Models;

namespace NiceShop.Data;

public static class SeedDataConfiguration
{
    public static void Apply(ModelBuilder builder)
    {
        // 1. Seed Categories Images
        builder.Entity<Image>().HasData(
            new Image { Id = 10, Name = "men.png", FilePath = "/assets/seed/categories/men.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 11, Name = "women.png", FilePath = "/assets/seed/categories/women.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 12, Name = "kids.png", FilePath = "/assets/seed/categories/kids.png", IsDefault = true, Type = ImageType.Thumbnail },
            new Image { Id = 13, Name = "footwere.png", FilePath = "/assets/seed/categories/footwere.png", IsDefault = true, Type = ImageType.Thumbnail }
        );

        // 2. Seed Categories
        builder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Men's Fashion", Slug = "mens-fashion", ImageId = 10 },
            new Category { Id = 2, Name = "Women's Fashion", Slug = "womens-fashion", ImageId = 11 },
            new Category { Id = 3, Name = "Kids' Wear", Slug = "kids-wear", ImageId = 12 },
            new Category { Id = 4, Name = "Footwear", Slug = "footwear", ImageId = 13 }
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

        // 4. Seed Brands (1-4 already exist, Update ImageId) (5-11 new)
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
        
        // Ensure Colors and Sizes are seeded as they were before
        builder.Entity<Color>().HasData(
            new Color { Id = 1, Name = "Black", HexCode = "#000000" },
            new Color { Id = 2, Name = "White", HexCode = "#FFFFFF" },
            new Color { Id = 3, Name = "Red", HexCode = "#EF4444" },
            new Color { Id = 4, Name = "Blue", HexCode = "#3B82F6" },
            new Color { Id = 5, Name = "Green", HexCode = "#10B981" }
        );
        
        builder.Entity<Size>().HasData(
            new Size { Id = 1, Name = "Small", Code = "S" },
            new Size { Id = 2, Name = "Medium", Code = "M" },
            new Size { Id = 3, Name = "Large", Code = "L" },
            new Size { Id = 4, Name = "Extra Large", Code = "XL" }
        );

        // 5. Seed Products
        builder.Entity<Product>().HasData(
            new Product { 
                Id = 1, Name = "ASTKWomens Cape Trenchcoat", Description = "Experience ultimate comfort and style with the Astkwomens Cape Trenchcoat. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 103.12m, Stock = 0, CategoryId = 2, BrandId = 7,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 20.62m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 2, Name = "ASTKWomens Essential Puff Jacket", Description = "Experience ultimate comfort and style with the Astkwomens Essential Puff Jacket. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 24.12m, Stock = 0, CategoryId = 2, BrandId = 7,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 4.82m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 3, Name = "Alimens Gentle Slim Fit Mens Dress Shirtsfor Men Button Down Long Sleeve Dress Shirts Wrinkle Free Formal Stain Proof", Description = "Experience ultimate comfort and style with the Alimens Gentle Slim Fit Mens Dress Shirtsfor Men Button Down Long Sleeve Dress Shirts Wrinkle Free Formal Stain Proof. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 96.59m, Stock = 0, CategoryId = 1, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 4, Name = "American Eagle Mens AEFlex12Khaki Short", Description = "Experience ultimate comfort and style with the American Eagle Mens Aeflex12Khaki Short. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 32.05m, Stock = 0, CategoryId = 1, BrandId = 5,
                IsFeatured = false, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 5, Name = "American Eagle Mens Slim Fit Everyday Oxford Button Up Shirt Slim Fit Everyday Oxford Button Up Shirt", Description = "Experience ultimate comfort and style with the American Eagle Mens Slim Fit Everyday Oxford Button Up Shirt Slim Fit Everyday Oxford Button Up Shirt. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 91.76m, Stock = 100, CategoryId = 1, BrandId = 5,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 18.35m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 6, Name = "American Eagle Womens Stretch Barrel Jean", Description = "Experience ultimate comfort and style with the American Eagle Womens Stretch Barrel Jean. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.",
                Price = 132.63m, Stock = 50, CategoryId = 2, BrandId = 5,
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
                Price = 47.63m, Stock = 50, CategoryId = 2, BrandId = 6,
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
            new Image { Id = 63, Name = "51bEHcCQE0L._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensSlimFitEverydayOxfordButtonUpShirtSlimFitEverydayOxfordButtonUpShirt/51bEHcCQE0L._AC_SX569_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 5 },
            new Image { Id = 64, Name = "61RGI5JEkQL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensSlimFitEverydayOxfordButtonUpShirtSlimFitEverydayOxfordButtonUpShirt/61RGI5JEkQL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 5 },
            new Image { Id = 65, Name = "61ucX1Z4TGL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensSlimFitEverydayOxfordButtonUpShirtSlimFitEverydayOxfordButtonUpShirt/61ucX1Z4TGL._AC_SX569_.jpg", IsDefault = false, Type = ImageType.Gallery, ProductId = 5 },
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
            new Image { Id = 143, Name = "51TzrEe7lEL._AC_SX679_.jpg", FilePath = "/assets/seed/products/kidstown_kids-wear_kidstownBoys2PieceSummerSetHighQualityCottonSizes2to5YearsModernDesignandUniqueColors/51TzrEe7lEL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 32 }
        );

        // 7. Seed Many-to-Many Join Tables (ProductColors and ProductSizes)
        // EF Core 5+ supports seeding join tables using the configured table name
        builder.Entity("ColorProduct").HasData(
            new { ProductsId = 1, ColorsId = 1 },
            new { ProductsId = 2, ColorsId = 5 },
            new { ProductsId = 2, ColorsId = 4 },
            new { ProductsId = 2, ColorsId = 1 },
            new { ProductsId = 3, ColorsId = 2 },
            new { ProductsId = 3, ColorsId = 3 },
            new { ProductsId = 4, ColorsId = 4 },
            new { ProductsId = 5, ColorsId = 2 },
            new { ProductsId = 6, ColorsId = 3 },
            new { ProductsId = 7, ColorsId = 3 },
            new { ProductsId = 7, ColorsId = 2 },
            new { ProductsId = 8, ColorsId = 5 },
            new { ProductsId = 9, ColorsId = 2 },
            new { ProductsId = 9, ColorsId = 3 },
            new { ProductsId = 10, ColorsId = 1 },
            new { ProductsId = 10, ColorsId = 5 },
            new { ProductsId = 10, ColorsId = 4 },
            new { ProductsId = 11, ColorsId = 5 },
            new { ProductsId = 11, ColorsId = 3 },
            new { ProductsId = 11, ColorsId = 4 },
            new { ProductsId = 12, ColorsId = 2 },
            new { ProductsId = 12, ColorsId = 4 },
            new { ProductsId = 13, ColorsId = 5 },
            new { ProductsId = 13, ColorsId = 2 },
            new { ProductsId = 13, ColorsId = 1 },
            new { ProductsId = 14, ColorsId = 1 },
            new { ProductsId = 14, ColorsId = 2 },
            new { ProductsId = 15, ColorsId = 5 },
            new { ProductsId = 15, ColorsId = 2 },
            new { ProductsId = 15, ColorsId = 4 },
            new { ProductsId = 16, ColorsId = 4 },
            new { ProductsId = 16, ColorsId = 1 },
            new { ProductsId = 17, ColorsId = 1 },
            new { ProductsId = 18, ColorsId = 2 },
            new { ProductsId = 19, ColorsId = 4 },
            new { ProductsId = 19, ColorsId = 5 },
            new { ProductsId = 20, ColorsId = 2 },
            new { ProductsId = 21, ColorsId = 1 },
            new { ProductsId = 21, ColorsId = 4 },
            new { ProductsId = 22, ColorsId = 4 },
            new { ProductsId = 23, ColorsId = 4 },
            new { ProductsId = 23, ColorsId = 3 },
            new { ProductsId = 24, ColorsId = 1 },
            new { ProductsId = 24, ColorsId = 5 },
            new { ProductsId = 25, ColorsId = 2 },
            new { ProductsId = 25, ColorsId = 1 },
            new { ProductsId = 25, ColorsId = 3 },
            new { ProductsId = 26, ColorsId = 1 },
            new { ProductsId = 26, ColorsId = 5 },
            new { ProductsId = 26, ColorsId = 2 },
            new { ProductsId = 27, ColorsId = 3 },
            new { ProductsId = 28, ColorsId = 2 },
            new { ProductsId = 28, ColorsId = 3 },
            new { ProductsId = 28, ColorsId = 1 },
            new { ProductsId = 29, ColorsId = 2 },
            new { ProductsId = 29, ColorsId = 3 },
            new { ProductsId = 29, ColorsId = 1 },
            new { ProductsId = 30, ColorsId = 2 },
            new { ProductsId = 30, ColorsId = 3 },
            new { ProductsId = 30, ColorsId = 4 },
            new { ProductsId = 31, ColorsId = 3 },
            new { ProductsId = 32, ColorsId = 1 },
            new { ProductsId = 32, ColorsId = 5 },
            new { ProductsId = 32, ColorsId = 3 }
        );

        builder.Entity("ProductSize").HasData(
            new { ProductsId = 1, SizesId = 1 },
            new { ProductsId = 1, SizesId = 3 },
            new { ProductsId = 1, SizesId = 2 },
            new { ProductsId = 2, SizesId = 4 },
            new { ProductsId = 3, SizesId = 1 },
            new { ProductsId = 4, SizesId = 1 },
            new { ProductsId = 4, SizesId = 2 },
            new { ProductsId = 4, SizesId = 4 },
            new { ProductsId = 5, SizesId = 3 },
            new { ProductsId = 5, SizesId = 1 },
            new { ProductsId = 5, SizesId = 4 },
            new { ProductsId = 6, SizesId = 2 },
            new { ProductsId = 6, SizesId = 3 },
            new { ProductsId = 7, SizesId = 3 },
            new { ProductsId = 7, SizesId = 1 },
            new { ProductsId = 8, SizesId = 3 },
            new { ProductsId = 9, SizesId = 4 },
            new { ProductsId = 10, SizesId = 2 },
            new { ProductsId = 10, SizesId = 3 },
            new { ProductsId = 11, SizesId = 1 },
            new { ProductsId = 11, SizesId = 3 },
            new { ProductsId = 12, SizesId = 1 },
            new { ProductsId = 12, SizesId = 3 },
            new { ProductsId = 13, SizesId = 3 },
            new { ProductsId = 13, SizesId = 1 },
            new { ProductsId = 13, SizesId = 4 },
            new { ProductsId = 14, SizesId = 1 },
            new { ProductsId = 15, SizesId = 4 },
            new { ProductsId = 15, SizesId = 1 },
            new { ProductsId = 16, SizesId = 2 },
            new { ProductsId = 16, SizesId = 1 },
            new { ProductsId = 16, SizesId = 3 },
            new { ProductsId = 17, SizesId = 2 },
            new { ProductsId = 17, SizesId = 1 },
            new { ProductsId = 17, SizesId = 3 },
            new { ProductsId = 18, SizesId = 4 },
            new { ProductsId = 18, SizesId = 1 },
            new { ProductsId = 18, SizesId = 2 },
            new { ProductsId = 19, SizesId = 1 },
            new { ProductsId = 19, SizesId = 3 },
            new { ProductsId = 20, SizesId = 2 },
            new { ProductsId = 21, SizesId = 1 },
            new { ProductsId = 22, SizesId = 4 },
            new { ProductsId = 22, SizesId = 1 },
            new { ProductsId = 23, SizesId = 4 },
            new { ProductsId = 23, SizesId = 3 },
            new { ProductsId = 24, SizesId = 3 },
            new { ProductsId = 25, SizesId = 1 },
            new { ProductsId = 26, SizesId = 3 },
            new { ProductsId = 26, SizesId = 2 },
            new { ProductsId = 26, SizesId = 1 },
            new { ProductsId = 27, SizesId = 4 },
            new { ProductsId = 27, SizesId = 2 },
            new { ProductsId = 27, SizesId = 1 },
            new { ProductsId = 28, SizesId = 2 },
            new { ProductsId = 28, SizesId = 4 },
            new { ProductsId = 29, SizesId = 1 },
            new { ProductsId = 30, SizesId = 4 },
            new { ProductsId = 30, SizesId = 2 },
            new { ProductsId = 31, SizesId = 2 },
            new { ProductsId = 32, SizesId = 2 }
        );
    }
}
