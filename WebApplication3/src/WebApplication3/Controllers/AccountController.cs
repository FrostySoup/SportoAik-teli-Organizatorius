using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models.Identity;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        //1
    private readonly UserManager<ApplicationUser> _securityManager;
    private readonly SignInManager<ApplicationUser> _loginManager;
        //2
    private AppDbContext _context;

    public AccountController(UserManager<ApplicationUser> secMgr, SignInManager<ApplicationUser> loginManager, AppDbContext context)
    {
        _securityManager = secMgr;
        _loginManager = loginManager;
        _context = context;
    }

    //3
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Register()
    {
         return View();
    }

    //4

    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(Register model)
    {
        if (ModelState.IsValid)
        {
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email
            };
                if (!_context.Roles.Any(r => r.Name == "Administrators"))
                {
                    var store = new RoleStore<IdentityRole>(_context);
                    var manager = new RoleManager<IdentityRole>(store, null, null, null, null, null);
                    var role = new IdentityRole { Name = "Administrators" };
                    manager.CreateAsync(role);
                }

                if (!_context.Roles.Any(r => r.Name == "User"))
                {
                    var store = new RoleStore<IdentityRole>(_context);
                    var manager = new RoleManager<IdentityRole>(store, null, null, null, null, null);
                    var role = new IdentityRole { Name = "User" };
                    manager.CreateAsync(role);
                }
                var result = await _securityManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    await _securityManager.AddToRoleAsync(user, "Administrators");
                    await _loginManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction(nameof(HomeController.Index), "Home");
                }
        }

        return View(model);
    }

    //5
    [HttpGet]
    [AllowAnonymous]
    public IActionResult Login(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    //6
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(Login model, string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (ModelState.IsValid)
        {
            var result = await _loginManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                return RedirectToReturnUrl(returnUrl);
            }
        }


        return View(model);
    }

    //7
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOff()
    {
        await _loginManager.SignOutAsync();

        return RedirectToAction(nameof(HomeController.Index), "Home");
    }
    //8
    private IActionResult RedirectToReturnUrl(string returnUrl)
    {
        if (Url.IsLocalUrl(returnUrl))
        {
            return Redirect(returnUrl);
        }
        else
        {
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
}