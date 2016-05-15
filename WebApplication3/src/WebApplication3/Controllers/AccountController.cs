using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc;
using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using WebApplication3.Models.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.AspNet.Authentication.Facebook;
using WebApplication3.Helpers;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        //1
        private readonly UserManager<ApplicationUser> _securityManager;
        private readonly SignInManager<ApplicationUser> _loginManager;
        private readonly ILogger _logger;
        private readonly RolesHelper _rolesHelper;

        //2
        private AppDbContext _context;

        public AccountController(
            UserManager<ApplicationUser> secMgr,
            SignInManager<ApplicationUser> loginManager,
            AppDbContext context,
            ILoggerFactory loggerFactory)
        {
            _securityManager = secMgr;
            _loginManager = loginManager;
            _context = context;
            _logger = loggerFactory.CreateLogger<AccountController>();
            _rolesHelper = new RolesHelper(secMgr, context);
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

                if (!_context.Roles.Any(r => r.Name == "svecias"))
                {
                    var store = new RoleStore<IdentityRole>(_context);
                    var manager = new RoleManager<IdentityRole>(store, null, null, null, null, null);
                    await manager.CreateAsync(new IdentityRole { Name = "svecias" });
                    await manager.CreateAsync(new IdentityRole { Name = "vartotojas" });
                    await manager.CreateAsync(new IdentityRole { Name = "kurejas" });
                    await manager.CreateAsync(new IdentityRole { Name = "kapitonas" });
                    await manager.CreateAsync(new IdentityRole { Name = "administratorius" });
                }

                var result = await _securityManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _rolesHelper.addRoles(model.Email, new List<string>() { Roles.vartotojas });
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


        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl });
            var properties = _loginManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        //
        // GET: /Account/ExternalLoginCallback
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null)
        {
            string name;
            string email;
            string picture;
            var info = await _loginManager.GetExternalLoginInfoAsync();
            email = info.ExternalPrincipal.FindFirstValue(ClaimTypes.Email);
            name = info.ExternalPrincipal.FindFirstValue(ClaimTypes.Name);

            if (info == null)
            {
                return RedirectToAction(nameof(Login));
            }

            var result = await _loginManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false);
            if (result.Succeeded)
            {
                _logger.LogInformation(5, "User logged in with {Name} provider.", info.LoginProvider);
                return RedirectToAction("Index", "Home");
            }
            if (result.IsLockedOut)
            {
                return View("Lockout");
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                ViewData["LoginProvider"] = info.LoginProvider;
                if (email != null)
                {
                    var user = new ApplicationUser { FullName = name ,UserName = email, Email = email };

                   /* var store = new RoleStore<IdentityRole>(_context);
                    var manager = new RoleManager<IdentityRole>(store, null, null, null, null, null);
                    await manager.CreateAsync(new IdentityRole { Name = "svecias" });
                    await manager.CreateAsync(new IdentityRole { Name = "vartotojas" });
                    await manager.CreateAsync(new IdentityRole { Name = "kurejas" });
                    await manager.CreateAsync(new IdentityRole { Name = "kapitonas" });
                    await manager.CreateAsync(new IdentityRole { Name = "administratorius" });*/

                    var result2 = await _securityManager.CreateAsync(user);
                    if (result2.Succeeded)
                    {
                       // await _rolesHelper.addRoles(email, new List<string>() { Roles.vartotojas });
                        result2 = await _securityManager.AddLoginAsync(user, info);
                        if (result2.Succeeded)
                        {
                            await _loginManager.SignInAsync(user, isPersistent: false);
                            _logger.LogInformation(6, "User created an account using {Name} provider.", info.LoginProvider);
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = email });
            }
        }

        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl = null)
        {
            if (User.IsSignedIn())
            {
                return RedirectToAction(nameof(HomeController.Index));
            }

            if (ModelState.IsValid)
            {
                // Get the information about the user from the external login provider
                var info = await _loginManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };

                /*var store = new RoleStore<IdentityRole>(_context);
                var manager = new RoleManager<IdentityRole>(store, null, null, null, null, null);
                await manager.CreateAsync(new IdentityRole { Name = "svecias" });
                await manager.CreateAsync(new IdentityRole { Name = "vartotojas" });
                await manager.CreateAsync(new IdentityRole { Name = "kurejas" });
                await manager.CreateAsync(new IdentityRole { Name = "kapitonas" });
                await manager.CreateAsync(new IdentityRole { Name = "administratorius" });*/

                var result = await _securityManager.CreateAsync(user);
                if (result.Succeeded)
                {
                  //  await _rolesHelper.addRoles(model.Email, new List<string>() { Roles.vartotojas });
                    result = await _securityManager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _loginManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation(6, "User created an account using {Name} provider.", info.LoginProvider);
                        return RedirectToAction("Index", "Home");
                    }
                }
                AddErrors(result);
            }

            ViewData["ReturnUrl"] = returnUrl;
            return View(model);
        }


        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}