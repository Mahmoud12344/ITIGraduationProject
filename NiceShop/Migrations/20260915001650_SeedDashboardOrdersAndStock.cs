using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NiceShop.Migrations
{
    /// <inheritdoc />
    public partial class SeedDashboardOrdersAndStock : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "Discount", "Price" },
                values: new object[] { 250.00m, 1250.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discount", "Price" },
                values: new object[] { 150.00m, 850.00m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 550.00m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 450.00m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Stock",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Stock",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Stock",
                value: 1);

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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discount", "Price" },
                values: new object[] { 20.62m, 103.12m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discount", "Price" },
                values: new object[] { 4.82m, 24.12m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Price",
                value: 96.59m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "Price",
                value: 32.05m);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "Stock",
                value: 100);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                column: "Stock",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                column: "Stock",
                value: 50);
        }
    }
}
