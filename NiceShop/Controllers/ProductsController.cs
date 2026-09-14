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

    // GET: Products (Shop All)
    public async Task<IActionResult> Index()
    {
        var products = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p=>p.Images)
            .Include(p=>p.Colors)
            .Where(p => p.IsActive)
            .ToListAsync();

        ViewBag.Categories = await _context.Categories.ToListAsync();
        ViewBag.Brands = await _context.Brands.ToListAsync();

        return View(products);
    }

    // GET: Products/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.Images)
            .Include(p => p.Colors)
            .Include(p => p.Sizes)
            .Include(p => p.Reviews)
                .ThenInclude(r => r.Customer)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        var relatedProducts = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .Include(p => p.Images)
            .Where(p => p.CategoryId == product.CategoryId && p.Id != id && p.IsActive)
            .Take(4)
            .ToListAsync();

        ViewBag.RelatedProducts = relatedProducts;

        return View(product);
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
            .Include(p => p.Images)
            .Where(p => p.CategoryId == id && p.IsActive)
            .ToListAsync();

        return View(products);
    }
}