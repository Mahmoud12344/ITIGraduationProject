using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using NiceShop.Data;
using NiceShop.Models;
using NiceShop.Services;
using NiceShop.Services;
using NiceShop.ViewModels;

namespace NiceShop.Controllers;

// [Authorize]
public class AuthController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly ICartService _cartService;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ApplicationDbContext context, ICartService cartService)
    {

        _userManager = userManager;
        _signInManager = signInManager;
        _cartService = cartService;
        _applicationDbContext = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var model = new AuthVM
        {
            ActiveTab = "login"
        };

        return View(model);
    }


    [HttpGet]
    public IActionResult CreateAccount()
    {
        var model = new AuthVM
        {
            ActiveTab = "register"
        };

        return View(nameof(Index), model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAccount(UserRegistrationVM urvm)
    {
        if (!ModelState.IsValid)
        {
            var authVmInvalid = new AuthVM { Register = urvm, ActiveTab = "register" };
            return View(nameof(Index), authVmInvalid);
        }

        var user = new ApplicationUser();
        user.UserName = urvm.Email;
        user.Email = urvm.Email;
        user.PhoneNumber = urvm.Phone;

        var identityResult = await _userManager.CreateAsync(user, urvm.Password);

        if (identityResult.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);

            var customer = new Customer()
            {
                FName = urvm.Fname,
                LName = urvm.Lname,
                Id = user.Id
            };

            await _applicationDbContext.Customers.AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync();

            // user might have added stuff to the cart before making an account, move it over
            try
            {
                await _cartService.MergeGuestCartIntoDbAsync();
            }
            catch (Exception ex)
            {
                // don't let a cart merge failure break account creation
            }

            return RedirectToAction("Index");
        }

        foreach (var error in identityResult.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        // Return the View with the data so the user can see the errors 
        var authVmFailed = new AuthVM { Register = urvm, ActiveTab = "register" };
        return View(nameof(Index), authVmFailed);
    }

    [HttpGet]
    public async Task<IActionResult> SignIn()
    {
        return View("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveSignIn(AuthVM authVm)
    {
        authVm.ActiveTab = "login";
        bool loginValid = ModelState
            .Where(kvp => kvp.Key.StartsWith("Login"))
            .All(kvp => kvp.Value.ValidationState == ModelValidationState.Valid);
        if (!loginValid)
        {
            return View("Index", authVm);
        }

        var appuser = await _userManager.FindByNameAsync(authVm.Login.Email);
        if (appuser is null)
        {
            ModelState.AddModelError("", "Username can't wrong ");
            return View("Index", authVm);
        }

        var isPresent = await _userManager.CheckPasswordAsync(appuser, authVm.Login.Password);
        if (!isPresent)
        {
            ModelState.AddModelError("", "Wrong Password ");
            return View("Index", authVm);

        }

        await _signInManager.SignInAsync(appuser, authVm.Login.RememberMe);

        // same as register, user might have stuff in guest cart before logging in, move it over
        try
        {
            await _cartService.MergeGuestCartIntoDbAsync();
        }
        catch (Exception ex)
        {
            // dont let a cart merge failure break login
        }

        return RedirectToAction("Index", "Home");
    }


    public async Task<IActionResult> SignOut()
    {
        await _signInManager.SignOutAsync();

        return View(nameof(Index), new AuthVM() { ActiveTab = "login" });
    }
}