using NiceShop.Models;

namespace NiceShop.ViewModels.Admin;

public class DashboardVm {

 public int NumberOfSalesToday{ get; set; }
 public decimal SumOfSalesToday{ get; set; }
 
 public int NumberOfSalesThisMonth{ get; set; }
 public decimal SumSalesThisMonth{ get; set; }
 
 public int NumberOfSalesAllTime{ get; set; }
 public decimal SumOfSalesAllTime{ get; set; }

 public int NumberPendingOrders{ get; set; }
 public List<Order>  PendingOrders{ get; set; }= new ();
 
 public class TopSellingProductDto {
     public Product Product { get; set; }
     public int TotalSold { get; set; }
     public decimal TotalRevenue { get; set; }
 }
 
 // take the best 5 selling products 
 public List<TopSellingProductDto> TopSellingProducts { get; set; } = new ();
 // done done on a period of  3 days 
 public List<Order> RecentOrders{ get; set; } = new ();
 
 public int TotalNumberOfCustomers{ get; set; }
 
 public int TotalNumberProducts{ get; set; }
 
 // less than 5 products 
 public int  NumberOfLowStockProducts { get; set; }
 public List<Product> LowStockProducts{ get; set; } = new();
 
 public int  NumberOFOutOfStockProducts{ get; set; } 
 public List<Product> OutOfStockProducts{ get; set; } = new();
 
}