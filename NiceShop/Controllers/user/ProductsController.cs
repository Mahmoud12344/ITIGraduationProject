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
            .Include(p => p.Images)
            .Include(p => p.Colors)
            .Where(p => p.IsActive)
            .ToListAsync();

        ViewBag.Categories = await _context.Categories.ToListAsync();
        ViewBag.Brands = await _context.Brands.ToListAsync();

        return View(products);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();

        var product = await _context.Products
            .Include(p => p.Images)
            .Include(p => p.Brand)
            .Include(p => p.Sizes)
            .Include(p => p.Colors)
            .Include(p => p.Category)
            .Include(p => p.Reviews)
                .ThenInclude(r => r.Customer)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product == null) return NotFound();

        ViewBag.RelatedProducts = await _context.Products
            .Include(p => p.Images)
            .Include(p => p.Brand)
            .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id && p.IsActive)
            .Take(4)
            .ToListAsync();

        return View(product);
    }

    // POST: Products/AddReview
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddReview(int ProductId, int Rating, string Content)
    {
        if (!User.Identity?.IsAuthenticated ?? true)
        {
            return Challenge();
        }

        if (Rating < 1 || Rating > 5){
            TempData["ReviewError"] = " please choose  rate the product from 1 to 5 starts ";
            return RedirectToAction(nameof(Details), new { id = ProductId });
        }

        if (string.IsNullOrWhiteSpace(Content))
        {
            TempData["ReviewError"] = "please enter the review contetent ";
            return RedirectToAction(nameof(Details), new { id = ProductId });
        }

        var product = await _context.Products.FindAsync(ProductId);
        if (product == null) return NotFound();

        var customerId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        if (customerId == null) return Challenge();

        var review = new Review
        {
            ProductId = ProductId,
            CustomerId = customerId,
            Rating = Rating,
            Content = Content.Trim(),
            Date = DateTime.UtcNow,
            IsApproved = true,          // يفضل تحت المراجعة لحد ما الأدمن يوافق
            IsVerifiedUser = false       // أو تتحدد حسب لو الكستمر اشترى المنتج فعلاً
        };

        _context.Reviews.Add(review);
        await _context.SaveChangesAsync();

        TempData["ReviewSuccess"] = "Thank you! Your review has been submitted successfully and is now live.";
        return RedirectToAction(nameof(Details), new { id = ProductId });
    }

    //quick review
    public async Task<IActionResult> QuickReview(int id)
    {
        var product = await _context.Products.Include(p => p.Brand).Include(p => p.Category)
            .Include(p => p.Colors).Include(p => p.Sizes)
            .Include(p => p.Images).FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
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

        var products = await _context.Products.Include(p => p.Images)
            .Where(p => p.CategoryId == id && p.IsActive)
            .ToListAsync();

        return View(products);
    }
}