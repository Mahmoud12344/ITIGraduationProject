using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;

namespace NiceShop.Controllers;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    // GET: Admin/Products
    public async Task<IActionResult> Products()
    {
        var products = await _context.Products
            .Include(p => p.Category)
            .Include(p => p.Brand)
            .ToListAsync();

        return View(products);
    }

    // GET: Admin/AddProduct
    public async Task<IActionResult> AddProduct()
    {
        await PopulateDropdowns();
        return View();
    }

    // POST: Admin/AddProduct
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddProduct(Product product)
    {
        if (ModelState.IsValid)
        {
            product.CreatedAt = DateTime.Now;
            product.UpdatedAt = DateTime.Now;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Products));
        }

        await PopulateDropdowns(product.CategoryId, product.BrandId);
        return View(product);
    }

    // GET: Admin/EditProduct/5
    public async Task<IActionResult> EditProduct(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var product = await _context.Products.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        await PopulateDropdowns(product.CategoryId, product.BrandId);
        return View(product);
    }

    // POST: Admin/EditProduct/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EditProduct(int id, Product product)
    {
        if (id != product.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            product.UpdatedAt = DateTime.Now;
            _context.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Products));
        }

        await PopulateDropdowns(product.CategoryId, product.BrandId);
        return View(product);
    }

    // POST: Admin/DeleteProduct
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Products));
    }

    public IActionResult Orders()
    {
        return View();
    }

    public IActionResult Reviews()
    {
        return View();
    }

    // GET: Admin/CategoriesCoupons
    public async Task<IActionResult> CategoriesCoupons()
    {
        var categories = await _context.Categories.ToListAsync();
        return View(categories);
    }

    // POST: Admin/AddCategory
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddCategory(string name, string slug)
    {
        bool exists = await _context.Categories.AnyAsync(c => c.Name == name);
        if (!exists && !string.IsNullOrWhiteSpace(name))
        {
            _context.Categories.Add(new Category { Name = name, Slug = slug });
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(CategoriesCoupons));
    }

    // POST: Admin/DeleteCategory
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(CategoriesCoupons));
    }

    private async Task PopulateDropdowns(int? selectedCategoryId = null, int? selectedBrandId = null)
    {
        ViewBag.CategoryId = new SelectList(
            await _context.Categories.ToListAsync(), "Id", "Name", selectedCategoryId);

        ViewBag.BrandId = new SelectList(
            await _context.Brands.ToListAsync(), "Id", "Name", selectedBrandId);
    }
}