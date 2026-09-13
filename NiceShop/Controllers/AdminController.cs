using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;
using NiceShop.ViewModels;

namespace NiceShop.Controllers;
[Authorize (Roles = "Admin")]
public class AdminController(ApplicationDbContext dbContext ) : Controller
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
    // public IActionResult Coupons() {
    //     var cvm = new CouponVm() {
    //         Coupons = dbContext.Coupons.ToList() 
    //     };
    //     
    //     return View(cvm);
    // }

}
