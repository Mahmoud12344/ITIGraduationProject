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
                Id = 1, Name = "ASTKWomens Cape Trenchcoat", Description = "High quality ASTKWomens Cape Trenchcoat from our latest collection. Comfortable and stylish.",
                Price = 103.12m, Stock = 0, CategoryId = 2, BrandId = 7,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 20.62m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 2, Name = "ASTKWomens Essential Puff Jacket", Description = "High quality ASTKWomens Essential Puff Jacket from our latest collection. Comfortable and stylish.",
                Price = 24.12m, Stock = 0, CategoryId = 2, BrandId = 7,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 4.82m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 3, Name = "Alimens Gentle Slim Fit Mens Dress Shirtsfor Men Button Down Long Sleeve Dress Shirts Wrinkle Free Formal Stain Proof", Description = "High quality Alimens Gentle Slim Fit Mens Dress Shirtsfor Men Button Down Long Sleeve Dress Shirts Wrinkle Free Formal Stain Proof from our latest collection. Comfortable and stylish.",
                Price = 96.59m, Stock = 0, CategoryId = 1, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 4, Name = "American Eagle Mens AEFlex12Khaki Short", Description = "High quality American Eagle Mens AEFlex12Khaki Short from our latest collection. Comfortable and stylish.",
                Price = 32.05m, Stock = 0, CategoryId = 1, BrandId = 5,
                IsFeatured = false, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 5, Name = "American Eagle Mens Slim Fit Everyday Oxford Button Up Shirt Slim Fit Everyday Oxford Button Up Shirt", Description = "High quality American Eagle Mens Slim Fit Everyday Oxford Button Up Shirt Slim Fit Everyday Oxford Button Up Shirt from our latest collection. Comfortable and stylish.",
                Price = 91.76m, Stock = 100, CategoryId = 1, BrandId = 5,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 18.35m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 6, Name = "American Eagle Womens Stretch Barrel Jean", Description = "High quality American Eagle Womens Stretch Barrel Jean from our latest collection. Comfortable and stylish.",
                Price = 132.63m, Stock = 50, CategoryId = 2, BrandId = 5,
                IsFeatured = false, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 7, Name = "American Eagle Womens Strigid Barrel Jean", Description = "High quality American Eagle Womens Strigid Barrel Jean from our latest collection. Comfortable and stylish.",
                Price = 54.7m, Stock = 0, CategoryId = 2, BrandId = 5,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 10.94m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 8, Name = "Andora Mens Oxford Cotton", Description = "High quality Andora Mens Oxford Cotton from our latest collection. Comfortable and stylish.",
                Price = 49.77m, Stock = 0, CategoryId = 2, BrandId = 6,
                IsFeatured = false, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 9, Name = "Andora Mens Solid Pattern Hall Sleeve Wester", Description = "High quality Andora Mens Solid Pattern Hall Sleeve Wester from our latest collection. Comfortable and stylish.",
                Price = 47.63m, Stock = 50, CategoryId = 2, BrandId = 6,
                IsFeatured = false, IsBestseller = false, IsOnSale = true,
                Discount = 9.53m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 10, Name = "Dubinik Flannel Shirt Mens Checked Button Down Outdoor Cotton Casual Shirts Flannel Shirts Mens Long Sleeve", Description = "High quality Dubinik Flannel Shirt Mens Checked Button Down Outdoor Cotton Casual Shirts Flannel Shirts Mens Long Sleeve from our latest collection. Comfortable and stylish.",
                Price = 136.71m, Stock = 50, CategoryId = 2, BrandId = 1,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 27.34m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 11, Name = "Short Sleeve Basic Top6229000006", Description = "High quality Short Sleeve Basic Top6229000006 from our latest collection. Comfortable and stylish.",
                Price = 40.79m, Stock = 50, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 12, Name = "ESKINOWomens Winter Long Coat Slim Waist Broadcloth Jacketwith Button Frontand Elegant Belt Multi Color Size", Description = "High quality ESKINOWomens Winter Long Coat Slim Waist Broadcloth Jacketwith Button Frontand Elegant Belt Multi Color Size from our latest collection. Comfortable and stylish.",
                Price = 113.68m, Stock = 100, CategoryId = 2, BrandId = 1,
                IsFeatured = false, IsBestseller = false, IsOnSale = true,
                Discount = 22.74m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 13, Name = "Long Women Coat Gray", Description = "High quality Long Women Coat Gray from our latest collection. Comfortable and stylish.",
                Price = 133.85m, Stock = 20, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = true, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 14, Name = "Womens Dark Brown Wide Leg High Waist Casual Fashion Pants", Description = "High quality Womens Dark Brown Wide Leg High Waist Casual Fashion Pants from our latest collection. Comfortable and stylish.",
                Price = 97.85m, Stock = 50, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = true, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 15, Name = "Womens Plush Faux Fur Hooded Jacket Black Cropped Design Zip Up Front Winter Casual Wear", Description = "High quality Womens Plush Faux Fur Hooded Jacket Black Cropped Design Zip Up Front Winter Casual Wear from our latest collection. Comfortable and stylish.",
                Price = 31.12m, Stock = 50, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 6.22m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 16, Name = "Womens Wide Leg Trousers High Waist Pleated111Tailored Fit Smart Casual Full Length Straight Cut Womens Fashion", Description = "High quality Womens Wide Leg Trousers High Waist Pleated111Tailored Fit Smart Casual Full Length Straight Cut Womens Fashion from our latest collection. Comfortable and stylish.",
                Price = 140.75m, Stock = 10, CategoryId = 2, BrandId = 1,
                IsFeatured = false, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 17, Name = "JACKJONESMens Marco Sunny Chino Shorts", Description = "High quality JACKJONESMens Marco Sunny Chino Shorts from our latest collection. Comfortable and stylish.",
                Price = 63.94m, Stock = 100, CategoryId = 1, BrandId = 8,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 12.79m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 18, Name = "LCWAIKIKIBaby Girls Hooded Cardiganand Bootie Bottom Set", Description = "High quality LCWAIKIKIBaby Girls Hooded Cardiganand Bootie Bottom Set from our latest collection. Comfortable and stylish.",
                Price = 131.74m, Stock = 0, CategoryId = 3, BrandId = 10,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 19, Name = "LCWAIKIKIEmbroidered Baby Girls Set", Description = "High quality LCWAIKIKIEmbroidered Baby Girls Set from our latest collection. Comfortable and stylish.",
                Price = 124.96m, Stock = 10, CategoryId = 3, BrandId = 10,
                IsFeatured = true, IsBestseller = true, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 20, Name = "AWide Fit POPLINShirt For Women With", Description = "High quality AWide Fit POPLINShirt For Women With from our latest collection. Comfortable and stylish.",
                Price = 104.94m, Stock = 0, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 21, Name = "Levis Mens CLASSICWESTERNSTANDARDWoven Tops", Description = "High quality Levis Mens CLASSICWESTERNSTANDARDWoven Tops from our latest collection. Comfortable and stylish.",
                Price = 89.71m, Stock = 10, CategoryId = 2, BrandId = 9,
                IsFeatured = false, IsBestseller = true, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 22, Name = "Levis Women Seasonal Fashion Jacket", Description = "High quality Levis Women Seasonal Fashion Jacket from our latest collection. Comfortable and stylish.",
                Price = 26.57m, Stock = 100, CategoryId = 2, BrandId = 9,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 5.31m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 23, Name = "PUMAMens F1ESSLogo Polo180g Black Classic", Description = "High quality PUMAMens F1ESSLogo Polo180g Black Classic from our latest collection. Comfortable and stylish.",
                Price = 132.39m, Stock = 0, CategoryId = 1, BrandId = 11,
                IsFeatured = true, IsBestseller = false, IsOnSale = true,
                Discount = 26.48m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 24, Name = "Visittheadidas Storeadidas Mens Essentials Small Logo PiquéPolo Shirt T Shirt", Description = "High quality Visittheadidas Storeadidas Mens Essentials Small Logo PiquéPolo Shirt T Shirt from our latest collection. Comfortable and stylish.",
                Price = 144.44m, Stock = 100, CategoryId = 2, BrandId = 2,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 28.89m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 25, Name = "adidas Copa Pure3League Firm Multi Ground Bootsunisexadult Shoes", Description = "High quality adidas Copa Pure3League Firm Multi Ground Bootsunisexadult Shoes from our latest collection. Comfortable and stylish.",
                Price = 27.42m, Stock = 100, CategoryId = 4, BrandId = 2,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 5.48m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 26, Name = "adidas UNISEXADULTRESPONSERUNNER2SHOES", Description = "High quality adidas UNISEXADULTRESPONSERUNNER2SHOES from our latest collection. Comfortable and stylish.",
                Price = 107.77m, Stock = 10, CategoryId = 4, BrandId = 2,
                IsFeatured = false, IsBestseller = true, IsOnSale = true,
                Discount = 21.55m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 27, Name = "adidas Mens", Description = "High quality adidas Mens from our latest collection. Comfortable and stylish.",
                Price = 107.05m, Stock = 20, CategoryId = 1, BrandId = 2,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 28, Name = "adidas Womens Ultrarun5Running Shoes", Description = "High quality adidas Womens Ultrarun5Running Shoes from our latest collection. Comfortable and stylish.",
                Price = 21.2m, Stock = 100, CategoryId = 2, BrandId = 2,
                IsFeatured = true, IsBestseller = true, IsOnSale = true,
                Discount = 4.24m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 29, Name = "adidaswomens COURTFUNKSneaker", Description = "High quality adidaswomens COURTFUNKSneaker from our latest collection. Comfortable and stylish.",
                Price = 57.04m, Stock = 50, CategoryId = 2, BrandId = 2,
                IsFeatured = false, IsBestseller = true, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 30, Name = "adidaswomens ULTRADREAMDNASHOES", Description = "High quality adidaswomens ULTRADREAMDNASHOES from our latest collection. Comfortable and stylish.",
                Price = 116.5m, Stock = 10, CategoryId = 2, BrandId = 2,
                IsFeatured = false, IsBestseller = false, IsOnSale = true,
                Discount = 23.3m, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 31, Name = "black Graphic T Shirt Short Sleeve Crew Neck Casual Topfor Menand Women,Stylish Everyday Shirtfor Outings,University,Traveland Casual Wear B", Description = "High quality black Graphic T Shirt Short Sleeve Crew Neck Casual Topfor Menand Women,Stylish Everyday Shirtfor Outings,University,Traveland Casual Wear B from our latest collection. Comfortable and stylish.",
                Price = 137.68m, Stock = 0, CategoryId = 2, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },
            new Product { 
                Id = 32, Name = "kidstown Boys2Piece Summer Set High Quality Cotton Sizes2to5Years Modern Designand Unique Colors", Description = "High quality kidstown Boys2Piece Summer Set High Quality Cotton Sizes2to5Years Modern Designand Unique Colors from our latest collection. Comfortable and stylish.",
                Price = 102.81m, Stock = 20, CategoryId = 3, BrandId = 1,
                IsFeatured = true, IsBestseller = false, IsOnSale = false,
                Discount = null, IsActive = true,
                CreatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc), UpdatedAt = new DateTime(2023, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );

        // 6. Seed Product Images
        builder.Entity<Image>().HasData(
            new Image { Id = 50, Name = "71Tv6b-uu0L._AC_SY741_.jpg", FilePath = "/assets/seed/products/ASTK_women_ASTKWomensCapeTrenchcoat/71Tv6b-uu0L._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 1 },
            new Image { Id = 51, Name = "71ZQ6hd7StL._AC_SY741_.jpg", FilePath = "/assets/seed/products/ASTK_women_ASTKWomensEssentialPuffJacket/71ZQ6hd7StL._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 2 },
            new Image { Id = 52, Name = "51K5NCVcF0L._AC_SX679_.jpg", FilePath = "/assets/seed/products/AlimensGentle_mens_AlimensGentleSlimFitMensDressShirtsforMenButtonDownLongSleeveDressShirtsWrinkleFreeFormalStainProof/51K5NCVcF0L._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 3 },
            new Image { Id = 53, Name = "61Tv6X+r1dL._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/61Tv6X+r1dL._AC_SX569_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 4 },
            new Image { Id = 54, Name = "51bEHcCQE0L._AC_SX569_.jpg", FilePath = "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensSlimFitEverydayOxfordButtonUpShirtSlimFitEverydayOxfordButtonUpShirt/51bEHcCQE0L._AC_SX569_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 5 },
            new Image { Id = 55, Name = "710MuP+3MbL._AC_SX466_.jpg", FilePath = "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStretchBarrelJean/710MuP+3MbL._AC_SX466_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 6 },
            new Image { Id = 56, Name = "61Wc1zcwhpL._AC_SX466_.jpg", FilePath = "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStrigidBarrelJean/61Wc1zcwhpL._AC_SX466_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 7 },
            new Image { Id = 57, Name = "618Z3nUCUzL._AC_SX679_.jpg", FilePath = "/assets/seed/products/AndoraMensOxfordCotton/618Z3nUCUzL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 8 },
            new Image { Id = 58, Name = "611tOusi66L._AC_SX679_.jpg", FilePath = "/assets/seed/products/AndoraMensSolidPatternHallSleeveWester/611tOusi66L._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 9 },
            new Image { Id = 59, Name = "81o4U3pfCGL._AC_SX679_.jpg", FilePath = "/assets/seed/products/DubinikFlannelShirtMensCheckedButtonDownOutdoorCottonCasualShirtsFlannelShirtsMensLongSleeve/81o4U3pfCGL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 10 },
            new Image { Id = 60, Name = "31DQxnVYCOL._AC_.jpg", FilePath = "/assets/seed/products/FRESKASTORE_women_ShortSleeveBasicTop6229000006/31DQxnVYCOL._AC_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 11 },
            new Image { Id = 61, Name = "41ivaZqDgsL._AC_SY741_.jpg", FilePath = "/assets/seed/products/Generic_women_ESKINOWomensWinterLongCoatSlimWaistBroadclothJacketwithButtonFrontandElegantBeltMultiColorSize/41ivaZqDgsL._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 12 },
            new Image { Id = 62, Name = "51MLt95IRvL._AC_SX569_.jpg", FilePath = "/assets/seed/products/Generic_women_LongWomenCoatGray/51MLt95IRvL._AC_SX569_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 13 },
            new Image { Id = 63, Name = "310L1CYTxuL._AC_.jpg", FilePath = "/assets/seed/products/Generic_women_WomensPlushFauxFurHoodedJacketBlackCroppedDesignZipUpFrontWinterCasualWear/310L1CYTxuL._AC_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 15 },
            new Image { Id = 64, Name = "31zRDa68EJL._AC_.jpg", FilePath = "/assets/seed/products/Generic_women_WomensWideLegTrousersHighWaistPleated111TailoredFitSmartCasualFullLengthStraightCutWomensFashion/31zRDa68EJL._AC_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 16 },
            new Image { Id = 65, Name = "71YqESc2BqL._AC_SX569_.jpg", FilePath = "/assets/seed/products/JACKJONES_mens_JACKJONESMensMarcoSunnyChinoShorts/71YqESc2BqL._AC_SX569_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 17 },
            new Image { Id = 66, Name = "61fKx6h3OEL._AC_SY741_.jpg", FilePath = "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIBabyGirlsHoodedCardiganandBootieBottomSet/61fKx6h3OEL._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 18 },
            new Image { Id = 67, Name = "41oaWVfmf5L._AC_SY741_.jpg", FilePath = "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIEmbroideredBabyGirlsSet/41oaWVfmf5L._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 19 },
            new Image { Id = 68, Name = "31i5NOfxavL._AC_.jpg", FilePath = "/assets/seed/products/LaBEAUTE_women_AWideFitPOPLINShirtForWomenWith/31i5NOfxavL._AC_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 20 },
            new Image { Id = 69, Name = "816b+px-riL._AC_SX679_.jpg", FilePath = "/assets/seed/products/LevisMensCLASSICWESTERNSTANDARDWovenTops/816b+px-riL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 21 },
            new Image { Id = 70, Name = "51T0ciE+XhL._AC_SX679_.jpg", FilePath = "/assets/seed/products/PUMA_mens_PUMAMensF1ESSLogoPolo180gBlackClassic/51T0ciE+XhL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 23 },
            new Image { Id = 71, Name = "71-hHXwye6L._AC_SX679_.jpg", FilePath = "/assets/seed/products/VisittheadidasStoreadidasMensEssentialsSmallLogoPiquéPoloShirtT-Shirt/71-hHXwye6L._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 24 },
            new Image { Id = 72, Name = "71BZTgWpGhL._AC_SY625_ (1).jpg", FilePath = "/assets/seed/products/adidas_footwear_adidasCopaPure3LeagueFirmMultiGroundBootsunisexadultShoes/71BZTgWpGhL._AC_SY625_ (1).jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 25 },
            new Image { Id = 73, Name = "51HJ3l10kJL._AC_SX625_.jpg", FilePath = "/assets/seed/products/adidas_footwear_adidasUNISEXADULTRESPONSERUNNER2SHOES/51HJ3l10kJL._AC_SX625_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 26 },
            new Image { Id = 74, Name = "414h8y8rQvL._AC_SY695_.jpg", FilePath = "/assets/seed/products/adidas_mens_adidasMens/414h8y8rQvL._AC_SY695_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 27 },
            new Image { Id = 75, Name = "71V4YxrFg8L._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidasWomensUltrarun5RunningShoes/71V4YxrFg8L._AC_SY625_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 28 },
            new Image { Id = 76, Name = "51JWnAJ2fmL._AC_SY625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidaswomensCOURTFUNKSneaker/51JWnAJ2fmL._AC_SY625_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 29 },
            new Image { Id = 77, Name = "61H70Z36RCL._AC_SX625_.jpg", FilePath = "/assets/seed/products/adidas_women_adidaswomensULTRADREAMDNASHOES/61H70Z36RCL._AC_SX625_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 30 },
            new Image { Id = 78, Name = "61CB4aRY1OL._AC_SY741_.jpg", FilePath = "/assets/seed/products/blackGraphicT-ShirtShortSleeveCrewNeckCasualTopforMenandWomen,StylishEverydayShirtforOutings,University,TravelandCasualWearBYHouseofBlack/61CB4aRY1OL._AC_SY741_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 31 },
            new Image { Id = 79, Name = "51TzrEe7lEL._AC_SX679_.jpg", FilePath = "/assets/seed/products/kidstown_kids-wear_kidstownBoys2PieceSummerSetHighQualityCottonSizes2to5YearsModernDesignandUniqueColors/51TzrEe7lEL._AC_SX679_.jpg", IsDefault = true, Type = ImageType.Thumbnail, ProductId = 32 }
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
