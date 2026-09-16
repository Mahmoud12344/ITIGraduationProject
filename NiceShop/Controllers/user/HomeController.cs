using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;

namespace NiceShop.Controllers;

public class HomeController : Controller
{

    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.FeaturedProducts = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p=>p.Images)
            .Where(p => p.IsFeatured && p.IsActive)
            .Take(4)
            .ToListAsync();

        var categories = await _context.Categories.Include(c=>c.Image).Include(c=>c.Products).ToArrayAsync();

        ViewBag.SpecialCoupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Id == 1);

        return View(categories);
    }


    [HttpGet]
public async Task<IActionResult> GetFilteredProducts(string filter)
{
    var query = _context.Products
        .Include(p => p.Brand)
        .Include(p => p.Images)
        .Where(p => p.IsActive);
    switch (filter?.ToLower())
    {
        case "new":
            query = query.OrderByDescending(p => p.CreatedAt);
            break;
        case "bestsellers":
            query = query.Where(p => p.IsBestseller);
            break;
        case "sale":
            query = query.Where(p => p.IsOnSale);
            break;
        case "trending":
        default:
            query = query.Where(p => p.IsFeatured);
            break;
    }
    var products = await query.Take(4).ToListAsync();
    return PartialView("Partials/_ProductGrid", products);
}

    public IActionResult Index2()
    {
        throw new Exception();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}