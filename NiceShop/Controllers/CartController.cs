using Microsoft.AspNetCore.Mvc;
using NiceShop.Data;
using NiceShop.Services;

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

    public IActionResult Index()
    {
        var sessionItems = _cartService.GetCart();
        return View(sessionItems);
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
}