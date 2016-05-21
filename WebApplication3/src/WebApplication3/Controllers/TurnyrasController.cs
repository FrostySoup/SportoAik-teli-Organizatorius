using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.Identity;
using WebApplication3.Models.TurnyroModeliai;
using WebApplication3.Helpers;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using WebApplication3.Services;
using WebApplication3.ViewModel.TurnyroViewModeliai;

namespace WebApplication3.Controllers
{
    public class TurnyrasController : Controller
    {
        private AppDbContext _context;
        private readonly RolesHelper _rolesHelper;
        private readonly UserManager<ApplicationUser> _securityManager;

        public TurnyrasController(AppDbContext context, UserManager<ApplicationUser> secMgr)
        {
            _context = context;
            _securityManager = secMgr;
            _rolesHelper = new RolesHelper(secMgr, context);
        }

        // GET: Turnyras
        public IActionResult Index(int? type)
        {
            var ViewModel = new IndexViewModel() { Turnyrai = _context.Turnyras.ToList(), Type = type };

            return View(ViewModel);
        }

        // GET: Turnyras/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Turnyras turnyras = _context.Turnyras.Where(m => m.TurnyrasID == id)
                .Include(m => m.Dalyviai)
                .ThenInclude(m => m.Komanda)
                .FirstOrDefault();

            if (turnyras == null)
            {
                return HttpNotFound();
            }

            return View(turnyras);
        }

        // GET: Turnyras/Join/5
        public async Task<IActionResult> Join(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Turnyras turnyras = _context.Turnyras.Single(m => m.TurnyrasID == id);
            var currentUser = _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
            Komanda komanda = TeamService.Instance.getUserTeam(_context, currentUser);

            if (turnyras.Dalyviai == null)
            {
                turnyras.Dalyviai = new List<TurnyroDalyvis>();
            }

            turnyras.Dalyviai.Add(new TurnyroDalyvis() { KomandaID = komanda.KomandaID, TurnyrasID = turnyras.TurnyrasID });
            await ChallongeService.AddTeam(komanda);

            _context.Update(turnyras);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Turnyras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turnyras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Turnyras turnyras)
        {

            if (ModelState.IsValid)
            {
                var currentUser = _context.Users
                    .Include(x => x.Books)
                    .Where(x => x.Email == User.Identity.Name)
                    .FirstOrDefault();

                if (currentUser != null)
                {
                    turnyras.TurnyroAutorius = currentUser;
                }

                await _rolesHelper.addRoles(User.Identity.Name, new List<string>() { Roles.kurejas });

                _context.Turnyras.Add(turnyras);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turnyras);
        }

        // GET: Turnyras/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Turnyras turnyras = _context.Turnyras.Single(m => m.TurnyrasID == id);
            if (turnyras == null)
            {
                return HttpNotFound();
            }
            return View(turnyras);
        }

        // POST: Turnyras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Turnyras turnyras)
        {
            if (ModelState.IsValid)
            {
                _context.Update(turnyras);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turnyras);
        }

        // GET: Turnyras/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Turnyras turnyras = _context.Turnyras.Single(m => m.TurnyrasID == id);
            if (turnyras == null)
            {
                return HttpNotFound();
            }

            return View(turnyras);
        }

        // POST: Turnyras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Turnyras turnyras = _context.Turnyras.Single(m => m.TurnyrasID == id);
            _context.Turnyras.Remove(turnyras);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
