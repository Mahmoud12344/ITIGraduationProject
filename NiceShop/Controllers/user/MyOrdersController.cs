using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Services;

namespace NiceShop.Controllers;

[Authorize]
public class MyOrdersController(MyOrdersService service) : Controller
{
    private string CustomerId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    public async Task<IActionResult> Index()
    {
        var orders = await service.GetMyOrdersAsync(CustomerId);
        return View(orders);
    }

    public async Task<IActionResult> Details(int id)
    {
        var order = await service.GetMyOrderDetailsAsync(id, CustomerId);

        // not found, or belongs to someone else, either way just 404, dont hint which one
        if (order == null) return NotFound();

        return View(order);
    }

    public IActionResult Track()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Track(string orderNumber)
    {
        if (string.IsNullOrWhiteSpace(orderNumber))
        {
            TempData["TrackError"] = "please type an order number";
            return RedirectToAction("Track");
        }

        var orderId = await service.FindMyOrderIdByNumberAsync(orderNumber.Trim(), CustomerId);

        if (orderId == null)
        {
            TempData["TrackError"] = "no order found with this number on your account";
            return RedirectToAction("Track");
        }

        return RedirectToAction("Details", new { id = orderId });
    }
}