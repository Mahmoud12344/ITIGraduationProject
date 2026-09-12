using NiceShop.Models;

namespace NiceShop.Services;

public interface ICartService
{
    List<CartSessionItem> GetCart();
    void AddToCart(int productId, int quantity, string? size, string? color);
    void RemoveFromCart(int productId, string? size, string? color);
    void UpdateQuantity(int productId, string? size, string? color, int newQuantity);
    void ClearCart();
}

public class CartService : ICartService
{
    private const string CartSessionKey = "Cart";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private ISession Session => _httpContextAccessor.HttpContext!.Session;

    public List<CartSessionItem> GetCart()
    {
        return Session.GetObject<List<CartSessionItem>>(CartSessionKey) ?? new List<CartSessionItem>();
    }

    private void SaveCart(List<CartSessionItem> cart)
    {
        Session.SetObject(CartSessionKey, cart);
    }

    public void AddToCart(int productId, int quantity, string? size, string? color)
    {
        var cart = GetCart();

        var existingItem = cart.FirstOrDefault(i =>
            i.ProductId == productId && i.Size == size && i.Color == color);

        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            cart.Add(new CartSessionItem
            {
                ProductId = productId,
                Quantity = quantity,
                Size = size,
                Color = color
            });
        }

        SaveCart(cart);
    }

    public void RemoveFromCart(int productId, string? size, string? color)
    {
        var cart = GetCart();
        cart.RemoveAll(i => i.ProductId == productId && i.Size == size && i.Color == color);
        SaveCart(cart);
    }

    public void UpdateQuantity(int productId, string? size, string? color, int newQuantity)
    {
        var cart = GetCart();
        var item = cart.FirstOrDefault(i =>
            i.ProductId == productId && i.Size == size && i.Color == color);

        if (item != null)
        {
            if (newQuantity <= 0)
                cart.Remove(item);
            else
                item.Quantity = newQuantity;
        }

        SaveCart(cart);
    }

    public void ClearCart()
    {
        Session.Remove(CartSessionKey);
    }
}