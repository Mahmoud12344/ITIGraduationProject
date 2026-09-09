using Microsoft.AspNetCore.Mvc;

namespace NiceShop.Controllers;

public class OrdersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Invoice(string id)
    {
        return View();
    }
}
