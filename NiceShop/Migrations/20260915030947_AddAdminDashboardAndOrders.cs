using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NiceShop.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminDashboardAndOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "AddressType", "Building", "City", "CustomerId", "Government", "Street", "ZipCode" },
                values: new object[] { 1, 0, "1A", "Cairo", 1, "Cairo", "Test Street", "" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "dashboard-test-user-id", 0, "00000000-0000-0000-0000-000000000000", "test@dashboard.com", true, null, false, null, "TEST@DASHBOARD.COM", "TEST@DASHBOARD.COM", "AQAAAAEAACcQAAAAEA==...", null, false, "00000000-0000-0000-0000-000000000000", false, "test@dashboard.com" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Discount", "Price" },
                values: new object[] { "Experience ultimate comfort and style with the Astkwomens Cape Trenchcoat. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", 250.00m, 1250.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Discount", "Price" },
                values: new object[] { "Experience ultimate comfort and style with the Astkwomens Essential Puff Jacket. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", 150.00m, 850.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Experience ultimate comfort and style with the Alimens Gentle Slim Fit Mens Dress Shirtsfor Men Button Down Long Sleeve Dress Shirts Wrinkle Free Formal Stain Proof. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "Alimens Gentle Slim Fit Mens Dress Shirtsfor Men Button Down Long Sleeve Dress Shirts Wrinkle Free Formal Stain Proof", 550.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Experience ultimate comfort and style with the American Eagle Mens Aeflex12Khaki Short. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", 450.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Stock" },
                values: new object[] { "Experience ultimate comfort and style with the American Eagle Mens Slim Fit Everyday Oxford Button Up Shirt Slim Fit Everyday Oxford Button Up Shirt. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "American Eagle Mens Slim Fit Everyday Oxford Button Up Shirt Slim Fit Everyday Oxford Button Up Shirt", 2 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Experience ultimate comfort and style with the American Eagle Womens Stretch Barrel Jean. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", 4 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Experience ultimate comfort and style with the American Eagle Womens Strigid Barrel Jean. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 2, "Experience ultimate comfort and style with the Andora Mens Oxford Cotton. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "Description", "Stock" },
                values: new object[] { 2, "Experience ultimate comfort and style with the Andora Mens Solid Pattern Hall Sleeve Wester. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", 1 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 2, "Experience ultimate comfort and style with the Dubinik Flannel Shirt Mens Checked Button Down Outdoor Cotton Casual Shirts Flannel Shirts Mens Long Sleeve. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "Dubinik Flannel Shirt Mens Checked Button Down Outdoor Cotton Casual Shirts Flannel Shirts Mens Long Sleeve" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Experience ultimate comfort and style with the Short Sleeve Basic Top6229000006. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Experience ultimate comfort and style with the Eskinowomens Winter Long Coat Slim Waist Broadcloth Jacketwith Button Frontand Elegant Belt Multi Color Size. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "ESKINOWomens Winter Long Coat Slim Waist Broadcloth Jacketwith Button Frontand Elegant Belt Multi Color Size" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "Experience ultimate comfort and style with the Long Women Coat Gray. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Experience ultimate comfort and style with the Womens Dark Brown Wide Leg High Waist Casual Fashion Pants. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "Womens Dark Brown Wide Leg High Waist Casual Fashion Pants" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Experience ultimate comfort and style with the Womens Plush Faux Fur Hooded Jacket Black Cropped Design Zip Up Front Winter Casual Wear. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "Womens Plush Faux Fur Hooded Jacket Black Cropped Design Zip Up Front Winter Casual Wear" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Experience ultimate comfort and style with the Womens Wide Leg Trousers High Waist Pleated111Tailored Fit Smart Casual Full Length Straight Cut Womens Fashion. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "Womens Wide Leg Trousers High Waist Pleated111Tailored Fit Smart Casual Full Length Straight Cut Womens Fashion" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: "Experience ultimate comfort and style with the Jackjonesmens Marco Sunny Chino Shorts. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Experience ultimate comfort and style with the Lcwaikikibaby Girls Hooded Cardiganand Bootie Bottom Set. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "LCWAIKIKIBaby Girls Hooded Cardiganand Bootie Bottom Set" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "Description",
                value: "Experience ultimate comfort and style with the Lcwaikikiembroidered Baby Girls Set. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "Description",
                value: "Experience ultimate comfort and style with the Awide Fit Poplinshirt For Women With. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 2, "Experience ultimate comfort and style with the Levis Mens Classicwesternstandardwoven Tops. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "Description",
                value: "Experience ultimate comfort and style with the Levis Women Seasonal Fashion Jacket. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Description",
                value: "Experience ultimate comfort and style with the Pumamens F1Esslogo Polo180G Black Classic. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 2, "Experience ultimate comfort and style with the Visittheadidas Storeadidas Mens Essentials Small Logo Piquépolo Shirt T Shirt. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "Visittheadidas Storeadidas Mens Essentials Small Logo PiquéPolo Shirt T Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 4, "Experience ultimate comfort and style with the Adidas Copa Pure3League Firm Multi Ground Bootsunisexadult Shoes. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "adidas Copa Pure3League Firm Multi Ground Bootsunisexadult Shoes" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 4, "Experience ultimate comfort and style with the Adidas Unisexadultresponserunner2Shoes. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "Description",
                value: "Experience ultimate comfort and style with the Adidas Mens. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 2, "Experience ultimate comfort and style with the Adidas Womens Ultrarun5Running Shoes. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 2, "Experience ultimate comfort and style with the Adidaswomens Courtfunksneaker. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 2, "Experience ultimate comfort and style with the Adidaswomens Ultradreamdnashoes. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Experience ultimate comfort and style with the Black Graphic T Shirt Short Sleeve Crew Neck Casual Topfor Menand Women,Stylish Everyday Shirtfor Outings,University,Traveland Casual Wear Byhouseof Black. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "black Graphic T Shirt Short Sleeve Crew Neck Casual Topfor Menand Women,Stylish Everyday Shirtfor Outings,University,Traveland Casual Wea..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Experience ultimate comfort and style with the Kidstown Boys2Piece Summer Set High Quality Cotton Sizes2To5Years Modern Designand Unique Colors. Crafted with premium materials, this piece from our latest collection is designed to elevate your everyday look. Perfect for any occasion, it seamlessly blends modern design with exceptional durability.", "kidstown Boys2Piece Summer Set High Quality Cotton Sizes2to5Years Modern Designand Unique Colors" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FName", "LName" },
                values: new object[] { "dashboard-test-user-id", "Dashboard", "Tester" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "CancellationReason", "CouponId", "CustomerId", "Discount", "Notes", "Number", "OrderDate", "ShippingCost", "Status", "Subtotal", "Total" },
                values: new object[] { 1, 1, null, null, "dashboard-test-user-id", null, null, "ORD-001", new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), 0m, 1, 2400.00m, 2400.00m });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "CancellationReason", "CouponId", "CustomerId", "Discount", "Notes", "Number", "OrderDate", "ShippingCost", "Subtotal", "Total" },
                values: new object[] { 2, 1, null, null, "dashboard-test-user-id", null, null, "ORD-002", new DateTime(2026, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), 0m, 550.00m, 550.00m });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AddressId", "CancellationReason", "CouponId", "CustomerId", "Discount", "Notes", "Number", "OrderDate", "ShippingCost", "Status", "Subtotal", "Total" },
                values: new object[,]
                {
                    { 3, 1, null, null, "dashboard-test-user-id", null, null, "ORD-003", new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Utc), 0m, 1, 1450.00m, 1450.00m },
                    { 4, 1, null, null, "dashboard-test-user-id", null, null, "ORD-004", new DateTime(2026, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), 0m, 1, 5600.00m, 5600.00m },
                    { 5, 1, null, null, "dashboard-test-user-id", null, null, "ORD-005", new DateTime(2026, 6, 15, 0, 0, 0, 0, DateTimeKind.Utc), 0m, 1, 3000.00m, 3000.00m },
                    { 6, 1, null, null, "dashboard-test-user-id", null, null, "ORD-006", new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), 0m, 1, 4500.00m, 4500.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Color", "Name", "OrderId", "Price", "ProductId", "Quantity", "Size" },
                values: new object[,]
                {
                    { 1, "Black", "ASTKWomens Cape Trenchcoat", 1, 1000.00m, 1, 1, null },
                    { 2, "Red", "ASTKWomens Essential Puff Jacket", 1, 700.00m, 2, 2, null },
                    { 3, "White", "Alimens Gentle Slim Fit Mens Dress", 2, 550.00m, 3, 1, null },
                    { 4, "Black", "ASTKWomens Cape Trenchcoat", 3, 1000.00m, 1, 1, null },
                    { 5, "Blue", "American Eagle Mens AEFlex12Khaki", 3, 450.00m, 4, 1, null },
                    { 6, "Red", "ASTKWomens Essential Puff Jacket", 4, 700.00m, 2, 8, null },
                    { 7, "Black", "ASTKWomens Cape Trenchcoat", 5, 1000.00m, 1, 3, null },
                    { 8, "Blue", "American Eagle Mens AEFlex12Khaki", 6, 450.00m, 4, 10, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OrderItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: "dashboard-test-user-id");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dashboard-test-user-id");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Discount", "Price" },
                values: new object[] { "Stay warm and stylish with this elegant cape trench coat, featuring a timeless silhouette, sophisticated double-breasted front, and premium wind-resistant fabric.", 20.62m, 103.12m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Discount", "Price" },
                values: new object[] { "A must-have winter essential, this puff jacket offers lightweight insulation, a water-resistant outer shell, and an ultra-cozy fit without compromising on your everyday style.", 4.82m, 24.12m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Name", "Price" },
                values: new object[] { "Premium slim-fit dress shirt crafted from breathable wrinkle-free cotton. Perfectly tailored for formal occasions, weddings, or a sharp look at the modern office.", "Alimens Gentle Slim Fit Mens Dress Shirts...", 96.59m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Description", "Price" },
                values: new object[] { "Comfortable and versatile khaki shorts equipped with signature AEFlex technology for superior mobility and a stretch waistband for all-day comfort.", 32.05m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Description", "Name", "Stock" },
                values: new object[] { "Classic slim-fit Oxford shirt designed for everyday wear. Made from durable yet soft brushed cotton for a tailored, smart-casual look.", "American Eagle Mens Slim Fit Everyday Oxford...", 100 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Stock" },
                values: new object[] { "Trendy stretch barrel jeans offering a relaxed, curved fit. Features high-quality stretch denim that moves with you for ultimate everyday comfort.", 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Rigid structured denim with a high-waisted vintage cut. The barrel leg brings a modern, edgy twist to classic non-stretch denim.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 1, "High-quality Oxford cotton shirt offering durability, breathability, and a sharp, structured fit. An essential staple for any gentleman's wardrobe." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CategoryId", "Description", "Stock" },
                values: new object[] { 1, "A casual half-sleeve western shirt with a clean solid pattern. Lightweight and perfect for a laid-back weekend or warm-weather outings.", 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 1, "Classic checked flannel shirt made from ultra-soft, brushed fabric. Ideal for layering over tees during the crisp autumn and winter months.", "Dubinik Flannel Shirt Mens Checked..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "An everyday essential short-sleeve top. Crafted with soft, breathable modal-blend fabric, it’s versatile enough to tuck into jeans or layer under a blazer.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Stay cozy in this elegant long winter coat, designed with a heavy-duty wind-resistant outer shell, deep pockets, and a heavily insulated lining.", "ESKINOWomens Winter Long Coat..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                column: "Description",
                value: "Chic gray long coat with a tailored, slim fit. Features an elegant lapel collar, providing a highly sophisticated outer layer for colder seasons.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Flattering dark brown wide-leg trousers featuring a high waist and a smooth, flowing drape. Perfect for office wear or elevated evening outfits.", "Womens Dark Brown Wide Leg High Waist..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Ultra-soft plush faux fur hooded jacket. Combines luxury, deep warmth, and a modern streetwear aesthetic for cold days out on the town.", "Womens Plush Faux Fur Hooded Jacket..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Elegant wide-leg trousers crafted from premium anti-wrinkle fabric. Offering superior comfort, practical side pockets, and a beautifully polished silhouette.", "Womens Wide Leg Trousers..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                column: "Description",
                value: "Classic Marco Sunny chino shorts featuring a tailored slim fit, breathable stretch-cotton fabric, and versatile styling options for sunny days.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Adorable hooded cardigan for baby girls. Made from soft, skin-friendly knit material to keep your little one warm and comfortable all day.", "LCWAIKIKIBaby Girls Hooded Cardigan..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                column: "Description",
                value: "Beautifully embroidered two-piece set for baby girls. Blends exceptional comfort with delicate floral detailing for special occasions or daily wear.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                column: "Description",
                value: "A relaxed, wide-fit poplin shirt for women. Features drop shoulders and a crisp collar, offering a breathable and effortlessly chic oversized look.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 1, "The iconic standard western woven top by Levi's. Features signature pearl snaps, pointed yokes, and legendary durable denim construction." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22,
                column: "Description",
                value: "A versatile seasonal trucker jacket offering lightweight protection. Designed with a slightly cropped fit and timeless denim styling.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23,
                column: "Description",
                value: "Sporty and classic F1-inspired polo shirt. Features a lightweight 180g breathable pique fabric, ribbed collar, and a sleek understated logo design.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 1, "Essential small logo t-shirt crafted from a premium soft cotton blend. Delivers ultimate casual comfort and clean, minimalist athletic style.", "Visittheadidas Storeadidas Mens Essentials Small Logo..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[] { 5, "High-performance firm multi-ground football boots. Designed with a synthetic leather upper for a soft touch, optimal traction, and precision ball control.", "adidas Copa Pure3League Firm Multi Ground Boots..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 5, "Durable and highly responsive running shoes built for everyday training. Features a breathable mesh upper and a supportive cushioned midsole." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27,
                column: "Description",
                value: "Classic athletic apparel designed to provide maximum comfort and freedom of movement. Perfect for intense workouts or relaxed rest days.");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 6, "Lightweight and breathable Ultrarun running shoes tailored for women. Features advanced bounce cushioning for an energized and smooth stride." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 6, "Stylish and highly comfortable court funk sneakers. Blending retro tennis aesthetics with modern platform soles and streetwear flair." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "CategoryId", "Description" },
                values: new object[] { 6, "Experience unmatched comfort with these ultra-dream DNA shoes. Engineered with adaptive cloud-like cushioning for all-day wear and support." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "Description", "Name" },
                values: new object[] { "A casual black graphic t-shirt with a classic crew neck and short sleeves. Made from soft cotton, perfect for everyday casual wear.", "black Graphic T Shirt Short Sleeve Crew Neck..." });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Fun and comfortable two-piece summer set for boys. Made with breathable, lightweight fabric to keep them cool and active during warm sunny days.", "kidstown Boys2Piece Summer Set..." });
        }
    }
}
