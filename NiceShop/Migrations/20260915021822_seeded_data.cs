using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NiceShop.Migrations
{
    /// <inheritdoc />
    public partial class seeded_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Government = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Street = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Building = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AddressType = table.Column<int>(type: "int", nullable: false),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HexCode = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Coupons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coupons", x => x.Id);
                    table.CheckConstraint("CK_Coupon_Percentage", "[Percentage] >= 0 AND [Percentage] <= 100");
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: true),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ShippingCost = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsCanceled = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    CancellationReason = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CouponId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.CheckConstraint("CK_Order_Total", "[Total] >= 0");
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Coupons_CouponId",
                        column: x => x.CouponId,
                        principalTable: "Coupons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ProductCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.CheckConstraint("CK_CartItem_Quantity", "[Quantity] > 0");
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    ImageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(3,2)", precision: 3, scale: 2, nullable: false, defaultValue: 0m),
                    IsFeatured = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsBestseller = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsOnSale = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Stock = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    ReviewCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.CheckConstraint("CK_Product_Price", "[Price] >= 0");
                    table.CheckConstraint("CK_Product_Rating", "[Rating] >= 0 AND [Rating] <= 5");
                    table.CheckConstraint("CK_Product_Stock", "[Stock] >= 0");
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDefault = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Caption = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.CheckConstraint("CK_OrderItem_Price", "[Price] >= 0");
                    table.CheckConstraint("CK_OrderItem_Quantity", "[Quantity] > 0");
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductColors",
                columns: table => new
                {
                    ColorsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductColors", x => new { x.ColorsId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_ProductColors_Colors_ColorsId",
                        column: x => x.ColorsId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductColors_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSizes",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    SizesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSizes", x => new { x.ProductsId, x.SizesId });
                    table.ForeignKey(
                        name: "FK_ProductSizes_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSizes_Sizes_SizesId",
                        column: x => x.SizesId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    IsVerifiedUser = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.CheckConstraint("CK_Review_Rating", "[Rating] >= 1 AND [Rating] <= 5");
                    table.ForeignKey(
                        name: "FK_Reviews_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "HexCode", "Name" },
                values: new object[,]
                {
                    { 1, "#000000", "Black" },
                    { 2, "#FFFFFF", "White" },
                    { 3, "#EF4444", "Red" },
                    { 4, "#3B82F6", "Blue" },
                    { 5, "#10B981", "Green" },
                    { 6, "#1E3A8A", "Navy" },
                    { 7, "#F5F5DC", "Beige" },
                    { 8, "#800020", "Burgundy" },
                    { 9, "#4B5320", "Olive" },
                    { 10, "#6B7280", "Gray" },
                    { 11, "#EC4899", "Pink" },
                    { 12, "#D4AF37", "Gold" },
                    { 13, "#C0C0C0", "Silver" },
                    { 14, "#8B4513", "Brown" },
                    { 15, "#8B5CF6", "Purple" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 10, null, "/assets/seed/categories/men.png", true, "men.png", null, 0 },
                    { 11, null, "/assets/seed/categories/women.png", true, "women.png", null, 0 },
                    { 12, null, "/assets/seed/categories/kids.png", true, "kids.png", null, 0 },
                    { 13, null, "/assets/seed/categories/footwere.png", true, "footwere.png", null, 0 },
                    { 14, null, "/assets/seed/categories/mens-footwear.png", true, "mens-footwear.png", null, 0 },
                    { 15, null, "/assets/seed/categories/womens-footwear.png", true, "womens-footwear.png", null, 0 },
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

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Code", "Name" },
                values: new object[,]
                {
                    { 1, "S", "Small" },
                    { 2, "M", "Medium" },
                    { 3, "L", "Large" },
                    { 4, "XL", "Extra Large" },
                    { 5, "XXS", "Extra Extra Small" },
                    { 6, "XS", "Extra Small" },
                    { 7, "XXL", "Double Extra Large" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Country", "ImageId", "Name" },
                values: new object[,]
                {
                    { 1, "USA", 21, "Nike" },
                    { 2, "Germany", 22, "Adidas" },
                    { 3, "Spain", 23, "Zara" },
                    { 4, "Italy", 24, "Gucci" },
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
                    { 4, 13, "Unisex Footwear", "unisex-footwear" },
                    { 5, 14, "Men's Footwear", "mens-footwear" },
                    { 6, 15, "Women's Footwear", "womens-footwear" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsOnSale", "Name", "Price", "UpdatedAt" },
                values: new object[] { 1, 7, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stay warm and stylish with this elegant cape trench coat, featuring a timeless silhouette, sophisticated double-breasted front, and premium wind-resistant fabric.", 20.62m, true, true, true, "ASTKWomens Cape Trenchcoat", 103.12m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "UpdatedAt" },
                values: new object[] { 2, 7, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A must-have winter essential, this puff jacket offers lightweight insulation, a water-resistant outer shell, and an ultra-cozy fit without compromising on your everyday style.", 4.82m, true, true, true, true, "ASTKWomens Essential Puff Jacket", 24.12m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "UpdatedAt" },
                values: new object[] { 3, 1, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Premium slim-fit dress shirt crafted from breathable wrinkle-free cotton. Perfectly tailored for formal occasions, weddings, or a sharp look at the modern office.", null, true, true, "Alimens Gentle Slim Fit Mens Dress Shirts...", 96.59m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "Name", "Price", "UpdatedAt" },
                values: new object[] { 4, 5, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Comfortable and versatile khaki shorts equipped with signature AEFlex technology for superior mobility and a stretch waistband for all-day comfort.", null, true, "American Eagle Mens AEFlex12Khaki Short", 32.05m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 5, 5, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Classic slim-fit Oxford shirt designed for everyday wear. Made from durable yet soft brushed cotton for a tailored, smart-casual look.", 18.35m, true, true, true, "American Eagle Mens Slim Fit Everyday Oxford...", 91.76m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 6, 5, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Trendy stretch barrel jeans offering a relaxed, curved fit. Features high-quality stretch denim that moves with you for ultimate everyday comfort.", null, true, "American Eagle Womens Stretch Barrel Jean", 132.63m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "UpdatedAt" },
                values: new object[] { 7, 5, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Rigid structured denim with a high-waisted vintage cut. The barrel leg brings a modern, edgy twist to classic non-stretch denim.", 10.94m, true, true, true, true, "American Eagle Womens Strigid Barrel Jean", 54.7m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "Name", "Price", "UpdatedAt" },
                values: new object[] { 8, 6, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality Oxford cotton shirt offering durability, breathability, and a sharp, structured fit. An essential staple for any gentleman's wardrobe.", null, true, "Andora Mens Oxford Cotton", 49.77m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 9, 6, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A casual half-sleeve western shirt with a clean solid pattern. Lightweight and perfect for a laid-back weekend or warm-weather outings.", 9.53m, true, true, "Andora Mens Solid Pattern Hall Sleeve Wester", 47.63m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 10, 1, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Classic checked flannel shirt made from ultra-soft, brushed fabric. Ideal for layering over tees during the crisp autumn and winter months.", 27.34m, true, true, true, "Dubinik Flannel Shirt Mens Checked...", 136.71m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 11, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "An everyday essential short-sleeve top. Crafted with soft, breathable modal-blend fabric, it’s versatile enough to tuck into jeans or layer under a blazer.", null, true, true, "Short Sleeve Basic Top6229000006", 40.79m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 12, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stay cozy in this elegant long winter coat, designed with a heavy-duty wind-resistant outer shell, deep pockets, and a heavily insulated lining.", 22.74m, true, true, "ESKINOWomens Winter Long Coat...", 113.68m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { 13, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Chic gray long coat with a tailored, slim fit. Features an elegant lapel collar, providing a highly sophisticated outer layer for colder seasons.", null, true, true, true, "Long Women Coat Gray", 133.85m, 20, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 14, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Flattering dark brown wide-leg trousers featuring a high waist and a smooth, flowing drape. Perfect for office wear or elevated evening outfits.", null, true, true, true, "Womens Dark Brown Wide Leg High Waist...", 97.85m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 15, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Ultra-soft plush faux fur hooded jacket. Combines luxury, deep warmth, and a modern streetwear aesthetic for cold days out on the town.", 6.22m, true, true, true, true, "Womens Plush Faux Fur Hooded Jacket...", 31.12m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 16, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Elegant wide-leg trousers crafted from premium anti-wrinkle fabric. Offering superior comfort, practical side pockets, and a beautifully polished silhouette.", null, true, "Womens Wide Leg Trousers...", 140.75m, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 17, 8, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Classic Marco Sunny chino shorts featuring a tailored slim fit, breathable stretch-cotton fabric, and versatile styling options for sunny days.", 12.79m, true, true, true, true, "JACKJONESMens Marco Sunny Chino Shorts", 63.94m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "UpdatedAt" },
                values: new object[] { 18, 10, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Adorable hooded cardigan for baby girls. Made from soft, skin-friendly knit material to keep your little one warm and comfortable all day.", null, true, true, "LCWAIKIKIBaby Girls Hooded Cardigan...", 131.74m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 19, 10, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Beautifully embroidered two-piece set for baby girls. Blends exceptional comfort with delicate floral detailing for special occasions or daily wear.", null, true, true, true, "LCWAIKIKIEmbroidered Baby Girls Set", 124.96m, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "UpdatedAt" },
                values: new object[] { 20, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A relaxed, wide-fit poplin shirt for women. Features drop shoulders and a crisp collar, offering a breathable and effortlessly chic oversized look.", null, true, true, "AWide Fit POPLINShirt For Women With", 104.94m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 21, 9, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "The iconic standard western woven top by Levi's. Features signature pearl snaps, pointed yokes, and legendary durable denim construction.", null, true, true, "Levis Mens CLASSICWESTERNSTANDARDWoven Tops", 89.71m, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 22, 9, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A versatile seasonal trucker jacket offering lightweight protection. Designed with a slightly cropped fit and timeless denim styling.", 5.31m, true, true, true, true, "Levis Women Seasonal Fashion Jacket", 26.57m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "IsOnSale", "Name", "Price", "UpdatedAt" },
                values: new object[] { 23, 11, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Sporty and classic F1-inspired polo shirt. Features a lightweight 180g breathable pique fabric, ribbed collar, and a sleek understated logo design.", 26.48m, true, true, true, "PUMAMens F1ESSLogo Polo180g Black Classic", 132.39m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { 24, 2, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Essential small logo t-shirt crafted from a premium soft cotton blend. Delivers ultimate casual comfort and clean, minimalist athletic style.", 28.89m, true, true, true, "Visittheadidas Storeadidas Mens Essentials Small Logo...", 144.44m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 25, 2, 5, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High-performance firm multi-ground football boots. Designed with a synthetic leather upper for a soft touch, optimal traction, and precision ball control.", 5.48m, true, true, true, "adidas Copa Pure3League Firm Multi Ground Boots...", 27.42m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 26, 2, 5, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Durable and highly responsive running shoes built for everyday training. Features a breathable mesh upper and a supportive cushioned midsole.", 21.55m, true, true, true, "adidas UNISEXADULTRESPONSERUNNER2SHOES", 107.77m, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 27, 2, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Classic athletic apparel designed to provide maximum comfort and freedom of movement. Perfect for intense workouts or relaxed rest days.", null, true, true, "adidas Mens", 107.05m, 20, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "IsFeatured", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 28, 2, 6, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Lightweight and breathable Ultrarun running shoes tailored for women. Features advanced bounce cushioning for an energized and smooth stride.", 4.24m, true, true, true, true, "adidas Womens Ultrarun5Running Shoes", 21.2m, 100, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsBestseller", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 29, 2, 6, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Stylish and highly comfortable court funk sneakers. Blending retro tennis aesthetics with modern platform soles and streetwear flair.", null, true, true, "adidaswomens COURTFUNKSneaker", 57.04m, 50, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsOnSale", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 30, 2, 6, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Experience unmatched comfort with these ultra-dream DNA shoes. Engineered with adaptive cloud-like cushioning for all-day wear and support.", 23.3m, true, true, "adidaswomens ULTRADREAMDNASHOES", 116.5m, 10, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "UpdatedAt" },
                values: new object[] { 31, 1, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "A casual black graphic t-shirt with a classic crew neck and short sleeves. Made from soft cotton, perfect for everyday casual wear.", null, true, true, "black Graphic T Shirt Short Sleeve Crew Neck...", 137.68m, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BrandId", "CategoryId", "CreatedAt", "Description", "Discount", "IsActive", "IsFeatured", "Name", "Price", "Stock", "UpdatedAt" },
                values: new object[] { 32, 1, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Fun and comfortable two-piece summer set for boys. Made with breathable, lightweight fabric to keep them cool and active during warm sunny days.", null, true, true, "kidstown Boys2Piece Summer Set...", 102.81m, 20, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 50, null, "/assets/seed/products/ASTK_women_ASTKWomensCapeTrenchcoat/71Tv6b-uu0L._AC_SY741_.jpg", true, "71Tv6b-uu0L._AC_SY741_.jpg", 1, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[] { 51, null, "/assets/seed/products/ASTK_women_ASTKWomensCapeTrenchcoat/71i81TMayhL._AC_SY741_.jpg", "71i81TMayhL._AC_SY741_.jpg", 1, 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 52, null, "/assets/seed/products/ASTK_women_ASTKWomensEssentialPuffJacket/71ZQ6hd7StL._AC_SY741_.jpg", true, "71ZQ6hd7StL._AC_SY741_.jpg", 2, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[] { 53, null, "/assets/seed/products/ASTK_women_ASTKWomensEssentialPuffJacket/71cvCIRw0cL._AC_SY741_.jpg", "71cvCIRw0cL._AC_SY741_.jpg", 2, 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 54, null, "/assets/seed/products/AlimensGentle_mens_AlimensGentleSlimFitMensDressShirtsforMenButtonDownLongSleeveDressShirtsWrinkleFreeFormalStainProof/51K5NCVcF0L._AC_SX679_.jpg", true, "51K5NCVcF0L._AC_SX679_.jpg", 3, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 55, null, "/assets/seed/products/AlimensGentle_mens_AlimensGentleSlimFitMensDressShirtsforMenButtonDownLongSleeveDressShirtsWrinkleFreeFormalStainProof/714eddH2ewL._AC_SX569_.jpg", "714eddH2ewL._AC_SX569_.jpg", 3, 1 },
                    { 56, null, "/assets/seed/products/AlimensGentle_mens_AlimensGentleSlimFitMensDressShirtsforMenButtonDownLongSleeveDressShirtsWrinkleFreeFormalStainProof/71RaeOTscyL._AC_SX569_ (1).jpg", "71RaeOTscyL._AC_SX569_ (1).jpg", 3, 1 },
                    { 57, null, "/assets/seed/products/AlimensGentle_mens_AlimensGentleSlimFitMensDressShirtsforMenButtonDownLongSleeveDressShirtsWrinkleFreeFormalStainProof/71RaeOTscyL._AC_SX569_.jpg", "71RaeOTscyL._AC_SX569_.jpg", 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 58, null, "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/61Tv6X+r1dL._AC_SX569_.jpg", true, "61Tv6X+r1dL._AC_SX569_.jpg", 4, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 59, null, "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/61eEOHexKHL._AC_SX569_.jpg", "61eEOHexKHL._AC_SX569_.jpg", 4, 1 },
                    { 60, null, "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/61l7AKAe6XL._AC_SX569_ (1).jpg", "61l7AKAe6XL._AC_SX569_ (1).jpg", 4, 1 },
                    { 61, null, "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/61l7AKAe6XL._AC_SX569_.jpg", "61l7AKAe6XL._AC_SX569_.jpg", 4, 1 },
                    { 62, null, "/assets/seed/products/AmericanEagle_mens_AmericanEagleMensAEFlex12KhakiShort/71ZGKUkfuWL._AC_SX569_.jpg", "71ZGKUkfuWL._AC_SX569_.jpg", 4, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 63, null, "/assets/seed/products/AmericanEagle_mens_SlimFitEverydayOxfordShirt/51bEHcCQE0L._AC_SX569_.jpg", true, "51bEHcCQE0L._AC_SX569_.jpg", 5, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 64, null, "/assets/seed/products/AmericanEagle_mens_SlimFitEverydayOxfordShirt/61RGI5JEkQL._AC_SX569_.jpg", "61RGI5JEkQL._AC_SX569_.jpg", 5, 1 },
                    { 65, null, "/assets/seed/products/AmericanEagle_mens_SlimFitEverydayOxfordShirt/61ucX1Z4TGL._AC_SX569_.jpg", "61ucX1Z4TGL._AC_SX569_.jpg", 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 66, null, "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStretchBarrelJean/710MuP+3MbL._AC_SX466_.jpg", true, "710MuP+3MbL._AC_SX466_.jpg", 6, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[] { 67, null, "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStretchBarrelJean/81OgKdiATwL._AC_SX466_.jpg", "81OgKdiATwL._AC_SX466_.jpg", 6, 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 68, null, "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStrigidBarrelJean/61Wc1zcwhpL._AC_SX466_.jpg", true, "61Wc1zcwhpL._AC_SX466_.jpg", 7, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 69, null, "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStrigidBarrelJean/71R2u84ujwL._AC_SX466_.jpg", "71R2u84ujwL._AC_SX466_.jpg", 7, 1 },
                    { 70, null, "/assets/seed/products/AmericanEagle_women_AmericanEagleWomensStrigidBarrelJean/71nOqpeJLML._AC_SX466_.jpg", "71nOqpeJLML._AC_SX466_.jpg", 7, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 71, null, "/assets/seed/products/AndoraMensOxfordCotton/618Z3nUCUzL._AC_SX679_.jpg", true, "618Z3nUCUzL._AC_SX679_.jpg", 8, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 72, null, "/assets/seed/products/AndoraMensOxfordCotton/618myyjIRLL._AC_SX679_.jpg", "618myyjIRLL._AC_SX679_.jpg", 8, 1 },
                    { 73, null, "/assets/seed/products/AndoraMensOxfordCotton/61UDkcqc+CL._AC_SX679_.jpg", "61UDkcqc+CL._AC_SX679_.jpg", 8, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 74, null, "/assets/seed/products/AndoraMensSolidPatternHallSleeveWester/611tOusi66L._AC_SX679_.jpg", true, "611tOusi66L._AC_SX679_.jpg", 9, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 75, null, "/assets/seed/products/AndoraMensSolidPatternHallSleeveWester/61ZxB3vTf4L._AC_SX679_.jpg", "61ZxB3vTf4L._AC_SX679_.jpg", 9, 1 },
                    { 76, null, "/assets/seed/products/AndoraMensSolidPatternHallSleeveWester/61xjiObk7vL._AC_SX679_.jpg", "61xjiObk7vL._AC_SX679_.jpg", 9, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 77, null, "/assets/seed/products/DubinikFlannelShirtMensCheckedButtonDownOutdoorCottonCasualShirtsFlannelShirtsMensLongSleeve/81o4U3pfCGL._AC_SX679_.jpg", true, "81o4U3pfCGL._AC_SX679_.jpg", 10, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 78, null, "/assets/seed/products/DubinikFlannelShirtMensCheckedButtonDownOutdoorCottonCasualShirtsFlannelShirtsMensLongSleeve/91dDWgfHgHL._AC_SX679_.jpg", "91dDWgfHgHL._AC_SX679_.jpg", 10, 1 },
                    { 79, null, "/assets/seed/products/DubinikFlannelShirtMensCheckedButtonDownOutdoorCottonCasualShirtsFlannelShirtsMensLongSleeve/91z0Xf8MK2L._AC_SX679_.jpg", "91z0Xf8MK2L._AC_SX679_.jpg", 10, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 80, null, "/assets/seed/products/FRESKASTORE_women_ShortSleeveBasicTop6229000006/31DQxnVYCOL._AC_.jpg", true, "31DQxnVYCOL._AC_.jpg", 11, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 81, null, "/assets/seed/products/FRESKASTORE_women_ShortSleeveBasicTop6229000006/41N34DcpLvL._AC_SX569_.jpg", "41N34DcpLvL._AC_SX569_.jpg", 11, 1 },
                    { 82, null, "/assets/seed/products/FRESKASTORE_women_ShortSleeveBasicTop6229000006/41lYW4DS5EL._AC_SX569_.jpg", "41lYW4DS5EL._AC_SX569_.jpg", 11, 1 },
                    { 83, null, "/assets/seed/products/FRESKASTORE_women_ShortSleeveBasicTop6229000006/51KMPUGFdOL._AC_SX569_.jpg", "51KMPUGFdOL._AC_SX569_.jpg", 11, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 84, null, "/assets/seed/products/Generic_women_ESKINOWomensWinterLongCoatSlimWaistBroadclothJacketwithButtonFrontandElegantBeltMultiColorSize/41ivaZqDgsL._AC_SY741_.jpg", true, "41ivaZqDgsL._AC_SY741_.jpg", 12, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 85, null, "/assets/seed/products/Generic_women_ESKINOWomensWinterLongCoatSlimWaistBroadclothJacketwithButtonFrontandElegantBeltMultiColorSize/611dbxlkzhL._AC_SX679_.jpg", "611dbxlkzhL._AC_SX679_.jpg", 12, 1 },
                    { 86, null, "/assets/seed/products/Generic_women_ESKINOWomensWinterLongCoatSlimWaistBroadclothJacketwithButtonFrontandElegantBeltMultiColorSize/61zMIlPw4PL._AC_SY741_.jpg", "61zMIlPw4PL._AC_SY741_.jpg", 12, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 87, null, "/assets/seed/products/Generic_women_LongWomenCoatGray/51MLt95IRvL._AC_SX569_.jpg", true, "51MLt95IRvL._AC_SX569_.jpg", 13, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 88, null, "/assets/seed/products/Generic_women_LongWomenCoatGray/61ycJHorzvL._AC_SX679_.jpg", "61ycJHorzvL._AC_SX679_.jpg", 13, 1 },
                    { 89, null, "/assets/seed/products/Generic_women_LongWomenCoatGray/71Tf1MgZAJL._AC_SY741_.jpg", "71Tf1MgZAJL._AC_SY741_.jpg", 13, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 90, null, "/assets/seed/products/Generic_women_WomensPlushFauxFurHoodedJacketBlackCroppedDesignZipUpFrontWinterCasualWear/310L1CYTxuL._AC_.jpg", true, "310L1CYTxuL._AC_.jpg", 15, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 91, null, "/assets/seed/products/Generic_women_WomensPlushFauxFurHoodedJacketBlackCroppedDesignZipUpFrontWinterCasualWear/31RQ-6P7lWL._AC_SX569_.jpg", "31RQ-6P7lWL._AC_SX569_.jpg", 15, 1 },
                    { 92, null, "/assets/seed/products/Generic_women_WomensPlushFauxFurHoodedJacketBlackCroppedDesignZipUpFrontWinterCasualWear/41ad9TXIBJL._AC_SY741_.jpg", "41ad9TXIBJL._AC_SY741_.jpg", 15, 1 },
                    { 93, null, "/assets/seed/products/Generic_women_WomensPlushFauxFurHoodedJacketBlackCroppedDesignZipUpFrontWinterCasualWear/51zV68b-ISL._AC_SY741_.jpg", "51zV68b-ISL._AC_SY741_.jpg", 15, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 94, null, "/assets/seed/products/Generic_women_WomensWideLegTrousersHighWaistPleated111TailoredFitSmartCasualFullLengthStraightCutWomensFashion/31zRDa68EJL._AC_.jpg", true, "31zRDa68EJL._AC_.jpg", 16, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[] { 95, null, "/assets/seed/products/Generic_women_WomensWideLegTrousersHighWaistPleated111TailoredFitSmartCasualFullLengthStraightCutWomensFashion/41JfCFjjDaL._AC_SY741_.jpg", "41JfCFjjDaL._AC_SY741_.jpg", 16, 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 96, null, "/assets/seed/products/JACKJONES_mens_JACKJONESMensMarcoSunnyChinoShorts/71YqESc2BqL._AC_SX569_.jpg", true, "71YqESc2BqL._AC_SX569_.jpg", 17, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[] { 97, null, "/assets/seed/products/JACKJONES_mens_JACKJONESMensMarcoSunnyChinoShorts/71oKHsfF-3L._AC_SX569_.jpg", "71oKHsfF-3L._AC_SX569_.jpg", 17, 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 98, null, "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIBabyGirlsHoodedCardiganandBootieBottomSet/61fKx6h3OEL._AC_SY741_.jpg", true, "61fKx6h3OEL._AC_SY741_.jpg", 18, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 99, null, "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIBabyGirlsHoodedCardiganandBootieBottomSet/61nL1Q9eFDL._AC_SY741_.jpg", "61nL1Q9eFDL._AC_SY741_.jpg", 18, 1 },
                    { 100, null, "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIBabyGirlsHoodedCardiganandBootieBottomSet/61p48jb9qAL._AC_SY741_.jpg", "61p48jb9qAL._AC_SY741_.jpg", 18, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 101, null, "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIEmbroideredBabyGirlsSet/41oaWVfmf5L._AC_SY741_.jpg", true, "41oaWVfmf5L._AC_SY741_.jpg", 19, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 102, null, "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIEmbroideredBabyGirlsSet/51LmMK8TGfL._AC_SY741_.jpg", "51LmMK8TGfL._AC_SY741_.jpg", 19, 1 },
                    { 103, null, "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIEmbroideredBabyGirlsSet/61VTz6tMvHL._AC_SY741_.jpg", "61VTz6tMvHL._AC_SY741_.jpg", 19, 1 },
                    { 104, null, "/assets/seed/products/LCWAIKIKI_kids-wear_LCWAIKIKIEmbroideredBabyGirlsSet/81DgYc28mcL._AC_SY741_.jpg", "81DgYc28mcL._AC_SY741_.jpg", 19, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 105, null, "/assets/seed/products/LaBEAUTE_women_AWideFitPOPLINShirtForWomenWith/31i5NOfxavL._AC_.jpg", true, "31i5NOfxavL._AC_.jpg", 20, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[] { 106, null, "/assets/seed/products/LaBEAUTE_women_AWideFitPOPLINShirtForWomenWith/51d1qu0K5mL._AC_SX679_.jpg", "51d1qu0K5mL._AC_SX679_.jpg", 20, 1 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 107, null, "/assets/seed/products/LevisMensCLASSICWESTERNSTANDARDWovenTops/816b+px-riL._AC_SX679_.jpg", true, "816b+px-riL._AC_SX679_.jpg", 21, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 108, null, "/assets/seed/products/LevisMensCLASSICWESTERNSTANDARDWovenTops/81YfIJ+CNeL._AC_SX679_.jpg", "81YfIJ+CNeL._AC_SX679_.jpg", 21, 1 },
                    { 109, null, "/assets/seed/products/LevisMensCLASSICWESTERNSTANDARDWovenTops/81dPG-5hOQL._AC_SX679_.jpg", "81dPG-5hOQL._AC_SX679_.jpg", 21, 1 },
                    { 110, null, "/assets/seed/products/LevisMensCLASSICWESTERNSTANDARDWovenTops/91CnONjElrL._AC_SX679_.jpg", "91CnONjElrL._AC_SX679_.jpg", 21, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 111, null, "/assets/seed/products/PUMA_mens_PUMAMensF1ESSLogoPolo180gBlackClassic/51T0ciE+XhL._AC_SX679_.jpg", true, "51T0ciE+XhL._AC_SX679_.jpg", 23, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 112, null, "/assets/seed/products/PUMA_mens_PUMAMensF1ESSLogoPolo180gBlackClassic/51oKwvsVsTL._AC_SX679_.jpg", "51oKwvsVsTL._AC_SX679_.jpg", 23, 1 },
                    { 113, null, "/assets/seed/products/PUMA_mens_PUMAMensF1ESSLogoPolo180gBlackClassic/51pQf4TcjYL._AC_SX679_.jpg", "51pQf4TcjYL._AC_SX679_.jpg", 23, 1 },
                    { 114, null, "/assets/seed/products/PUMA_mens_PUMAMensF1ESSLogoPolo180gBlackClassic/51ykfRDU6jL._AC_SX679_.jpg", "51ykfRDU6jL._AC_SX679_.jpg", 23, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 115, null, "/assets/seed/products/VisittheadidasStoreadidasMensEssentialsSmallLogoPiquéPoloShirtT-Shirt/71-hHXwye6L._AC_SX679_.jpg", true, "71-hHXwye6L._AC_SX679_.jpg", 24, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 116, null, "/assets/seed/products/VisittheadidasStoreadidasMensEssentialsSmallLogoPiquéPoloShirtT-Shirt/710jRKOOSuL._AC_SX679_.jpg", "710jRKOOSuL._AC_SX679_.jpg", 24, 1 },
                    { 117, null, "/assets/seed/products/VisittheadidasStoreadidasMensEssentialsSmallLogoPiquéPoloShirtT-Shirt/81nCNaeExPL._AC_SX679_.jpg", "81nCNaeExPL._AC_SX679_.jpg", 24, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 118, null, "/assets/seed/products/adidas_footwear_adidasCopaPure3LeagueFirmMultiGroundBootsunisexadultShoes/71BZTgWpGhL._AC_SY625_ (1).jpg", true, "71BZTgWpGhL._AC_SY625_ (1).jpg", 25, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 119, null, "/assets/seed/products/adidas_footwear_adidasCopaPure3LeagueFirmMultiGroundBootsunisexadultShoes/71BZTgWpGhL._AC_SY625_.jpg", "71BZTgWpGhL._AC_SY625_.jpg", 25, 1 },
                    { 120, null, "/assets/seed/products/adidas_footwear_adidasCopaPure3LeagueFirmMultiGroundBootsunisexadultShoes/71vvjUel52L._AC_SY625_.jpg", "71vvjUel52L._AC_SY625_.jpg", 25, 1 },
                    { 121, null, "/assets/seed/products/adidas_footwear_adidasCopaPure3LeagueFirmMultiGroundBootsunisexadultShoes/812LfWM33-L._AC_SY625_.jpg", "812LfWM33-L._AC_SY625_.jpg", 25, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 122, null, "/assets/seed/products/adidas_footwear_adidasUNISEXADULTRESPONSERUNNER2SHOES/51HJ3l10kJL._AC_SX625_.jpg", true, "51HJ3l10kJL._AC_SX625_.jpg", 26, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 123, null, "/assets/seed/products/adidas_footwear_adidasUNISEXADULTRESPONSERUNNER2SHOES/815FkWPHb9L._AC_SY625_.jpg", "815FkWPHb9L._AC_SY625_.jpg", 26, 1 },
                    { 124, null, "/assets/seed/products/adidas_footwear_adidasUNISEXADULTRESPONSERUNNER2SHOES/819HbjYgE8L._AC_SY625_.jpg", "819HbjYgE8L._AC_SY625_.jpg", 26, 1 },
                    { 125, null, "/assets/seed/products/adidas_footwear_adidasUNISEXADULTRESPONSERUNNER2SHOES/91h-sP1VFYL._AC_SY625_.jpg", "91h-sP1VFYL._AC_SY625_.jpg", 26, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 126, null, "/assets/seed/products/adidas_mens_adidasMens/414h8y8rQvL._AC_SY695_.jpg", true, "414h8y8rQvL._AC_SY695_.jpg", 27, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 127, null, "/assets/seed/products/adidas_mens_adidasMens/71KReCiVO-L._AC_SY625_.jpg", "71KReCiVO-L._AC_SY625_.jpg", 27, 1 },
                    { 128, null, "/assets/seed/products/adidas_mens_adidasMens/71YMW58eXeL._AC_SY625_.jpg", "71YMW58eXeL._AC_SY625_.jpg", 27, 1 },
                    { 129, null, "/assets/seed/products/adidas_mens_adidasMens/81Gm3ktsxIL._AC_SY625_.jpg", "81Gm3ktsxIL._AC_SY625_.jpg", 27, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 130, null, "/assets/seed/products/adidas_women_adidasWomensUltrarun5RunningShoes/71V4YxrFg8L._AC_SY625_.jpg", true, "71V4YxrFg8L._AC_SY625_.jpg", 28, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 131, null, "/assets/seed/products/adidas_women_adidasWomensUltrarun5RunningShoes/71qdcGuzEmL._AC_SY625_.jpg", "71qdcGuzEmL._AC_SY625_.jpg", 28, 1 },
                    { 132, null, "/assets/seed/products/adidas_women_adidasWomensUltrarun5RunningShoes/71rZIyBErmL._AC_SY695_.jpg", "71rZIyBErmL._AC_SY695_.jpg", 28, 1 },
                    { 133, null, "/assets/seed/products/adidas_women_adidasWomensUltrarun5RunningShoes/81rHwe5GmyL._AC_SY625_.jpg", "81rHwe5GmyL._AC_SY625_.jpg", 28, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 134, null, "/assets/seed/products/adidas_women_adidaswomensCOURTFUNKSneaker/51JWnAJ2fmL._AC_SY625_.jpg", true, "51JWnAJ2fmL._AC_SY625_.jpg", 29, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 135, null, "/assets/seed/products/adidas_women_adidaswomensCOURTFUNKSneaker/51oOMEiFRVL._AC_SY625_.jpg", "51oOMEiFRVL._AC_SY625_.jpg", 29, 1 },
                    { 136, null, "/assets/seed/products/adidas_women_adidaswomensCOURTFUNKSneaker/61ApGjmcR-L._AC_SY625_.jpg", "61ApGjmcR-L._AC_SY625_.jpg", 29, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 137, null, "/assets/seed/products/adidas_women_adidaswomensULTRADREAMDNASHOES/61H70Z36RCL._AC_SX625_.jpg", true, "61H70Z36RCL._AC_SX625_.jpg", 30, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 138, null, "/assets/seed/products/adidas_women_adidaswomensULTRADREAMDNASHOES/71+iCz5PyuL._AC_SX625_.jpg", "71+iCz5PyuL._AC_SX625_.jpg", 30, 1 },
                    { 139, null, "/assets/seed/products/adidas_women_adidaswomensULTRADREAMDNASHOES/71Q8K792gqL._AC_SX625_.jpg", "71Q8K792gqL._AC_SX625_.jpg", 30, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[] { 140, null, "/assets/seed/products/blackGraphicT-ShirtShortSleeveCrewNeckCasualTopforMenandWomen,StylishEverydayShirtforOutings,University,TravelandCasualWearBYHouseofBlack/61CB4aRY1OL._AC_SY741_.jpg", true, "61CB4aRY1OL._AC_SY741_.jpg", 31, 0 });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 141, null, "/assets/seed/products/blackGraphicT-ShirtShortSleeveCrewNeckCasualTopforMenandWomen,StylishEverydayShirtforOutings,University,TravelandCasualWearBYHouseofBlack/61LKWnqmE8L._AC_SY741_.jpg", "61LKWnqmE8L._AC_SY741_.jpg", 31, 1 },
                    { 142, null, "/assets/seed/products/blackGraphicT-ShirtShortSleeveCrewNeckCasualTopforMenandWomen,StylishEverydayShirtforOutings,University,TravelandCasualWearBYHouseofBlack/61RaJasKrJL._AC_SY741_.jpg", "61RaJasKrJL._AC_SY741_.jpg", 31, 1 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Caption", "FilePath", "IsDefault", "Name", "ProductId", "Type" },
                values: new object[,]
                {
                    { 143, null, "/assets/seed/products/kidstown_kids-wear_kidstownBoys2PieceSummerSetHighQualityCottonSizes2to5YearsModernDesignandUniqueColors/51TzrEe7lEL._AC_SX679_.jpg", true, "51TzrEe7lEL._AC_SX679_.jpg", 32, 0 },
                    { 144, null, "/assets/seed/products/71GjGE4DikL._AC_SY550_.jpg", true, "71GjGE4DikL._AC_SY550_.jpg", 14, 0 },
                    { 145, null, "/assets/seed/products/71wwFYwHetL._AC_SY550_.jpg", true, "71wwFYwHetL._AC_SY550_.jpg", 14, 0 },
                    { 146, null, "/assets/seed/products/W_OUTERWEAR_DENIM_JACKETS_29945-0265-1.png", true, "W_OUTERWEAR_DENIM_JACKETS_29945-0265-1.png", 22, 0 }
                });

            migrationBuilder.InsertData(
                table: "ProductColors",
                columns: new[] { "ColorsId", "ProductsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 5 },
                    { 1, 6 },
                    { 1, 7 },
                    { 1, 8 },
                    { 1, 9 },
                    { 1, 10 },
                    { 1, 11 },
                    { 1, 12 },
                    { 1, 13 },
                    { 1, 14 },
                    { 1, 15 },
                    { 1, 16 },
                    { 1, 17 },
                    { 1, 18 },
                    { 1, 19 },
                    { 1, 20 },
                    { 1, 21 },
                    { 1, 22 },
                    { 1, 23 },
                    { 1, 24 },
                    { 1, 25 },
                    { 1, 26 },
                    { 1, 27 },
                    { 1, 28 },
                    { 1, 29 },
                    { 1, 30 },
                    { 1, 31 },
                    { 1, 32 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 6 },
                    { 2, 7 },
                    { 2, 8 },
                    { 2, 9 },
                    { 2, 10 },
                    { 2, 11 },
                    { 2, 12 },
                    { 2, 13 },
                    { 2, 14 },
                    { 2, 15 },
                    { 2, 16 },
                    { 2, 17 },
                    { 2, 18 },
                    { 2, 19 },
                    { 2, 20 },
                    { 2, 21 },
                    { 2, 22 },
                    { 2, 23 },
                    { 2, 24 },
                    { 2, 25 },
                    { 2, 26 },
                    { 2, 27 },
                    { 2, 28 },
                    { 2, 29 },
                    { 2, 30 },
                    { 2, 31 },
                    { 2, 32 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 3, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 3, 12 },
                    { 3, 13 },
                    { 3, 14 },
                    { 3, 15 },
                    { 3, 16 },
                    { 3, 17 },
                    { 3, 18 },
                    { 3, 19 },
                    { 3, 20 },
                    { 3, 21 },
                    { 3, 22 },
                    { 3, 23 },
                    { 3, 24 },
                    { 3, 25 },
                    { 3, 26 },
                    { 3, 27 },
                    { 3, 28 },
                    { 3, 29 },
                    { 3, 30 },
                    { 3, 31 },
                    { 3, 32 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 5 },
                    { 4, 6 },
                    { 4, 7 },
                    { 4, 8 },
                    { 4, 9 },
                    { 4, 10 },
                    { 4, 11 },
                    { 4, 12 },
                    { 4, 13 },
                    { 4, 14 },
                    { 4, 15 },
                    { 4, 16 },
                    { 4, 17 },
                    { 4, 18 },
                    { 4, 19 },
                    { 4, 20 },
                    { 4, 21 },
                    { 4, 22 },
                    { 4, 23 },
                    { 4, 24 },
                    { 4, 25 },
                    { 4, 26 },
                    { 4, 27 },
                    { 4, 28 },
                    { 4, 29 },
                    { 4, 30 },
                    { 4, 31 },
                    { 4, 32 },
                    { 5, 2 },
                    { 5, 4 },
                    { 5, 6 },
                    { 5, 8 },
                    { 5, 10 },
                    { 5, 12 },
                    { 5, 14 },
                    { 5, 16 },
                    { 5, 18 },
                    { 5, 20 },
                    { 5, 22 },
                    { 5, 24 },
                    { 5, 26 },
                    { 5, 28 },
                    { 5, 30 },
                    { 5, 32 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 6, 5 },
                    { 6, 6 },
                    { 6, 7 },
                    { 6, 8 },
                    { 6, 9 },
                    { 6, 10 },
                    { 6, 11 },
                    { 6, 12 },
                    { 6, 13 },
                    { 6, 14 },
                    { 6, 15 },
                    { 6, 16 },
                    { 6, 17 },
                    { 6, 18 },
                    { 6, 19 },
                    { 6, 20 },
                    { 6, 21 },
                    { 6, 22 },
                    { 6, 23 },
                    { 6, 24 },
                    { 6, 25 },
                    { 6, 26 },
                    { 6, 27 },
                    { 6, 28 },
                    { 6, 29 },
                    { 6, 30 },
                    { 6, 31 },
                    { 6, 32 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 7, 5 },
                    { 7, 6 },
                    { 7, 7 },
                    { 7, 8 },
                    { 7, 9 },
                    { 7, 10 },
                    { 7, 11 },
                    { 7, 12 },
                    { 7, 13 },
                    { 7, 14 },
                    { 7, 15 },
                    { 7, 16 },
                    { 7, 17 },
                    { 7, 18 },
                    { 7, 19 },
                    { 7, 20 },
                    { 7, 21 },
                    { 7, 22 },
                    { 7, 23 },
                    { 7, 24 },
                    { 7, 25 },
                    { 7, 26 },
                    { 7, 27 },
                    { 7, 28 },
                    { 7, 29 },
                    { 7, 30 },
                    { 7, 31 },
                    { 7, 32 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 3 },
                    { 10, 4 },
                    { 10, 5 },
                    { 10, 6 },
                    { 10, 7 },
                    { 10, 8 },
                    { 10, 9 },
                    { 10, 10 },
                    { 10, 11 },
                    { 10, 12 },
                    { 10, 13 },
                    { 10, 14 },
                    { 10, 15 },
                    { 10, 16 },
                    { 10, 17 },
                    { 10, 18 },
                    { 10, 19 },
                    { 10, 20 },
                    { 10, 21 },
                    { 10, 22 },
                    { 10, 23 },
                    { 10, 24 },
                    { 10, 25 },
                    { 10, 26 },
                    { 10, 27 },
                    { 10, 28 },
                    { 10, 29 },
                    { 10, 30 },
                    { 10, 31 },
                    { 10, 32 },
                    { 11, 3 },
                    { 11, 6 },
                    { 11, 9 },
                    { 11, 12 },
                    { 11, 15 },
                    { 11, 18 },
                    { 11, 21 },
                    { 11, 24 },
                    { 11, 27 },
                    { 11, 30 },
                    { 12, 4 },
                    { 12, 8 },
                    { 12, 12 },
                    { 12, 16 },
                    { 12, 20 },
                    { 12, 24 },
                    { 12, 28 },
                    { 12, 32 },
                    { 13, 5 },
                    { 13, 10 },
                    { 13, 15 },
                    { 13, 20 },
                    { 13, 25 },
                    { 13, 30 }
                });

            migrationBuilder.InsertData(
                table: "ProductSizes",
                columns: new[] { "ProductsId", "SizesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 1, 6 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 6 },
                    { 2, 7 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 6 },
                    { 4, 1 },
                    { 4, 2 },
                    { 4, 3 },
                    { 4, 4 },
                    { 4, 6 },
                    { 4, 7 },
                    { 5, 1 },
                    { 5, 2 },
                    { 5, 3 },
                    { 5, 4 },
                    { 5, 6 },
                    { 6, 1 },
                    { 6, 2 },
                    { 6, 3 },
                    { 6, 4 },
                    { 6, 6 },
                    { 6, 7 },
                    { 7, 1 },
                    { 7, 2 },
                    { 7, 3 },
                    { 7, 4 },
                    { 7, 6 },
                    { 8, 1 },
                    { 8, 2 },
                    { 8, 3 },
                    { 8, 4 },
                    { 8, 6 },
                    { 8, 7 },
                    { 9, 1 },
                    { 9, 2 },
                    { 9, 3 },
                    { 9, 4 },
                    { 9, 6 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 3 },
                    { 10, 4 },
                    { 10, 6 },
                    { 10, 7 },
                    { 11, 1 },
                    { 11, 2 },
                    { 11, 3 },
                    { 11, 4 },
                    { 11, 6 },
                    { 12, 1 },
                    { 12, 2 },
                    { 12, 3 },
                    { 12, 4 },
                    { 12, 6 },
                    { 12, 7 },
                    { 13, 1 },
                    { 13, 2 },
                    { 13, 3 },
                    { 13, 4 },
                    { 13, 6 },
                    { 14, 1 },
                    { 14, 2 },
                    { 14, 3 },
                    { 14, 4 },
                    { 14, 6 },
                    { 14, 7 },
                    { 15, 1 },
                    { 15, 2 },
                    { 15, 3 },
                    { 15, 4 },
                    { 15, 6 },
                    { 16, 1 },
                    { 16, 2 },
                    { 16, 3 },
                    { 16, 4 },
                    { 16, 6 },
                    { 16, 7 },
                    { 17, 1 },
                    { 17, 2 },
                    { 17, 3 },
                    { 17, 4 },
                    { 17, 6 },
                    { 18, 1 },
                    { 18, 2 },
                    { 18, 3 },
                    { 18, 4 },
                    { 18, 6 },
                    { 18, 7 },
                    { 19, 1 },
                    { 19, 2 },
                    { 19, 3 },
                    { 19, 4 },
                    { 19, 6 },
                    { 20, 1 },
                    { 20, 2 },
                    { 20, 3 },
                    { 20, 4 },
                    { 20, 6 },
                    { 20, 7 },
                    { 21, 1 },
                    { 21, 2 },
                    { 21, 3 },
                    { 21, 4 },
                    { 21, 6 },
                    { 22, 1 },
                    { 22, 2 },
                    { 22, 3 },
                    { 22, 4 },
                    { 22, 6 },
                    { 22, 7 },
                    { 23, 1 },
                    { 23, 2 },
                    { 23, 3 },
                    { 23, 4 },
                    { 23, 6 },
                    { 24, 1 },
                    { 24, 2 },
                    { 24, 3 },
                    { 24, 4 },
                    { 24, 6 },
                    { 24, 7 },
                    { 25, 1 },
                    { 25, 2 },
                    { 25, 3 },
                    { 25, 4 },
                    { 25, 6 },
                    { 26, 1 },
                    { 26, 2 },
                    { 26, 3 },
                    { 26, 4 },
                    { 26, 6 },
                    { 26, 7 },
                    { 27, 1 },
                    { 27, 2 },
                    { 27, 3 },
                    { 27, 4 },
                    { 27, 6 },
                    { 28, 1 },
                    { 28, 2 },
                    { 28, 3 },
                    { 28, 4 },
                    { 28, 6 },
                    { 28, 7 },
                    { 29, 1 },
                    { 29, 2 },
                    { 29, 3 },
                    { 29, 4 },
                    { 29, 6 },
                    { 30, 1 },
                    { 30, 2 },
                    { 30, 3 },
                    { 30, 4 },
                    { 30, 6 },
                    { 30, 7 },
                    { 31, 1 },
                    { 31, 2 },
                    { 31, 3 },
                    { 31, 4 },
                    { 31, 6 },
                    { 32, 1 },
                    { 32, 2 },
                    { 32, 3 },
                    { 32, 4 },
                    { 32, 6 },
                    { 32, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_ImageId",
                table: "Brands",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId_ProductId_Size_Color",
                table: "CartItems",
                columns: new[] { "CartId", "ProductId", "Size", "Color" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CustomerId",
                table: "Carts",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ImageId",
                table: "Categories",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Slug",
                table: "Categories",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Colors_Name",
                table: "Colors",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_Code",
                table: "Coupons",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coupons_ExpiryDate",
                table: "Coupons",
                column: "ExpiryDate");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LName_FName",
                table: "Customers",
                columns: new[] { "LName", "FName" });

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProductId_IsDefault",
                table: "Images",
                columns: new[] { "ProductId", "IsDefault" });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AddressId",
                table: "Orders",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CouponId",
                table: "Orders",
                column: "CouponId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId_Status",
                table: "Orders",
                columns: new[] { "CustomerId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Number",
                table: "Orders",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductColors_ProductsId",
                table: "ProductColors",
                column: "ProductsId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId_IsActive",
                table: "Products",
                columns: new[] { "CategoryId", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsBestseller_IsActive",
                table: "Products",
                columns: new[] { "IsBestseller", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsFeatured_IsActive",
                table: "Products",
                columns: new[] { "IsFeatured", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_IsOnSale_IsActive",
                table: "Products",
                columns: new[] { "IsOnSale", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSizes_SizesId",
                table: "ProductSizes",
                column: "SizesId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_CustomerId_ProductId",
                table: "Reviews",
                columns: new[] { "CustomerId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ProductId_IsApproved",
                table: "Reviews",
                columns: new[] { "ProductId", "IsApproved" });

            migrationBuilder.CreateIndex(
                name: "IX_Sizes_Name",
                table: "Sizes",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Images_ImageId",
                table: "AspNetUsers",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Images_ImageId",
                table: "Brands",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_ProductId",
                table: "CartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Images_ImageId",
                table: "Categories",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Images_ImageId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Images_ImageId",
                table: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "ProductColors");

            migrationBuilder.DropTable(
                name: "ProductSizes");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Coupons");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
