using Microsoft.AspNetCore.Mvc;

namespace NiceShop.Controllers;

public class AdminController : Controller
{
    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Products()
    {
        return View();
    }

    public IActionResult AddProduct()
    {
        return View();
    }

    public IActionResult Orders()
    {
        return View();
    }

    public IActionResult Reviews()
    {
        return View();
    }

    public IActionResult CategoriesCoupons()
    {
        return View();
    }
}
