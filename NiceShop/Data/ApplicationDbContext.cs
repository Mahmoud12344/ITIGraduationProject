using Microsoft.EntityFrameworkCore;
using NiceShop.Models;

namespace NiceShop.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
    }

    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartItem> CartItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Coupon> Coupons { get; set; } // it will be removed when dev3 create his own
    public DbSet<Product> Products { get; set; } // it will be removed when dev1 create his own


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // sets decimal precision for all money related fields so ef stops warning us
        modelBuilder.Entity<Product>().Property(p => p.Price).HasPrecision(18, 2);
        modelBuilder.Entity<Coupon>().Property(c => c.Percentage).HasPrecision(18, 2);
        modelBuilder.Entity<Order>().Property(o => o.Subtotal).HasPrecision(18, 2);
        modelBuilder.Entity<Order>().Property(o => o.ShippingCost).HasPrecision(18, 2);
        modelBuilder.Entity<Order>().Property(o => o.Total).HasPrecision(18, 2);
        modelBuilder.Entity<OrderItem>().Property(oi => oi.Price).HasPrecision(18, 2);
    }
}
