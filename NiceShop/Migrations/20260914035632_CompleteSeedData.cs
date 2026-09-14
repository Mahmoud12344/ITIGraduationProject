using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NiceShop.Migrations
{
    /// <inheritdoc />
    public partial class CompleteSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 10, null, "/assets/seed/categories/men.png", true, "men.png", null, 0 },
                    { 11, null, "/assets/seed/categories/women.png", true, "women.png", null, 0 },
                    { 12, null, "/assets/seed/categories/kids.png", true, "kids.png", null, 0 },
                    { 13, null, "/assets/seed/categories/footwere.png", true, "footwere.png", null, 0 },
                    { 21, null, "/assets/seed/brands/nike.png", true, "nike.png", null, 0 },
                    { 22, null, "/assets/seed/brands/Adidas_Logo.svg.webp", true, "Adidas_Logo.svg.webp", null, 0 },
                    { 23, null, "/assets/seed/brands/zara-logo-png_seeklogo-351594.png", true, "zara-logo-png_seeklogo-351594.png", null, 0 },
                    { 24, null, "/assets/seed/brands/gucci.jpg", true, "gucci.jpg", null, 0 },
                    { 25, null, "/assets/seed/brands/AmericanEagle.png", true, "AmericanEagle.png", null, 0 },
                    { 26, null, "/assets/seed/brands/andora.jpg", true, "andora.jpg", null, 0 },
                    { 27, null, "/assets/seed/brands/atik.jpg", true, "atik.jpg", null, 0 },
                    { 28, null, "/assets/seed/brands/jaket&jeens.jpg", true, "jaket&jeens.jpg", null, 0 },
                    { 29, null, "/assets/seed/brands/lavi's.jpg", true, "lavi's.jpg", null, 0 },
                    { 30, null, "/assets/seed/brands/lc_wakiki.jpg", true, "lc_wakiki.jpg", null, 0 },
                    { 31, null, "/assets/seed/brands/puma.jpg", true, "puma.jpg", null, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: 22);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageId",
                value: 24);

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Country", "ImageId", "Name" },
                values: new object[,]
                {
                    { 5, "USA", 25, "American Eagle" },
                    { 6, "Egypt", 26, "Andora" },
                    { 7, "Egypt", 27, "ASTK" },
                    { 8, "Denmark", 28, "Jack & Jones" },
                    { 9, "USA", 29, "Levi's" },
                    { 10, "Turkey", 30, "LC Waikiki" },
                    { 11, "Germany", 31, "PUMA" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "ImageId", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, 10, "Men's Fashion", "mens-fashion" },
                    { 2, 11, "Women's Fashion", "womens-fashion" },
                    { 3, 12, "Kids' Wear", "kids-wear" },
                    { 4, 13, "Footwear", "footwear" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsOnSale", "Name", "Price", "UpdatedAt" },
                values: new object[] { 1, 7, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality ASTKWomens Cape Trenchcoat from our latest collection. Comfortable and stylish.", 20.62m, true, true, true, "ASTKWomens Cape Trenchcoat", 103.12m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "UpdatedAt" },
                values: new object[] { 2, 7, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality ASTKWomens Essential Puff Jacket from our latest collection. Comfortable and stylish.", 4.82m, true, true, true, true, "ASTKWomens Essential Puff Jacket", 24.12m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "UpdatedAt" },
                values: new object[] { 3, 1, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Alimens Gentle Slim Fit Mens Dress Shirtsfor Men Button Down Long Sleeve Dress Shirts Wrinkle Free Formal Stain Proof from our latest collection. Comfortable and stylish.", null, true, true, "Alimens Gentle Slim Fit Mens Dress Shirtsfor Men Button Down Long Sleeve Dress Shirts Wrinkle Free Formal Stain Proof", 96.59m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "Name", "Price", "UpdatedAt" },
                values: new object[] { 4, 5, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality American Eagle Mens AEFlex12Khaki Short from our latest collection. Comfortable and stylish.", null, true, "American Eagle Mens AEFlex12Khaki Short", 32.05m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 5, 5, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality American Eagle Mens Slim Fit Everyday Oxford Button Up Shirt Slim Fit Everyday Oxford Button Up Shirt from our latest collection. Comfortable and stylish.", 18.35m, true, true, true, "American Eagle Mens Slim Fit Everyday Oxford Button Up Shirt Slim Fit Everyday Oxford Button Up Shirt", 91.76m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 6, 5, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality American Eagle Womens Stretch Barrel Jean from our latest collection. Comfortable and stylish.", null, true, "American Eagle Womens Stretch Barrel Jean", 132.63m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "UpdatedAt" },
                values: new object[] { 7, 5, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality American Eagle Womens Strigid Barrel Jean from our latest collection. Comfortable and stylish.", 10.94m, true, true, true, true, "American Eagle Womens Strigid Barrel Jean", 54.7m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "Name", "Price", "UpdatedAt" },
                values: new object[] { 8, 6, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Andora Mens Oxford Cotton from our latest collection. Comfortable and stylish.", null, true, "Andora Mens Oxford Cotton", 49.77m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 9, 6, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Andora Mens Solid Pattern Hall Sleeve Wester from our latest collection. Comfortable and stylish.", 9.53m, true, true, "Andora Mens Solid Pattern Hall Sleeve Wester", 47.63m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 10, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Dubinik Flannel Shirt Mens Checked Button Down Outdoor Cotton Casual Shirts Flannel Shirts Mens Long Sleeve from our latest collection. Comfortable and stylish.", 27.34m, true, true, true, "Dubinik Flannel Shirt Mens Checked Button Down Outdoor Cotton Casual Shirts Flannel Shirts Mens Long Sleeve", 136.71m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 11, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Short Sleeve Basic Top6229000006 from our latest collection. Comfortable and stylish.", null, true, true, "Short Sleeve Basic Top6229000006", 40.79m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 12, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality ESKINOWomens Winter Long Coat Slim Waist Broadcloth Jacketwith Button Frontand Elegant Belt Multi Color Size from our latest collection. Comfortable and stylish.", 22.74m, true, true, "ESKINOWomens Winter Long Coat Slim Waist Broadcloth Jacketwith Button Frontand Elegant Belt Multi Color Size", 113.68m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { 13, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Long Women Coat Gray from our latest collection. Comfortable and stylish.", null, true, true, true, "Long Women Coat Gray", 133.85m, 20, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Womens Dark Brown Wide Leg High Waist Casual Fashion Pants from our latest collection. Comfortable and stylish.", null, true, true, true, "Womens Dark Brown Wide Leg High Waist Casual Fashion Pants", 97.85m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 15, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Womens Plush Faux Fur Hooded Jacket Black Cropped Design Zip Up Front Winter Casual Wear from our latest collection. Comfortable and stylish.", 6.22m, true, true, true, true, "Womens Plush Faux Fur Hooded Jacket Black Cropped Design Zip Up Front Winter Casual Wear", 31.12m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 16, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Womens Wide Leg Trousers High Waist Pleated111Tailored Fit Smart Casual Full Length Straight Cut Womens Fashion from our latest collection. Comfortable and stylish.", null, true, "Womens Wide Leg Trousers High Waist Pleated111Tailored Fit Smart Casual Full Length Straight Cut Womens Fashion", 140.75m, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 17, 8, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality JACKJONESMens Marco Sunny Chino Shorts from our latest collection. Comfortable and stylish.", 12.79m, true, true, true, true, "JACKJONESMens Marco Sunny Chino Shorts", 63.94m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "UpdatedAt" },
                values: new object[] { 18, 10, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality LCWAIKIKIBaby Girls Hooded Cardiganand Bootie Bottom Set from our latest collection. Comfortable and stylish.", null, true, true, "LCWAIKIKIBaby Girls Hooded Cardiganand Bootie Bottom Set", 131.74m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 19, 10, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality LCWAIKIKIEmbroidered Baby Girls Set from our latest collection. Comfortable and stylish.", null, true, true, true, "LCWAIKIKIEmbroidered Baby Girls Set", 124.96m, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "UpdatedAt" },
                values: new object[] { 20, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality AWide Fit POPLINShirt For Women With from our latest collection. Comfortable and stylish.", null, true, true, "AWide Fit POPLINShirt For Women With", 104.94m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 21, 9, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Levis Mens CLASSICWESTERNSTANDARDWoven Tops from our latest collection. Comfortable and stylish.", null, true, true, "Levis Mens CLASSICWESTERNSTANDARDWoven Tops", 89.71m, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 22, 9, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Levis Women Seasonal Fashion Jacket from our latest collection. Comfortable and stylish.", 5.31m, true, true, true, true, "Levis Women Seasonal Fashion Jacket", 26.57m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "IsOnSale", "Name", "Price", "UpdatedAt" },
                values: new object[] { 23, 11, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality PUMAMens F1ESSLogo Polo180g Black Classic from our latest collection. Comfortable and stylish.", 26.48m, true, true, true, "PUMAMens F1ESSLogo Polo180g Black Classic", 132.39m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { 24, 2, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality Visittheadidas Storeadidas Mens Essentials Small Logo PiquéPolo Shirt T Shirt from our latest collection. Comfortable and stylish.", 28.89m, true, true, true, "Visittheadidas Storeadidas Mens Essentials Small Logo PiquéPolo Shirt T Shirt", 144.44m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, 2, 4, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality adidas Copa Pure3League Firm Multi Ground Bootsunisexadult Shoes from our latest collection. Comfortable and stylish.", 5.48m, true, true, true, "adidas Copa Pure3League Firm Multi Ground Bootsunisexadult Shoes", 27.42m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 26, 2, 4, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality adidas UNISEXADULTRESPONSERUNNER2SHOES from our latest collection. Comfortable and stylish.", 21.55m, true, true, true, "adidas UNISEXADULTRESPONSERUNNER2SHOES", 107.77m, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 27, 2, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality adidas Mens from our latest collection. Comfortable and stylish.", null, true, true, "adidas Mens", 107.05m, 20, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 28, 2, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality adidas Womens Ultrarun5Running Shoes from our latest collection. Comfortable and stylish.", 4.24m, true, true, true, true, "adidas Womens Ultrarun5Running Shoes", 21.2m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 29, 2, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality adidaswomens COURTFUNKSneaker from our latest collection. Comfortable and stylish.", null, true, true, "adidaswomens COURTFUNKSneaker", 57.04m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 30, 2, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality adidaswomens ULTRADREAMDNASHOES from our latest collection. Comfortable and stylish.", 23.3m, true, true, "adidaswomens ULTRADREAMDNASHOES", 116.5m, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "UpdatedAt" },
                values: new object[] { 31, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality black Graphic T Shirt Short Sleeve Crew Neck Casual Topfor Menand Women,Stylish Everyday Shirtfor Outings,University,Traveland Casual Wear B from our latest collection. Comfortable and stylish.", null, true, true, "black Graphic T Shirt Short Sleeve Crew Neck Casual Topfor Menand Women,Stylish Everyday Shirtfor Outings,University,Traveland Casual Wear B", 137.68m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 32, 1, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High quality kidstown Boys2Piece Summer Set High Quality Cotton Sizes2to5Years Modern Designand Unique Colors from our latest collection. Comfortable and stylish.", null, true, true, "kidstown Boys2Piece Summer Set High Quality Cotton Sizes2to5Years Modern Designand Unique Colors", 102.81m, 20, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 50, null, "/assets/seed/products/ASTK_women_ASTKWomensCapeTrenchcoat/71Tv6b-uu0L._AC_SY741_.jpg", true, "71Tv6b-uu0L._AC_SY741_.jpg", 1, 0 },
                    { 51, null, "/assets/seed/products/ASTK_women_ASTKWomensEssentialPuffJacket/71ZQ6hd7StL._AC_SY741_.jpg", true, "71ZQ6hd7StL._AC_SY741_.jpg", 2, 0 },
                    { 52, null, "/assets/seed/products/AlimensGentle_mens_AlimensGentleSlimFitMensDressShirtsforMenButtonDownLongSleeveDressShirtsWrinkleFreeFormalStainProof/51K5NCVcF0L._AC_SX679_.jpg", true, "51K5NCVcF0L._AC_SX679_.jpg", 3, 0 },
                    { 53, null, "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/61Tv6X+r1dL._AC_SX569_.jpg", true, "61Tv6X+r1dL._AC_SX569_.jpg", 4, 0 },
                    { 54, null, "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensSlimFitEverydayOxfordButtonUpShirtSlimFitEverydayOxfordButtonUpShirt/51bEHcCQE0L._AC_SX569_.jpg", true, "51bEHcCQE0L._AC_SX569_.jpg", 5, 0 },
                    { 55, null, "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStretchBarrelJean/710MuP+3MbL._AC_SX466_.jpg", true, "710MuP+3MbL._AC_SX466_.jpg", 6, 0 },
                    { 56, null, "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStrigidBarrelJean/61Wc1zcwhpL._AC_SX466_.jpg", true, "61Wc1zcwhpL._AC_SX466_.jpg", 7, 0 },
                    { 57, null, "/assets/seed/products/AndoraMensOxfordCotton/618Z3nUCUzL._AC_SX679_.jpg", true, "618Z3nUCUzL._AC_SX679_.jpg", 8, 0 },
                    { 58, null, "/assets/seed/products/AndoraMensSolidPatternHallSleeveWester/611tOusi66L._AC_SX679_.jpg", true, "611tOusi66L._AC_SX679_.jpg", 9, 0 },
                    { 59, null, "/assets/seed/products/DubinikFlannelShirtMensCheckedButtonDownOutdoorCottonCasualShirtsFlannelShirtsMensLongSleeve/81o4U3pfCGL._AC_SX679_.jpg", true, "81o4U3pfCGL._AC_SX679_.jpg", 10, 0 },
                    { 60, null, "/assets/seed/products/FRESKASTORE_women_ShortSleeveBasicTop6229000006/31DQxnVYCOL._AC_.jpg", true, "31DQxnVYCOL._AC_.jpg", 11, 0 },
                    { 61, null, "/assets/seed/products/Generic_women_ESKINOWomensWinterLongCoatSlimWaistBroadclothJacketwithButtonFrontandElegantBeltMultiColorSize/41ivaZqDgsL._AC_SY741_.jpg", true, "41ivaZqDgsL._AC_SY741_.jpg", 12, 0 },
                    { 62, null, "/assets/seed/products/Generic_women_LongWomenCoatGray/51MLt95IRvL._AC_SX569_.jpg", true, "51MLt95IRvL._AC_SX569_.jpg", 13, 0 },
                    { 63, null, "/assets/seed/products/Generic_women_WomensPlushFauxFurHoodedJacketBlackCroppedDesignZipUpFrontWinterCasualWear/310L1CYTxuL._AC_.jpg", true, "310L1CYTxuL._AC_.jpg", 15, 0 },
                    { 64, null, "/assets/seed/products/Generic_women_WomensWideLegTrousersHighWaistPleated111TailoredFitSmartCasualFullLengthStraightCutWomensFashion/31zRDa68EJL._AC_.jpg", true, "31zRDa68EJL._AC_.jpg", 16, 0 },
                    { 65, null, "/assets/seed/products/JACKJONES_mens_JACKJONESMensMarcoSunnyChinoShorts/71YqESc2BqL._AC_SX569_.jpg", true, "71YqESc2BqL._AC_SX569_.jpg", 17, 0 },
                    { 66, null, "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIBabyGirlsHoodedCardiganandBootieBottomSet/61fKx6h3OEL._AC_SY741_.jpg", true, "61fKx6h3OEL._AC_SY741_.jpg", 18, 0 },
                    { 67, null, "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIEmbroideredBabyGirlsSet/41oaWVfmf5L._AC_SY741_.jpg", true, "41oaWVfmf5L._AC_SY741_.jpg", 19, 0 },
                    { 68, null, "/assets/seed/products/LaBEAUTE_women_AWideFitPOPLINShirtForWomenWith/31i5NOfxavL._AC_.jpg", true, "31i5NOfxavL._AC_.jpg", 20, 0 },
                    { 69, null, "/assets/seed/products/LevisMensCLASSICWESTERNSTANDARDWovenTops/816b+px-riL._AC_SX679_.jpg", true, "816b+px-riL._AC_SX679_.jpg", 21, 0 },
                    { 70, null, "/assets/seed/products/PUMA_mens_PUMAMensF1ESSLogoPolo180gBlackClassic/51T0ciE+XhL._AC_SX679_.jpg", true, "51T0ciE+XhL._AC_SX679_.jpg", 23, 0 },
                    { 71, null, "/assets/seed/products/VisittheadidasStoreadidasMensEssentialsSmallLogoPiquéPoloShirtT-Shirt/71-hHXwye6L._AC_SX679_.jpg", true, "71-hHXwye6L._AC_SX679_.jpg", 24, 0 },
                    { 72, null, "/assets/seed/products/adidas_footwear_adidasCopaPure3LeagueFirmMultiGroundBootsunisexadultShoes/71BZTgWpGhL._AC_SY625_ (1).jpg", true, "71BZTgWpGhL._AC_SY625_ (1).jpg", 25, 0 },
                    { 73, null, "/assets/seed/products/adidas_footwear_adidasUNISEXADULTRESPONSERUNNER2SHOES/51HJ3l10kJL._AC_SX625_.jpg", true, "51HJ3l10kJL._AC_SX625_.jpg", 26, 0 },
                    { 74, null, "/assets/seed/products/adidas_mens_adidasMens/414h8y8rQvL._AC_SY695_.jpg", true, "414h8y8rQvL._AC_SY695_.jpg", 27, 0 },
                    { 75, null, "/assets/seed/products/adidas_women_adidasWomensUltrarun5RunningShoes/71V4YxrFg8L._AC_SY625_.jpg", true, "71V4YxrFg8L._AC_SY625_.jpg", 28, 0 },
                    { 76, null, "/assets/seed/products/adidas_women_adidaswomensCOURTFUNKSneaker/51JWnAJ2fmL._AC_SY625_.jpg", true, "51JWnAJ2fmL._AC_SY625_.jpg", 29, 0 },
                    { 77, null, "/assets/seed/products/adidas_women_adidaswomensULTRADREAMDNASHOES/61H70Z36RCL._AC_SX625_.jpg", true, "61H70Z36RCL._AC_SX625_.jpg", 30, 0 },
                    { 78, null, "/assets/seed/products/blackGraphicT-ShirtShortSleeveCrewNeckCasualTopforMenandWomen,StylishEverydayShirtforOutings,University,TravelandCasualWearBYHouseofBlack/61CB4aRY1OL._AC_SY741_.jpg", true, "61CB4aRY1OL._AC_SY741_.jpg", 31, 0 },
                    { 79, null, "/assets/seed/products/kidstown_kids-wear_kidstownBoys2PieceSummerSetHighQualityCottonSizes2to5YearsModernDesignandUniqueColors/51TzrEe7lEL._AC_SX679_.jpg", true, "51TzrEe7lEL._AC_SX679_.jpg", 32, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "ColorsId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 10 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 16 },
                    { 1, 17 },
                    { 1, 21 },
                    { 1, 24 },
                    { 1, 25 },
                    { 1, 26 },
                    { 1, 28 },
                    { 1, 29 },
                    { 1, 32 },
                    { 2, 3 },
                    { 2, 5 },
                    { 2, 7 },
                    { 2, 9 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 18 },
                    { 2, 20 },
                    { 2, 25 },
                    { 2, 26 },
                    { 2, 28 },
                    { 2, 29 },
                    { 2, 30 },
                    { 3, 3 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 9 },
                    { 3, 11 },
                    { 3, 23 },
                    { 3, 25 },
                    { 3, 27 },
                    { 3, 28 },
                    { 3, 29 },
                    { 3, 30 },
                    { 3, 31 },
                    { 3, 32 },
                    { 4, 2 },
                    { 4, 4 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 19 },
                    { 4, 21 },
                    { 4, 22 },
                    { 4, 23 },
                    { 4, 30 },
                    { 5, 2 },
                    { 5, 8 },
                    { 5, 10 },
                    { 5, 11 },
                    { 5, 13 },
                    { 5, 15 },
                    { 5, 19 },
                    { 5, 24 },
                    { 5, 26 },
                    { 5, 32 }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "ProductsId", "SizesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 4 },
                    { 3, 1 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 4 },
                    { 5, 1 },
                    { 5, 3 },
                    { 5, 4 },
                    { 6, 2 },
                    { 6, 3 },
                    { 7, 1 },
                    { 7, 3 },
                    { 8, 3 },
                    { 9, 4 },
                    { 10, 2 },
                    { 10, 3 },
                    { 11, 1 },
                    { 11, 3 },
                    { 12, 1 },
                    { 12, 3 },
                    { 13, 1 },
                    { 13, 3 },
                    { 13, 4 },
                    { 14, 1 },
                    { 15, 1 },
                    { 15, 4 },
                    { 16, 1 },
                    { 16, 2 },
                    { 16, 3 },
                    { 17, 1 },
                    { 17, 2 },
                    { 17, 3 },
                    { 18, 1 },
                    { 18, 2 },
                    { 18, 4 },
                    { 19, 1 },
                    { 19, 3 },
                    { 20, 2 },
                    { 21, 1 },
                    { 22, 1 },
                    { 22, 4 },
                    { 23, 3 },
                    { 23, 4 },
                    { 24, 3 },
                    { 25, 1 },
                    { 26, 1 },
                    { 26, 2 },
                    { 26, 3 },
                    { 27, 1 },
                    { 27, 2 },
                    { 27, 4 },
                    { 28, 2 },
                    { 28, 4 },
                    { 29, 1 },
                    { 30, 2 },
                    { 30, 4 },
                    { 31, 2 },
                    { 32, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 17 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 21 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 24 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 25 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 26 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 28 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 29 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 1, 32 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 18 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 20 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 25 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 26 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 28 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 29 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 2, 30 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 9 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 11 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 23 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 25 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 27 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 28 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 29 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 30 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 31 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 3, 32 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 19 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 21 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 22 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 23 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 4, 30 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 5, 10 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 5, 13 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 5, 15 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 5, 19 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 5, 24 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 5, 26 });

            migrationBuilder.DeleteData(
                table: "ProductColors",
                keyColumns: new[] { "ColorsId", "ProductsId" },
                keyValues: new object[] { 5, 32 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 6, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 9, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 15, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 16, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 16, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 16, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 17, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 17, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 18, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 18, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 19, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 19, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 20, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 21, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 22, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 22, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 23, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 23, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 24, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 25, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 26, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 26, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 26, 3 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 27, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 27, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 27, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 28, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 28, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 29, 1 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 30, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 30, 4 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 31, 2 });

            migrationBuilder.DeleteData(
                table: "ProductSizes",
                keyColumns: new[] { "ProductsId", "SizesId" },
                keyValues: new object[] { 32, 2 });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageId",
                value: null);
        }
    }
}
