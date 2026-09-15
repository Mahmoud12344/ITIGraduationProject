using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;
using NiceShop.ViewModels.Admin;

namespace NiceShop.services;

public class DashboardService(ApplicationDbContext context) {
    
    public async Task<int> GetNumberOfSalesTodayAsync() =>
        await context.Orders
            .Where(o => o.Status == OrderStatus.Confirmed &&
                        o.OrderDate == DateTime.Today
            ).CountAsync();

    public async Task<decimal> GetSumOfSalesTodayAsync() =>
        await context.Orders
            .Where(o => o.Status == OrderStatus.Confirmed &&
                        o.OrderDate == DateTime.Today
            ).SumAsync(o => o.Subtotal);

    public async Task<int> GetNumberOfSalesThisMonthAsync() =>
        await context.Orders
            .Where(o => o.Status == OrderStatus.Confirmed &&
                        o.OrderDate.Month == DateTime.Now.Date.Month
            ).CountAsync();
  
   
    public async Task<decimal> GetSumOfSalesThisMonthAsync() =>
        await context.Orders
            .Where(o => o.Status == OrderStatus.Confirmed &&
                        o.OrderDate.Month == DateTime.Now.Date.Month
            ).SumAsync(o => o.Subtotal);
    
    public async Task<int> GetNumberOfSalesAllTimeAsync() =>
        await context.Orders
            .Where(o => o.Status == OrderStatus.Confirmed  
            ).CountAsync();
  
    public async Task<decimal> GetSumOfSalesAllTimeAsync() =>
        await context.Orders
            .Where(o => o.Status == OrderStatus.Confirmed 
            ).SumAsync(o => o.Subtotal);

    
    public async Task<List<Order>> GetPendingOrdersAsync() =>
        await context.Orders
            .Where(o => o.Status == OrderStatus.Pending)
            .ToListAsync();
    
    public async Task<int> GetNumberPendingOrdersAsync() =>
        await context.Orders.CountAsync(o => o.Status == OrderStatus.Pending);

  

    private int count = 5;
    public async Task <List<DashboardVm.TopSellingProductDto>> GetTopSellingProductsAsync ()=>
    await context.OrderItems
        .GroupBy(oi => oi.ProductId)
        .Select(g => new
        {
            ProductId = g.Key,
            TotalSold = g.Sum(oi => oi.Quantity),
            TotalRevenue = g.Sum(oi => oi.Quantity * oi.Price)
        })
        .OrderByDescending(x=>x.TotalRevenue)
        .Take(count)
        .Join(context.Products.Include(p => p.Images),
            top => top.ProductId,
            p => p.Id,
            (top, p) => new DashboardVm.TopSellingProductDto { Product = p, TotalSold = top.TotalSold, TotalRevenue = top.TotalRevenue })
        .ToListAsync();


    public async Task<List<Order>> GetRecentOrdersAsync() =>
        await context.Orders
            .Where(o => o.OrderDate > (DateTime.Today.AddDays(-3)))
            .ToListAsync();


    public async Task<int> GetTotalNumberOfCustomersAsync() =>
        await context.Customers.CountAsync();

    public async Task<int> GetTotalNumberProductsAsync() =>
        await context.Products.CountAsync();

    
    private const int lowStock = 5;
    public async Task<List<Product>> GetLowStockProductsAsync() =>
        await context.Products.Include(p => p.Images).Where(p => p.Stock <= lowStock&& p.Stock>=1).ToListAsync() ;

    public async Task<int> GetNumberOfLowStockProductsAsync() =>
         await context.Products.CountAsync(p => p.Stock <= lowStock&& p.Stock>=1);
    


    public async Task<List<Product>> GetOutOfStockProductsAsync() =>
        await context.Products.Include(p => p.Images).Where(p => p.Stock == 0).ToListAsync();


    public async Task<int> GetNumberOfOutOfStockProductsAsync() =>
        await context.Products.CountAsync(p => p.Stock == 0);



}