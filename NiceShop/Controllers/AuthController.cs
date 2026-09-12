using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NiceShop.Models;
using NiceShop.ViewModels;

namespace NiceShop.Controllers;

public class AuthController: Controller {
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
  public  AuthController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser>signInManager) {
        _userManager = userManager;
        _signInManager = signInManager;
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

        var res = await _userManager.CreateAsync(user, urvm.Password);
        if (res.Succeeded){
            await _signInManager.SignInAsync(user, false);
            return RedirectToAction("Index"); 
        }

         foreach (var error in res.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
    
        // Return the View with the data so the user can see the errors 
        var authVmFailed = new AuthVM { Register = urvm, ActiveTab = "register" };
        return View(nameof(Index), authVmFailed);
    }
}