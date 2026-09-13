using NiceShop.Models;

namespace NiceShop.ViewModels;

public class CouponVm {
    public List<Coupon> Coupons{ get; set; } = new List<Coupon>();
    public Coupon Coupon{ get; set; } = new Coupon();
}