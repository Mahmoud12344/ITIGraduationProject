using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.services;
using NiceShop.ViewModels.Cart;

namespace NiceShop.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly ApplicationDbContext _context;

    public CartController(ICartService cartService, ApplicationDbContext context)
    {
        _cartService = cartService;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var sessionItems = await _cartService.GetCartAsync();
        var vm = new CartVM();

        foreach (var item in sessionItems)
        {
            var product = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == item.ProductId);

            if (product == null) continue;

            vm.Items.Add(new CartLineVM
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ImageUrl = product.Images.FirstOrDefault()?.FilePath,
                Price = product.Price,
                Quantity = item.Quantity,
                Size = item.Size,
                Color = item.Color
            });
        }

        return View(vm);
    }

    [HttpPost]
    public async Task<IActionResult> Add(int productId, int quantity, string? size, string? color)
    {
        await _cartService.AddToCartAsync(productId, quantity, size, color);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> Remove(int productId, string? size, string? color)
    {
        await _cartService.RemoveFromCartAsync(productId, size, color);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UpdateQuantity(int productId, string? size, string? color, int quantity)
    {
        await _cartService.UpdateQuantityAsync(productId, size, color, quantity);
        return RedirectToAction("Index");
    }
}