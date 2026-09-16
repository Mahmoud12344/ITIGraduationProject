using Microsoft.AspNetCore.Mvc;

namespace NiceShop.Controllers;

public class WishlistController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
