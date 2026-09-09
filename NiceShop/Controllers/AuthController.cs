using Microsoft.AspNetCore.Mvc;

namespace NiceShop.Controllers;

public class AuthController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
