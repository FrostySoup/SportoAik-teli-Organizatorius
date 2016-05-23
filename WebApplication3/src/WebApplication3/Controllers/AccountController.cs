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
using WebApplication3.Models.TurnyroModeliai;
using WebApplication3.Models.VartotojoModeliai;

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

        [ActionName("UserProfile")]
        public IActionResult UserProfile(string id)
        {
            ApplicationUser user = _context.Users.Where(u => u.Id == id).Include(u => u.UserComments).FirstOrDefault();
            Komentaras comment = new Komentaras();
            UserProfileViewModel UserModel = new UserProfileViewModel { users = user, comment = comment };

            return View(UserModel);
        }

        public IActionResult CommentPlayer(UserProfileViewModel UserModel)
        {

            ApplicationUser commentUser = _context.Users.Where(u => u.Id == UserModel.users.Id).FirstOrDefault();
            ApplicationUser user = _context.Users.Where(u => u.UserName == User.Identity.Name).FirstOrDefault();
           
            Komentaras comment = new Komentaras { Comment = UserModel.comment.Comment, commentedUser = commentUser.Id, userId = user.Id, user = user, Date = DateTime.Now };
            if (commentUser.UserComments == null)
            {
                commentUser.UserComments = new List<Komentaras>();
            }
            commentUser.UserComments.Add(comment);
            _context.Komentaras.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("UserProfile", new { id = commentUser.Id });
        }

        [ActionName("LeaveTeam")]
        public IActionResult LeaveTeam(string id)
        {
            ApplicationUser user = _context.Users.Where(u => u.Id == id).FirstOrDefault();

            Komanda team = _context.Komanda.Where(t => t.KomandaID == user.KomandosId).FirstOrDefault();

            if(team.Nariai == null)
            {
                team.Nariai = new List<ApplicationUser>();
            }

            team.Nariai.Remove(user);
            user.KomandosId = 0;
            _context.Update(user);
            _context.Update(team);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterAdmin(Register model)
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
                    await _rolesHelper.addRoles(model.Email, new List<string>() { Roles.administratorius });
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


        public IActionResult UserInvitations()
        {
            ApplicationUser user = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();
            List<Pakvietimas> invites = new List<Pakvietimas>();
            invites = _context.Pakvietimas.Where(i => i.vartotojoId == user.Id).ToList();
            List<Komanda> teams = new List<Komanda>();
                foreach (Pakvietimas invitation in invites)
                {
                    Komanda team = _context.Komanda.Where(t => t.KomandaID == invitation.komandosId).FirstOrDefault();
                    teams.Add(team);
                }
            return View(teams);
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
                    var result2 = await _securityManager.CreateAsync(user);
                    if (result2.Succeeded)
                    {
                       // await _rolesHelper.addRoles(email, new List<string>() { Roles.vartotojas });
                        result2 = await _securityManager.AddLoginAsync(user, info);
                        if (result2.Succeeded)
                        {
                            await _rolesHelper.addRoles(email, new List<string>() { Roles.vartotojas });
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