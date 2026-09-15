using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using NiceShop.Data;
using NiceShop.Models;
using NiceShop.ViewModels;

namespace NiceShop.Controllers;

// [Authorize]
public class AuthController : Controller {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ApplicationDbContext _applicationDbContext ;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,ApplicationDbContext context) {
        _userManager = userManager;
        _signInManager = signInManager;
        _applicationDbContext = context;
    }

    [HttpGet]
    public IActionResult Index() {
        var model = new AuthVM {
            ActiveTab = "login"
        };

        return View(model);
    }


    [HttpGet]
    public IActionResult CreateAccount() {
        var model = new AuthVM {
            ActiveTab = "register"
        };

        return View(nameof(Index), model);
    }

    [HttpPost]
[ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateAccount(UserRegistrationVM urvm) {
        if (!ModelState.IsValid){
            var authVmInvalid = new AuthVM { Register = urvm, ActiveTab = "register" };
            return View(nameof(Index), authVmInvalid);
        }

        var user = new ApplicationUser();
        user.UserName = urvm.Email;
        user.Email = urvm.Email;
        user.PhoneNumber = urvm.Phone;
        var identityResult = await _userManager.CreateAsync(user, urvm.Password);

        if (identityResult.Succeeded){
            await _signInManager.SignInAsync(user, false);
            var customer = new Customer() {
                FName = urvm.Fname,
                LName = urvm.Lname,
                Id = user.Id
            };

            await _applicationDbContext.Customers.AddAsync(customer);
            await _applicationDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }
      
        foreach (var error in identityResult.Errors){
            ModelState.AddModelError("", error.Description);
        }

        // Return the View with the data so the user can see the errors 
        var authVmFailed = new AuthVM { Register = urvm, ActiveTab = "register" };
        return View(nameof(Index), authVmFailed);
    }

    [HttpGet]
    public async Task<IActionResult> SignIn() {
        return View("Index");
    }

    [HttpPost]
[ValidateAntiForgeryToken]
    public async Task<IActionResult> SaveSignIn(AuthVM authVm) {
        authVm.ActiveTab = "login";
        bool loginValid = ModelState
            .Where(kvp => kvp.Key.StartsWith("Login"))
            .All(kvp => kvp.Value.ValidationState == ModelValidationState.Valid);
        if (!loginValid){
            return View("Index", authVm);
        }

        var appuser = await _userManager.FindByNameAsync(authVm.Login.Email);
        if (appuser is null){
            ModelState.AddModelError("", "Username can't wrong ");
            return View("Index", authVm);
        }

        var isPresent = await _userManager.CheckPasswordAsync(appuser,authVm.Login.Password);
        if (!isPresent){
            ModelState.AddModelError("", "Wrong Password ");
            return View("Index", authVm);
            
        }
        
        await _signInManager.SignInAsync(appuser, authVm.Login.RememberMe);
 
        return RedirectToAction("Index", "Home");
    }


    public async Task<IActionResult> SignOut() {
        await _signInManager.SignOutAsync();

        return View(nameof(Index), new AuthVM() { ActiveTab = "login" });
    }
}