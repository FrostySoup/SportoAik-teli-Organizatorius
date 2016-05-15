using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.Identity;
using WebApplication3.Models.TurnyroModeliai;
using WebApplication3.Models.VartotojoModeliai;
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
            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();
            ViewBag.KomandosId = currentUser.KomandosId;
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
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();

                var teams = _context.Komanda.Where(t => t.Pavadinimas == komanda.Pavadinimas).ToList();
                if (teams.Count <= 0)
                {
                    
                    komanda.Kapitonas = currentUser;
                  
                    Komanda team = new Komanda { Kapitonas = komanda.Kapitonas, Pavadinimas = komanda.Pavadinimas };
                    await _rolesHelper.addRoles(User.Identity.Name, new List<string>() { Roles.kapitonas });

                    _context.Komanda.Add(komanda);
                    _context.SaveChanges();

                    var UserTeam = _context.Komanda.Where(t => t.Kapitonas.Id == komanda.Kapitonas.Id).FirstOrDefault();
                    currentUser.KomandosId = UserTeam.KomandaID;
                    _context.Update(currentUser);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            ViewBag.TeamCreateError = "Tokia komanda jau egzistuoja!";
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
        public IActionResult Edit()
        {
            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();

            Komanda team = _context.Komanda.Where(t => t.KomandaID == currentUser.KomandosId).FirstOrDefault();
            return View(team);
        }


        public IActionResult TeamView() {
            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();

            Komanda team = _context.Komanda.Single(t => t.KomandaID == currentUser.KomandosId);
            return View(team);
        }

        // POST: Komanda/TeamView
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchForPlayers(Komanda komanda)
        {
        
            if (ModelState.IsValid) {
                ViewBag.TeamId = komanda.KomandaID;
                var foundUsers = _context.Users.Where(u => u.FullName == komanda.SearchForPlayers).Where(u => u.KomandosId == 0).ToList();
                return View(foundUsers);
            }
            return View();
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

        [HttpPost]
        public IActionResult Invite(int id, ApplicationUser user) {
            if (ModelState.IsValid)
            {
                Pakvietimas invite = new Pakvietimas { komandosId = id, vartotojoId = user.Id };
                _context.Pakvietimas.Add(invite);
                _context.SaveChanges();
            }
            return RedirectToAction("TeamView");
        }
    }

}
