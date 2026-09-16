using NiceShop.Models;
using NiceShop.ViewModels.Cart;

namespace NiceShop.ViewModels.Checkout;

public class CheckoutVM
{
    public CartVM Cart { get; set; } = new CartVM();
    public List<Address> Addresses { get; set; } = new List<Address>();
    public int? SelectedAddressId { get; set; }

    public string? AppliedCouponCode { get; set; }
    public decimal DiscountAmount { get; set; }

    // no real payment/order yet, this is just cart total minus discount for now
    public decimal Total => Cart.Subtotal - DiscountAmount;
}

// used by the "add a new address" form
public class NewAddressVM
{
    public string Government { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Building { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public AddressType AddressType { get; set; }
}