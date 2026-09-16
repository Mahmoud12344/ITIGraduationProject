using Microsoft.AspNetCore.Mvc;
using NiceShop.Data;
using NiceShop.Models;
using NiceShop.ViewModels;

namespace NiceShop.Controllers;

public class CouponController (ApplicationDbContext dbContext ) : Controller {
    // GET
    [HttpPost]
    public async Task<IActionResult> CreateCoupon(CouponVm couponVm) {

        if (!ModelState.IsValid){
            couponVm.Coupons = dbContext.Coupons.ToList();

            return View( "Coupons" ,couponVm);

        }
        var coupon = new Coupon() {
            Code = couponVm.Coupon.Code,
            ExpiryDate = couponVm.Coupon.ExpiryDate,
            Percentage = couponVm.Coupon.Percentage
        };

        await dbContext.AddAsync(coupon);
        await dbContext.SaveChangesAsync();

     return   RedirectToAction("Coupons");
     

    }
    [HttpPost]
    public async Task<IActionResult> EditCoupon(CouponVm couponVm) {

        if (!ModelState.IsValid)
        {
            couponVm.Coupons = dbContext.Coupons.ToList();
            return View("Coupons", couponVm);
        }

        
        var coupon = await dbContext.Coupons.FindAsync(couponVm.Coupon.Id);

        if (coupon is null)
        {
            return NotFound();
        }


        coupon.Code = couponVm.Coupon.Code;
        coupon.Percentage = couponVm.Coupon.Percentage;
        coupon.ExpiryDate = couponVm.Coupon.ExpiryDate;
        
        await dbContext.SaveChangesAsync();

        return   RedirectToAction("Coupons");
     

    }
    public IActionResult Coupons(string? search, string? status)
    {
        var query = dbContext.Coupons.AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
        {
            query = query.Where(c => c.Code.Contains(search));
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            if (status == "Active")
            {
                query = query.Where(c => c.ExpiryDate >= DateTime.Now);
            }
            else if (status == "Expired")
            {
                query = query.Where(c => c.ExpiryDate < DateTime.Now);
            }
        }

        var cvm = new CouponVm
        {
            Coupons = query.ToList()
        };

        return View(cvm);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        var coupon = await dbContext.Coupons.FindAsync(id);

        if (coupon is null)
        {
            return NotFound();
        }

        dbContext.Coupons.Remove(coupon);
        await dbContext.SaveChangesAsync();

        return RedirectToAction("Coupons");
    }
}