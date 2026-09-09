using Microsoft.AspNetCore.Mvc;

namespace NiceShop.Controllers;

public class CartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
