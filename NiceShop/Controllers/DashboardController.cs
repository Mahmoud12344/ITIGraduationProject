using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.services;
using NiceShop.ViewModels.Admin;

namespace NiceShop.Controllers;
[Authorize(Roles = "Admin") ]
public class DashboardController(DashboardService dashboardService) : Controller {
    private DashboardService _dashboardService = dashboardService;

    // GET
    public async Task<IActionResult> Dashboard() {
        var vm = new DashboardVm() {
            NumberOfSalesToday = await _dashboardService.GetNumberOfSalesTodayAsync(),
            SumOfSalesToday = await _dashboardService.GetSumOfSalesTodayAsync(),
            NumberOfSalesThisMonth = await _dashboardService.GetNumberOfSalesThisMonthAsync(),
            SumSalesThisMonth = await _dashboardService.GetSumOfSalesThisMonthAsync(),
            NumberOfSalesAllTime = await _dashboardService.GetNumberOfSalesAllTimeAsync(),
            SumOfSalesAllTime = await _dashboardService.GetSumOfSalesAllTimeAsync(),
            NumberPendingOrders = await _dashboardService.GetNumberPendingOrdersAsync(),
            PendingOrders = await _dashboardService.GetPendingOrdersAsync(),
            TopSellingProducts = await _dashboardService.GetTopSellingProductsAsync(),
            RecentOrders = await _dashboardService.GetRecentOrdersAsync(),
            TotalNumberOfCustomers = await _dashboardService.GetTotalNumberOfCustomersAsync(),
            TotalNumberProducts = await _dashboardService.GetTotalNumberProductsAsync(),
            NumberOfLowStockProducts = await _dashboardService.GetNumberOfLowStockProductsAsync(),
            LowStockProducts = await _dashboardService.GetLowStockProductsAsync(),
            NumberOFOutOfStockProducts = await _dashboardService.GetNumberOfOutOfStockProductsAsync(),
            OutOfStockProducts = await _dashboardService.GetOutOfStockProductsAsync()
        };

        return View(vm);
    }
}