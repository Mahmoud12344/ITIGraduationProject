using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.VisualBasic;
using NiceShop.Models;
using NiceShop.ViewModels;

namespace NiceShop.Controllers;

// [Authorize]
public class AuthController : Controller {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public AuthController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) {
        _userManager = userManager;
        _signInManager = signInManager;
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
    public async Task<IActionResult> CreateAccount(UserRegistrationVM urvm) {
        if (!ModelState.IsValid){
            var authVmInvalid = new AuthVM { Register = urvm, ActiveTab = "register" };
            return View(nameof(Index), authVmInvalid);
        }

        var user = new ApplicationUser();
        user.UserName = urvm.Email;
        user.Email = urvm.Email;
        user.PhoneNumber = urvm.Phone;

        var res = await _userManager.CreateAsync(user, urvm.Password);
        if (res.Succeeded){
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index");
        }

        foreach (var error in res.Errors){
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