using Microsoft.AspNetCore.Mvc;

namespace NiceShop.Controllers;

public class DashboardController : Controller {
    // GET
    public IActionResult Index() {
        return View();
    }
}