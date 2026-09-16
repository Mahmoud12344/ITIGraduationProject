//NiceShop/user/CheckoutController
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NiceShop.Data;
using NiceShop.Models;
using NiceShop.Services;
using NiceShop.ViewModels.Cart;
using NiceShop.ViewModels.Checkout;

namespace NiceShop.Controllers;

// checkout needs a real customer with a real address, no guest checkout
[Authorize]
public class CheckoutController : Controller
{
    private const string CouponSessionKey = "AppliedCouponCode";
    private const string SelectedAddressSessionKey = "SelectedAddressId";

    private readonly ICartService _cartService;
    private readonly ApplicationDbContext _context;

    public CheckoutController(ICartService cartService, ApplicationDbContext context)
    {
        _cartService = cartService;
        _context = context;
    }

    private string CustomerId => User.FindFirstValue(ClaimTypes.NameIdentifier)!;

    public async Task<IActionResult> Index()
    {
        var cartItems = await _cartService.GetCartAsync();

        // day 4 is only address + coupon validation, no order yet, so an empty cart has nothing to do here
        if (!cartItems.Any())
            return RedirectToAction("Index", "Cart");

        var vm = await BuildCheckoutVM(cartItems);
        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddAddress(NewAddressVM model)
    {
        if (!ModelState.IsValid)
        {
            TempData["AddressError"] = "please fill all the address fields";
            return RedirectToAction("Index");
        }

        var customerId = CustomerId;

        // the very first address a customer adds becomes their default automatically
        var hasAnyAddress = await _context.Addresses.AnyAsync(a => a.CustomerId == customerId);

        var address = new Address
        {
            CustomerId = customerId,
            Government = model.Government,
            City = model.City,
            Street = model.Street,
            Building = model.Building,
            ZipCode = model.ZipCode,
            AddressType = model.AddressType,
            IsDefault = !hasAnyAddress
        };

        _context.Addresses.Add(address);
        await _context.SaveChangesAsync();

        // a customer's newly added address becomes the selected one automatically
        HttpContext.Session.SetInt32(SelectedAddressSessionKey, address.Id);

        return RedirectToAction("Index");
    }

    // called when the customer picks a different saved address from the radio list
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SelectAddress(int addressId)
    {
        var customerId = CustomerId;

        // make sure this address actually belongs to the logged in customer,
        // otherwise anyone could pass any id and "select" someone else's address
        var belongsToCustomer = await _context.Addresses
            .AnyAsync(a => a.Id == addressId && a.CustomerId == customerId);

        if (belongsToCustomer)
            HttpContext.Session.SetInt32(SelectedAddressSessionKey, addressId);

        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ApplyCoupon(string couponCode)
    {
        if (string.IsNullOrWhiteSpace(couponCode))
        {
            TempData["CouponError"] = "type a coupon code first";
            return RedirectToAction("Index");
        }

        var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Code == couponCode);

        if (coupon == null)
        {
            TempData["CouponError"] = "this coupon code doesn't exist";
            return RedirectToAction("Index");
        }

        if (coupon.ExpiryDate < DateTime.UtcNow)
        {
            TempData["CouponError"] = "this coupon is expired";
            return RedirectToAction("Index");
        }

        // just storing the code in session for now, not tied to a real order yet since there is no order at this stage
        HttpContext.Session.SetString(CouponSessionKey, coupon.Code);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult RemoveCoupon()
    {
        HttpContext.Session.Remove(CouponSessionKey);
        return RedirectToAction("Index");
    }

    // day 5: this is where the cart actually turns into a real order
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> PlaceOrder(string paymentMethod)
    {
        var customerId = CustomerId;

        var cartItems = await _cartService.GetCartAsync();
        if (!cartItems.Any())
        {
            TempData["OrderError"] = "your cart is empty";
            return RedirectToAction("Index");
        }

        var addressId = HttpContext.Session.GetInt32(SelectedAddressSessionKey);
        if (addressId == null)
        {
            TempData["OrderError"] = "please select a shipping address first";
            return RedirectToAction("Index");
        }

        // same check as SelectAddress, dont trust the session blindly, make sure
        // this address is still actually this customer's address
        var addressBelongsToCustomer = await _context.Addresses
            .AnyAsync(a => a.Id == addressId && a.CustomerId == customerId);

        if (!addressBelongsToCustomer)
        {
            TempData["OrderError"] = "please select a shipping address first";
            return RedirectToAction("Index");
        }

        // fake payment, no real gateway. cash on delivery always "succeeds" since
        // no money moves yet. card fails randomly sometimes just so the failure
        // path (no order created, cart untouched) actually gets tested
        bool paymentSucceeded = paymentMethod == "cod" || new Random().Next(100) < 90;

        if (!paymentSucceeded)
        {
            TempData["OrderError"] = "payment failed, please try again";
            return RedirectToAction("Index");
        }

        var productIds = cartItems.Select(i => i.ProductId).ToList();
        var products = await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .ToDictionaryAsync(p => p.Id);

        var appliedCouponCode = HttpContext.Session.GetString(CouponSessionKey);
        Coupon? coupon = null;
        if (!string.IsNullOrEmpty(appliedCouponCode))
        {
            coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Code == appliedCouponCode);
            if (coupon != null && coupon.ExpiryDate < DateTime.UtcNow)
                coupon = null; // expired between applying it and placing the order, just drop it
        }

        decimal subtotal = 0;
        var orderItems = new List<OrderItem>();

        foreach (var item in cartItems)
        {
            if (!products.TryGetValue(item.ProductId, out var product))
                continue; // product got deleted or something, skip it, dont crash the whole order

            subtotal += product.Price * item.Quantity;

            // CartItem.Size is a plain string but OrderItem.Size is the SizeOption enum,
            // this is where we snapshot it into the enum at the moment of purchase
            SizeOption? sizeEnum = Enum.TryParse<SizeOption>(item.Size, true, out var parsedSize)
                ? parsedSize
                : null;

            orderItems.Add(new OrderItem
            {
                ProductId = product.Id,
                Name = product.Name,
                Price = product.Price,
                Quantity = item.Quantity,
                Size = sizeEnum,
                Color = item.Color
            });
        }

        // NOTE: Order.Discount is declared as int? not decimal?, so this loses
        // any cents. flagged this to Mahmoud, this is a pre-existing model issue.
        decimal discountAmount = coupon != null ? Math.Round(subtotal * (coupon.Percentage / 100m), 2) : 0;
        decimal shippingCost = 0; // free shipping for now, no real shipping calc in day 5 scope
        decimal total = subtotal - discountAmount + shippingCost;

        var order = new Order
        {
            Number = "ORD-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss"),
            CustomerId = customerId,
            AddressId = addressId.Value,
            CouponId = coupon?.Id,
            Subtotal = subtotal,
            ShippingCost = shippingCost,
            Discount = discountAmount > 0 ? (int)discountAmount : null,
            Total = total,
            Status = OrderStatus.Pending,
            OrderItems = orderItems
        };

        // everything below has to succeed together or not at all: the order row,
        // the order item rows, and clearing the cart. if anything fails halfway
        // we dont want a half-created order or an order with a cart still full
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            await _cartService.ClearCartAsync();
            HttpContext.Session.Remove(CouponSessionKey);

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            TempData["OrderError"] = "something went wrong placing your order, please try again";
            return RedirectToAction("Index");
        }

