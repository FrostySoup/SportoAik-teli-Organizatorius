using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.Identity;
using WebApplication3.Models.TurnyroModeliai;
using WebApplication3.Helpers;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplication3.Controllers
{
    public class KomandaController : Controller
    {
        private AppDbContext _context;
        private readonly RolesHelper _rolesHelper;
        private readonly UserManager<ApplicationUser> _securityManager;

        public KomandaController(AppDbContext context, UserManager<ApplicationUser> secMgr)
        {
            _context = context;
            _securityManager = secMgr;
            _rolesHelper = new RolesHelper(secMgr, context);
        }

        // GET: Komanda
        public IActionResult Index()
        {
            return View(_context.Komanda.ToList());
        }

        // GET: Komanda/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Komanda komanda = _context.Komanda.Include(x => x.Nariai).Single(m => m.KomandaID == id);
            if (komanda == null)
            {
                return HttpNotFound();
            }

            return View(komanda);
        }

        // GET: Komanda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Komanda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Komanda komanda)
        {
            if (ModelState.IsValid)
            {
                var currentUser = _context.Users
                    .Include(x => x.Books)
                    .Where(x => x.Email == User.Identity.Name)
                    .FirstOrDefault();

                if (currentUser != null)
                {
                    komanda.Kapitonas = currentUser;
                }

                await _rolesHelper.addRoles(User.Identity.Name, new List<string>() { Roles.kapitonas });

                _context.Komanda.Add(komanda);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(komanda);
        }

        // GET: Komanda/Join/5
        public IActionResult Join(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Komanda komanda = _context.Komanda.Single(m => m.KomandaID == id);

            if (komanda == null)
            {
                return HttpNotFound();
            }

            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();

            if (currentUser != null)
            {
                if (komanda.Nariai == null)
                {
                    komanda.Nariai = new List<ApplicationUser>();
                }

                komanda.Nariai.Add(currentUser);
            }

            _context.Update(komanda);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Komanda/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Komanda komanda = _context.Komanda.Single(m => m.KomandaID == id);
            if (komanda == null)
            {
                return HttpNotFound();
            }
            return View(komanda);
        }

        // POST: Komanda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Komanda komanda)
        {
            if (ModelState.IsValid)
            {
                _context.Update(komanda);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(komanda);
        }

        // GET: Komanda/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Komanda komanda = _context.Komanda.Single(m => m.KomandaID == id);
            if (komanda == null)
            {
                return HttpNotFound();
            }

            return View(komanda);
        }

        // POST: Komanda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Komanda komanda = _context.Komanda.Single(m => m.KomandaID == id);
            _context.Komanda.Remove(komanda);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
