using Microsoft.AspNetCore.Mvc;
using NiceShop.Models;
using NiceShop.services;
using NiceShop.ViewModels.Admin;

namespace NiceShop.Controllers;

public class OrdersController(OrdersService service) : Controller
{
    private readonly OrdersService _ordersService = service;
    
   public async Task<IActionResult> Orders([FromQuery] OrdersVm.OrderFilterVm filter)
    {
        var ordersList = await _ordersService.GetOrdersAsync(filter);

        var vm = new OrdersVm
        {
            Orders = ordersList, 
            Filter = filter     
        };

        return View("~/Views/Admin/Orders.cshtml", vm);
    }

    public async Task<IActionResult> OrderDetails(int? Id)
    {
        if(Id == null) return NotFound();
       var vm = await service.GetOrderDetailsAsync(Id);
       return View(vm);
    }

    public async Task<IActionResult> UpdateStatus(int Id, OrderStatus status)
    {
        bool result = await service.UpdateOrderStatusAsync(Id, status);
        if(result) TempData["SuccessMessage"] = $"Order status successfully updated to {status}.";
        else TempData["ErrorMessage"] = "Failed to update status. Transition invalid or order not found.";

        //get current page url
        string referer = Request.Headers.Referer.ToString();

        if (!string.IsNullOrEmpty(referer))
        {
            return Redirect(referer);
        }

        return RedirectToAction(nameof(Orders));
    }

    public IActionResult Invoice(string id)
    {
        return View();
    }
}
