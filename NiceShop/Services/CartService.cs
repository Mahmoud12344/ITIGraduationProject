using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;

namespace NiceShop.Services;

public interface ICartService
{
    Task<List<CartSessionItem>> GetCartAsync();
    Task AddToCartAsync(int productId, int quantity, string? size, string? color);
    Task RemoveFromCartAsync(int productId, string? size, string? color);
    Task UpdateQuantityAsync(int productId, string? size, string? color, int quantity);
    Task MergeGuestCartIntoDbAsync();
}

// this decides where the cart lives:
// guest (not logged in) -> browser session, gone after 30 min
// logged in -> real rows in Cart/CartItem tables
public class CartService : ICartService
{
    private const string CartSessionKey = "Cart";
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ApplicationDbContext _context;

    public CartService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext context)
    {
        _httpContextAccessor = httpContextAccessor;
        _context = context;
    }
