using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;

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
            .Where(p => p.IsActive)
            .ToListAsync();

        ViewBag.Categories = await _context.Categories.ToListAsync();
        ViewBag.Brands = await _context.Brands.ToListAsync();

        return View(products);
    }

public async Task<IActionResult> Details(int? id)
{
    if(id == null) return NotFound();

    var product = await _context.Products
        .Include(p => p.Images)
        .Include(p => p.Brand)
        .Include(p => p.Sizes)
        .Include(p => p.Colors)
        .Include(p => p.Category)
        .FirstOrDefaultAsync(p => p.Id == id);

    if(product == null) return NotFound();

    ViewBag.RelatedProducts = await _context.Products
        .Include(p => p.Images)
        .Include(p => p.Brand)
        .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id && p.IsActive)
        .Take(4)
        .ToListAsync();

    return View(product);
}

    //quick review

    public async Task<IActionResult> QuickReview(int id)
    {
        var product = await _context.Products.Include(p=>p.Brand).Include(p=>p.Category)
        .Include(p=>p.Colors).Include(p=>p.Sizes)
        .Include(p=>p.Images).FirstOrDefaultAsync(p=>p.Id == id);

        if(product == null)
        {
            return NotFound();
        }
        return PartialView("Partials/_QuickViewModal", product);
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

        var products = await _context.Products.Include(p=>p.Images)
            .Where(p => p.CategoryId == id && p.IsActive)
            .ToListAsync();

        return View(products);
    }
}