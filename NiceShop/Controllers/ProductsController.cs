using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;

namespace NiceShop.Controllers;

public class ProductsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Details(string id)
    {
        return View();
    }

    // GET: Products/Categories
    public async Task<IActionResult> Categories()
    {
        var categories = await _context.Categories.ToListAsync();
        return View(categories);
    }

    // GET: Products/ByCategory/5
    public async Task<IActionResult> ByCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category == null)
        {
            return NotFound();
        }

        ViewBag.CategoryName = category.Name;

        var products = await _context.Products
            .Where(p => p.CategoryId == id && p.IsActive)
            .ToListAsync();

        return View(products);
    }
}