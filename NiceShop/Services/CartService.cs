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
    Task ClearCartAsync();
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

    private HttpContext Ctx => _httpContextAccessor.HttpContext!;
    private ISession Session => Ctx.Session;
    private bool IsLoggedIn => Ctx.User.Identity?.IsAuthenticated == true;

    private string? CustomerId =>
        IsLoggedIn ? Ctx.User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value : null;

    // form posts send "" for an empty hidden input, but code that adds items directly
    // sends null. without this "" and null never match and Remove/UpdateQuantity fail
    private static string? Normalize(string? s) => string.IsNullOrEmpty(s) ? null : s;

    // size/color get saved as "" in the db not null, but Normalize turns "" into null
    // so we gotta compare with "" here too or it never finds the item (this is why
    // +/- and remove werent doing anything even tho they returned 200 ok)
    private static string DbValue(string? s) => s ?? "";

    public async Task<List<CartSessionItem>> GetCartAsync()
    {
        if (IsLoggedIn)
        {
            var cart = await GetOrCreateDbCartAsync();
            return cart.CartItems.Select(ci => new CartSessionItem
            {
                ProductId = ci.ProductId,
                Quantity = ci.Quantity,
                Size = ci.Size,
                Color = ci.Color
            }).ToList();
        }

        return GetSessionCart();
    }

    public async Task AddToCartAsync(int productId, int quantity, string? size, string? color)
    {
        size = Normalize(size);
        color = Normalize(color);

        if (IsLoggedIn)
        {
            var dbSize = DbValue(size);
            var dbColor = DbValue(color);

            var cart = await GetOrCreateDbCartAsync();
            var existing = cart.CartItems.FirstOrDefault(ci =>
                ci.ProductId == productId && ci.Size == dbSize && ci.Color == dbColor);

            if (existing != null)
                existing.Quantity += quantity;
            else
                cart.CartItems.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity,
                    Size = dbSize,
                    Color = dbColor
                });

            await _context.SaveChangesAsync();
            return;
        }

        var sessionCart = GetSessionCart();
        var item = sessionCart.FirstOrDefault(i => i.ProductId == productId && i.Size == size && i.Color == color);
        if (item != null)
            item.Quantity += quantity;
        else
            sessionCart.Add(new CartSessionItem { ProductId = productId, Quantity = quantity, Size = size, Color = color });

        SaveSessionCart(sessionCart);
    }

    public async Task RemoveFromCartAsync(int productId, string? size, string? color)
    {
        size = Normalize(size);
        color = Normalize(color);

        if (IsLoggedIn)
        {
            var dbSize = DbValue(size);
            var dbColor = DbValue(color);

            var cart = await GetOrCreateDbCartAsync();
            var item = cart.CartItems.FirstOrDefault(ci =>
                ci.ProductId == productId && ci.Size == dbSize && ci.Color == dbColor);

            if (item != null)
            {
                _context.CartItems.Remove(item);
                await _context.SaveChangesAsync();
            }
            return;
        }

        var sessionCart = GetSessionCart();
        sessionCart.RemoveAll(i => i.ProductId == productId && i.Size == size && i.Color == color);
        SaveSessionCart(sessionCart);
    }

    public async Task UpdateQuantityAsync(int productId, string? size, string? color, int quantity)
    {
        size = Normalize(size);
        color = Normalize(color);

        if (IsLoggedIn)
        {
            var dbSize = DbValue(size);
            var dbColor = DbValue(color);

            var cart = await GetOrCreateDbCartAsync();
            var item = cart.CartItems.FirstOrDefault(ci =>
                ci.ProductId == productId && ci.Size == dbSize && ci.Color == dbColor);

            if (item != null)
            {
                if (quantity <= 0)
                    _context.CartItems.Remove(item);
                else
                    item.Quantity = quantity;

                await _context.SaveChangesAsync();
            }
            return;
        }

        var sessionCart = GetSessionCart();
        var sItem = sessionCart.FirstOrDefault(i => i.ProductId == productId && i.Size == size && i.Color == color);
        if (sItem != null)
        {
            if (quantity <= 0)
                sessionCart.Remove(sItem);
            else
                sItem.Quantity = quantity;
        }
        SaveSessionCart(sessionCart);
    }

    // call this right after login succeeds, so guest items dont just disappear
    public async Task MergeGuestCartIntoDbAsync()
    {
        if (!IsLoggedIn) return;

        var sessionCart = GetSessionCart();
        if (!sessionCart.Any()) return;

        var cart = await GetOrCreateDbCartAsync();

        foreach (var sItem in sessionCart)
        {
            var dbSize = DbValue(Normalize(sItem.Size));
            var dbColor = DbValue(Normalize(sItem.Color));

            var existing = cart.CartItems.FirstOrDefault(ci =>
                ci.ProductId == sItem.ProductId && ci.Size == dbSize && ci.Color == dbColor);

            if (existing != null)
                existing.Quantity += sItem.Quantity;
            else
                cart.CartItems.Add(new CartItem
                {
                    ProductId = sItem.ProductId,
                    Quantity = sItem.Quantity,
                    Size = dbSize,
                    Color = dbColor
                });
        }

        await _context.SaveChangesAsync();
        Session.Remove(CartSessionKey); // moved everything to the db, guest cart is empty now
    }

    // called after an order is successfully placed, so the customer doesnt see the
    // same items still sitting in their cart afterward
    public async Task ClearCartAsync()
    {
        if (IsLoggedIn)
        {
            var cart = await GetOrCreateDbCartAsync();
            _context.CartItems.RemoveRange(cart.CartItems);
            await _context.SaveChangesAsync();
            return;
        }

        Session.Remove(CartSessionKey);
    }

    private async Task<Cart> GetOrCreateDbCartAsync()
    {
        var customerId = CustomerId!;

        // some users get an ApplicationUser but no matching Customer row yet
        // (registration doesnt create one), so make sure it exists before using it
        var customerExists = await _context.Customers.AnyAsync(c => c.Id == customerId);
        if (!customerExists)
        {
            _context.Customers.Add(new Customer
            {
                Id = customerId,
                FName = "Guest",
                LName = "User"
            });
            await _context.SaveChangesAsync();
        }

        var cart = await _context.Carts
            .Include(c => c.CartItems)
            .FirstOrDefaultAsync(c => c.CustomerId == customerId);

        if (cart == null)
        {
            cart = new Cart { CustomerId = customerId };
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();
        }

        return cart;
    }

    private List<CartSessionItem> GetSessionCart()
    {
        return Session.GetObject<List<CartSessionItem>>(CartSessionKey) ?? new List<CartSessionItem>();
    }

    private void SaveSessionCart(List<CartSessionItem> cart)
    {
        Session.SetObject(CartSessionKey, cart);
    }
}