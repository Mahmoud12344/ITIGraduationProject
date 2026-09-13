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
        var sessionItems = _cartService.GetCart();
        var vm = new CartVM();

        foreach (var item in sessionItems)
        {
            // session only has the ids, so go get the real product info from the db
            var product = await _context.Products
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == item.ProductId);

            if (product == null) continue; // product got deleted or doesnt exist, just skip it

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
    public IActionResult Add(int productId, int quantity, string? size, string? color)
    {
        _cartService.AddToCart(productId, quantity, size, color);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Remove(int productId, string? size, string? color)
    {
        _cartService.RemoveFromCart(productId, size, color);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult UpdateQuantity(int productId, string? size, string? color, int quantity)
    {
        _cartService.UpdateQuantity(productId, size, color, quantity);
        return RedirectToAction("Index");
    }
}