        return RedirectToAction("Confirmation", new { id = order.Id });
    }

    public async Task<IActionResult> Confirmation(int id)
    {
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .Include(o => o.Address)
            .FirstOrDefaultAsync(o => o.Id == id && o.CustomerId == CustomerId);

        // not found, or belongs to someone else - dont let people view others' orders by guessing ids
        if (order == null) return NotFound();

        return View(order);
    }

    private async Task<CheckoutVM> BuildCheckoutVM(List<CartSessionItem> cartItems)
    {
        // rebuilding the same CartVM shape the Cart feature uses, so the order summary
        // sidebar shows the exact same product name/image/price as the cart page
        var productIds = cartItems.Select(i => i.ProductId).ToList();
        var products = await _context.Products
            .Where(p => productIds.Contains(p.Id))
            .Include(p => p.Images)
            .ToDictionaryAsync(p => p.Id);

        var cartVm = new CartVM();
        foreach (var item in cartItems)
        {
            if (!products.TryGetValue(item.ProductId, out var product))
                continue; // product got removed or something, just skip it, dont crash the page

            cartVm.Items.Add(new CartLineVM
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ImageUrl = product.Images.FirstOrDefault(i => i.IsDefault)?.FilePath,
                Price = product.Price,
                Quantity = item.Quantity,
                Size = item.Size,
                Color = item.Color
            });
        }

        var customerId = CustomerId;
        var addresses = await _context.Addresses
            .Where(a => a.CustomerId == customerId)
            .ToListAsync();

        // figure out which address should show as selected:
        // 1. whatever the customer explicitly picked this session, if it's still theirs
        // 2. otherwise their default address
        // 3. otherwise just the first one they have
        var sessionSelectedId = HttpContext.Session.GetInt32(SelectedAddressSessionKey);
        var selectedAddressId = addresses.Any(a => a.Id == sessionSelectedId)
            ? sessionSelectedId
            : addresses.FirstOrDefault(a => a.IsDefault)?.Id ?? addresses.FirstOrDefault()?.Id;

        var vm = new CheckoutVM
        {
            Cart = cartVm,
            Addresses = addresses,
            SelectedAddressId = selectedAddressId
        };

        var appliedCode = HttpContext.Session.GetString(CouponSessionKey);
        if (!string.IsNullOrEmpty(appliedCode))
        {
            var coupon = await _context.Coupons.FirstOrDefaultAsync(c => c.Code == appliedCode);

            // coupon might have expired since it was applied, or gotten deleted, drop it quietly
            if (coupon == null || coupon.ExpiryDate < DateTime.UtcNow)
            {
                HttpContext.Session.Remove(CouponSessionKey);
            }
            else
            {
                vm.AppliedCouponCode = coupon.Code;
                vm.DiscountAmount = Math.Round(cartVm.Subtotal * (coupon.Percentage / 100m), 2);
            }
        }

        return vm;
    }
}