using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.Identity;
using WebApplication3.Models.TurnyroModeliai;
using WebApplication3.Models.VartotojoModeliai;
using WebApplication3.Helpers;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;


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
                ApplicationUser currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();

                var teams = _context.Komanda.Where(t => t.Pavadinimas == komanda.Pavadinimas).ToList();
                if (teams.Count <= 0)
                {
                    
                    komanda.Kapitonas = currentUser;
                  
                    Komanda team = new Komanda { Kapitonas = komanda.Kapitonas, Pavadinimas = komanda.Pavadinimas };
                    await _rolesHelper.addRoles(User.Identity.Name, new List<string>() { Roles.kapitonas });
                    //komanda.Nariai.Add(currentUser);
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
                currentUser.KomandosId = komanda.KomandaID;
                List<Pakvietimas> invitations = _context.Pakvietimas.Where(i => i.komandosId == komanda.KomandaID).Where(i2 => i2.vartotojoId == currentUser.Id).ToList();
                if (invitations.Count > 0) {
                    foreach (Pakvietimas invitation in invitations) {
                        _context.Remove(invitation);
                        
                    }
                }
            }

            _context.Update(komanda);
            _context.Update(currentUser);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Ignore(int? id) {
            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();

            if (currentUser != null)
            {
                List<Pakvietimas> invitations = _context.Pakvietimas.Where(i => i.komandosId == id).Where(i2 => i2.vartotojoId == currentUser.Id).ToList();
                if (invitations.Count > 0)
                {
                    foreach (Pakvietimas invitation in invitations)
                    {
                        _context.Remove(invitation);

                    }
                }
            }
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

        [ActionName("TeamView")]
        public IActionResult TeamView(int? id) {

            if (id == null)
            {
                var currentUser = _context.Users
                    .Where(x => x.Email == User.Identity.Name)
                    .FirstOrDefault();

                Komanda MyTeam = _context.Komanda.Where(t => t.KomandaID == currentUser.KomandosId).Include(t => t.Nariai).Include(t => t.Kapitonas).FirstOrDefault();
                return View(MyTeam);
            }
           
                Komanda team = _context.Komanda.Where(t => t.KomandaID == id).Include(t => t.Nariai).Include(t => t.Kapitonas).FirstOrDefault();
            
            return View(team);
        }

        // POST: Komanda/TeamView
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SearchForPlayers(Komanda komanda)
        {
        
            if (ModelState.IsValid) {
                ViewData["TeamId"] = komanda.KomandaID;
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

        [ActionName("Invite")]
        public IActionResult Invite(string Id, int teamId)
        {
            
            Pakvietimas invite = new Pakvietimas { komandosId = teamId, vartotojoId = Id };
            _context.Pakvietimas.Add(invite);
            ApplicationUser user = _context.Users
                .Where(x => x.Id == Id)
                .FirstOrDefault();
            if (user.Pakvietimai == null)
            {
                user.Pakvietimai = new List<Pakvietimas>();
            }
            user.Pakvietimai.Add(invite);
            _context.SaveChanges();
          
            return RedirectToAction("TeamView");
        }


        [ActionName("RemoveUser")]
        public IActionResult RemoveUser(string userId)
        {
            ApplicationUser user = _context.Users.Where(u => u.Id == userId).FirstOrDefault();
            Komanda team = _context.Komanda.Where(t => t.KomandaID == user.KomandosId).FirstOrDefault();
            team.Nariai.Remove(user);
            user.KomandosId = 0;
            _context.Update(user);
            _context.Update(team);
            _context.SaveChanges();
            return RedirectToAction("TeamView");
        }

        [ActionName("DeleteTeam")]
        public async Task<IActionResult> DeleteTeam(int id)
        {

            await _rolesHelper.removeRoles(User.Identity.Name, new List<string>() { Roles.kapitonas });
            Komanda team = _context.Komanda.Where(t => t.KomandaID == id).Include(t => t.Nariai).FirstOrDefault();
            List<ApplicationUser> players = _context.Users.Where(u => u.KomandosId == id).ToList();
            if (players != null)
            {
                foreach (ApplicationUser player in players)
                {
                    player.KomandosId = 0;
                    _context.Update(player);
                }
            }
            _context.Remove(team);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }

}
