using Microsoft.AspNetCore.Mvc;

namespace NiceShop.Controllers;

public class CheckoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
