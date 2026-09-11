using System.Drawing;
using Microsoft.EntityFrameworkCore;
using NiceShop.Models;
using Color = NiceShop.Models.Color;
using Size = NiceShop.Models.Size;

namespace NiceShop.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Address> Addresses => Set<Address>();
    public DbSet<Coupon> Coupons => Set<Coupon>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();
    public DbSet<Review> Reviews => Set<Review>();
    public DbSet<Cart> Carts => Set<Cart>();
    public DbSet<CartItem> CartItems => Set<CartItem>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Image> Images => Set<Image>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Color> Colors => Set<Color>();
    public DbSet<Size> Sizes => Set<Size>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // sets decimal precision for all money related fields so ef stops warning us
        builder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
        builder.Entity<Coupon>().Property(c => c.Percentage).HasPrecision(18, 2);
        builder.Entity<Order>().Property(o => o.Subtotal).HasPrecision(18, 2);
        builder.Entity<Order>().Property(o => o.ShippingCost).HasPrecision(18, 2);
        builder.Entity<Order>().Property(o => o.Total).HasPrecision(18, 2);
        builder.Entity<OrderItem>().Property(oi => oi.Price).HasPrecision(18, 2);
     // customer AppUsr fk
        builder.Entity<Customer>()
            .HasOne(c => c.ApplicationUser)
            .WithOne(u => u.Customer)
            .HasForeignKey<Customer>(c => c.Id);
        
        ConfigureApplicationUser(builder);
        ConfigureCustomer(builder);
        ConfigureAddress(builder);
        ConfigureCoupon(builder);
        ConfigureOrder(builder);
        ConfigureOrderItem(builder);
        ConfigureReview(builder);
        ConfigureCart(builder);
        ConfigureCartItem(builder);
        ConfigureBrand(builder);
        ConfigureCategory(builder);
        ConfigureImage(builder);
        ConfigureProduct(builder);
        ConfigureColor(builder);
        ConfigureSize(builder);
        
        
    }
    
    private static void ConfigureApplicationUser(ModelBuilder builder)
    {
        builder.Entity<ApplicationUser>()
            .HasOne(u => u.Image)
            .WithMany()
            .HasForeignKey(u => u.ImageId)
            .OnDelete(DeleteBehavior.SetNull);
    }
    
    
    
    private static void ConfigureCustomer(ModelBuilder builder)
    {
        builder.Entity<Customer>(e =>
        {
            e.Property(c => c.Id).ValueGeneratedNever(); // shared PK with ApplicationUser
            e.Property(c => c.FName).IsRequired().HasMaxLength(50);
            e.Property(c => c.LName).IsRequired().HasMaxLength(50);

            e.HasOne(c => c.ApplicationUser)
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(c => c.Id);

            e.HasOne(c => c.Cart)
                .WithOne(cart => cart.Customer)
                .HasForeignKey<Cart>(cart => cart.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasMany(c => c.Orders)
                .WithOne(o => o.Customer)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasMany(c => c.Reviews)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            // full name search (e.g. admin customer lookup)
            e.HasIndex(c => new { c.LName, c.FName });
        });
    }
    
    private static void ConfigureAddress(ModelBuilder builder)
    {
        builder.Entity<Address>(e =>
        {
            e.Property(a => a.Government).IsRequired().HasMaxLength(100);
            e.Property(a => a.City).IsRequired().HasMaxLength(100);
            e.Property(a => a.Street).IsRequired().HasMaxLength(150);
            e.Property(a => a.Building).IsRequired().HasMaxLength(50);
            e.Property(a => a.ZipCode).HasMaxLength(20);
            e.Property(a => a.IsDefault).HasDefaultValue(false);
            // AddressType kept as int (default) — no conversion needed
        });
    }
    
    private static void ConfigureCoupon(ModelBuilder builder)
    {
        builder.Entity<Coupon>(e =>
        {
            e.Property(c => c.Code).IsRequired().HasMaxLength(30);
            e.Property(c => c.Percentage).HasPrecision(5, 2);

            e.HasIndex(c => c.Code).IsUnique();
            e.HasIndex(c => c.ExpiryDate); // speeds up "active coupons" queries

            e.ToTable(t => t.HasCheckConstraint("CK_Coupon_Percentage", "[Percentage] >= 0 AND [Percentage] <= 100"));
        });
    }
    
    private static void ConfigureOrder(ModelBuilder builder)
    {
        builder.Entity<Order>(e =>
        {
            e.Property(o => o.Number).IsRequired().HasMaxLength(30);
            e.Property(o => o.Notes).HasMaxLength(500);
            e.Property(o => o.CancellationReason).HasMaxLength(300);
            e.Property(o => o.Total).HasPrecision(18, 2);
            e.Property(o => o.Subtotal).HasPrecision(18, 2);
            e.Property(o => o.IsCanceled).HasDefaultValue(false);
            e.Property(o => o.Status).HasDefaultValue(OrderStatus.Pending); // stored as int

            e.HasMany(o => o.OrderItems)
                .WithOne(oi => oi.Order)
                .HasForeignKey(oi => oi.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(o => o.Coupon)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CouponId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasOne(o => o.Address)
                .WithMany(a => a.Orders)
                .HasForeignKey(o => o.AddressId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasIndex(o => o.Number).IsUnique();
            e.HasIndex(o => new { o.CustomerId, o.Status }); // order history / "my pending orders" queries

            e.ToTable(t => t.HasCheckConstraint("CK_Order_Total", "[Total] >= 0"));
        });
    }
    
    private static void ConfigureOrderItem(ModelBuilder builder)
    {
        builder.Entity<OrderItem>(e =>
        {
            e.Property(oi => oi.Price).HasPrecision(18, 2);
            e.Property(oi => oi.Name).IsRequired().HasMaxLength(150);
            e.Property(oi => oi.Color).IsRequired().HasMaxLength(30);
            // Size kept as int (default) — snapshot value at time of purchase

            e.HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // never cascade-delete order history

            e.ToTable(t =>
            {
                t.HasCheckConstraint("CK_OrderItem_Quantity", "[Quantity] > 0");
                t.HasCheckConstraint("CK_OrderItem_Price", "[Price] >= 0");
            });
        });
    }
    private static void ConfigureReview(ModelBuilder builder)
    {
        builder.Entity<Review>(e =>
        {
            e.Property(r => r.Content).IsRequired().HasMaxLength(1000);
            e.Property(r => r.IsApproved).HasDefaultValue(false);
            e.Property(r => r.IsVerifiedUser).HasDefaultValue(false);
            e.Property(r => r.Date).HasDefaultValueSql("GETUTCDATE()");

            e.HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasIndex(r => new { r.CustomerId, r.ProductId }).IsUnique(); // 1 review per customer per product
            e.HasIndex(r => new { r.ProductId, r.IsApproved }); // "show approved reviews for product X"

            e.ToTable(t => t.HasCheckConstraint("CK_Review_Rating", "[Rating] >= 1 AND [Rating] <= 5"));
        });
    }
    private static void ConfigureCart(ModelBuilder builder)
    {
        builder.Entity<Cart>(e =>
        {
            e.Property(c => c.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            e.Property(c => c.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");
        });
    }
    private static void ConfigureCartItem(ModelBuilder builder)
    {
        builder.Entity<CartItem>(e =>
        {
            e.Property(ci => ci.Size).IsRequired().HasMaxLength(20);
            e.Property(ci => ci.Color).IsRequired().HasMaxLength(30);

            e.HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            // same product+variant can't appear twice in one cart — update qty instead
            e.HasIndex(ci => new { ci.CartId, ci.ProductId, ci.Size, ci.Color }).IsUnique();

            e.ToTable(t => t.HasCheckConstraint("CK_CartItem_Quantity", "[Quantity] > 0"));
        });
    }
    private static void ConfigureBrand(ModelBuilder builder)
    {
        builder.Entity<Brand>(e =>
        {
            e.Property(b => b.Name).IsRequired().HasMaxLength(100);
            e.Property(b => b.Country).HasMaxLength(60);
            e.Property(b => b.ProductCount).HasDefaultValue(0); // maintained by app logic, not user input

            e.HasOne(b => b.Image)
                .WithMany()
                .HasForeignKey(b => b.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

            e.HasMany(b => b.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandId)
                .OnDelete(DeleteBehavior.SetNull);

            e.HasIndex(b => b.Name).IsUnique();
        });
    }
    private static void ConfigureCategory(ModelBuilder builder)
    {
        builder.Entity<Category>(e =>
        {
            e.Property(c => c.Name).IsRequired().HasMaxLength(100);
            e.Property(c => c.Slug).IsRequired().HasMaxLength(120);

            e.HasOne(c => c.Image)
                .WithMany()
                .HasForeignKey(c => c.ImageId)
                .OnDelete(DeleteBehavior.SetNull);

            e.HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            e.HasIndex(c => c.Name).IsUnique();
            e.HasIndex(c => c.Slug).IsUnique(); // used for SEO-friendly URLs, must be unique
        });
    }
    private static void ConfigureImage(ModelBuilder builder)
    {
        builder.Entity<Image>(e =>
        {
            e.Property(i => i.Name).IsRequired().HasMaxLength(150);
            e.Property(i => i.Caption).HasMaxLength(300);
            e.Property(i => i.FilePath).IsRequired().HasMaxLength(300);
            e.Property(i => i.IsDefault).HasDefaultValue(false);
            // Type kept as int (default)

            e.HasOne(i => i.Product)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasIndex(i => new { i.ProductId, i.IsDefault }); // quickly fetch a product's default thumbnail
        });
    }

    private static void ConfigureProduct(ModelBuilder builder)
    {
        builder.Entity<Product>(e =>
        {
            e.Property(p => p.Name).IsRequired().HasMaxLength(150);
            e.Property(p => p.Price).HasPrecision(18, 2);
            e.Property(p => p.Discount).HasPrecision(18, 2);
            e.Property(p => p.Description).HasMaxLength(2000);
            e.Property(p => p.Rating).HasPrecision(3, 2).HasDefaultValue(0); // avg of Reviews, e.g. 4.75
            e.Property(p => p.ReviewCount).HasDefaultValue(0);
            e.Property(p => p.Stock).HasDefaultValue(0);
            e.Property(p => p.IsActive).HasDefaultValue(true);
            e.Property(p => p.IsFeatured).HasDefaultValue(false);
            e.Property(p => p.IsBestseller).HasDefaultValue(false);
            e.Property(p => p.IsOnSale).HasDefaultValue(false);
            e.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            e.Property(p => p.UpdatedAt).HasDefaultValueSql("GETUTCDATE()");

            e.HasMany(p => p.Colors)
                .WithMany(c => c.Products)
                .UsingEntity(j => j.ToTable("ProductColors"));

            e.HasMany(p => p.Sizes )
                .WithMany(s => s.Products)
                .UsingEntity(j => j.ToTable("ProductSizes"));

            // storefront filter/listing queries — Category/Brand FKs are auto-indexed by EF,
            // these composite ones target the actual query patterns (active items per section)
            e.HasIndex(p => new { p.CategoryId, p.IsActive });
            e.HasIndex(p => new { p.IsFeatured, p.IsActive });
            e.HasIndex(p => new { p.IsBestseller, p.IsActive });
            e.HasIndex(p => new { p.IsOnSale, p.IsActive });
            e.HasIndex(p => p.Name); // simple search-by-name support

            e.ToTable(t =>
            {
                t.HasCheckConstraint("CK_Product_Price", "[Price] >= 0");
                t.HasCheckConstraint("CK_Product_Stock", "[Stock] >= 0");
                t.HasCheckConstraint("CK_Product_Rating", "[Rating] >= 0 AND [Rating] <= 5");
            });
        });
    }
    private static void ConfigureColor(ModelBuilder builder)
    {
        builder.Entity<Color>(e =>
        {
            e.Property(c => c.Name).IsRequired().HasMaxLength(50);
            e.Property(c => c.HexCode).IsRequired().HasMaxLength(7); // "#FFFFFF"

            e.HasIndex(c => c.Name).IsUnique();
        });
    }
    private static void ConfigureSize(ModelBuilder builder)
    {
        builder.Entity<Size>(e =>
        {
            e.Property(s => s.Name).IsRequired().HasMaxLength(20);
            e.Property(s => s.Code).HasMaxLength(10);

            e.HasIndex(s => s.Name).IsUnique();
        });
    }
    
}
