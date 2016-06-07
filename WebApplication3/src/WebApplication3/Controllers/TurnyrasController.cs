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
using System.Net.Http;
using System;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Services.Contracts;

namespace WebApplication3.Controllers
{
    public class TurnyrasController : Controller
    {
        private AppDbContext _context;
        private readonly RolesHelper _rolesHelper;
        private readonly UserManager<ApplicationUser> _securityManager;
        private TeamService _teamService;

        public TurnyrasController(AppDbContext context, UserManager<ApplicationUser> securityManager)
        {
            _context = context;
            _securityManager = securityManager;
            _teamService = new TeamService();
            _rolesHelper = new RolesHelper(_securityManager, _context);
        }

        // GET: Turnyras
        public IActionResult Index(int? type)
        {
            var ViewModel = new IndexViewModel() { Turnyrai = _context.Turnyras.Include(x => x.TurnyroAutorius).ToList(), Type = type };
            
            if (type != null)
            {
                ViewModel = new IndexViewModel() { Turnyrai = _context.Turnyras.Where(t => t.TurnyroBusena.ToString() == Enum.GetName(typeof(TurnyroBusena), type)).Include(x => x.TurnyroAutorius).ToList(), Type = type };
            }

            return View(ViewModel);
        }

        // GET: Turnyras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            var aiksteles = _context.Aiksteles.ToList();

            var currentUser = _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
            Komanda komanda = _teamService.getUserTeam(_context, currentUser);

            Turnyras turnyras = _context.Turnyras.Where(m => m.TurnyrasID == id)
                .Include(m => m.TurnyroAutorius)
                .Include(m => m.Dalyviai)
                .ThenInclude(m => m.Komanda)
                .FirstOrDefault();

            var ViewModel = new DetailsViewModel() { Turnyras = turnyras, TurnyroDalyvis = null, Aiksteles = aiksteles, Komanda = komanda };

            TurnyroDalyvis turnyroDalyvis = turnyras.Dalyviai.Where(t => t.Komanda == komanda).FirstOrDefault();

            List<TurnyroVarzybos> visosVarzybos = _context.TurnyroVarzybos.Where(m => m.TurnyrasID == id).ToList();
            ViewModel.VisosTurnyroVarzybos = visosVarzybos;

            List<Komanda> visosKomandos = _context.Komanda.ToList();
            ViewModel.VisosTurnyroKomandos = visosKomandos;

            if (turnyroDalyvis != null)
            {
                TurnyroVarzybos turnyroVarzybos = _context.TurnyroVarzybos.Where(m => m.KomandaA_ID == turnyroDalyvis.ChallongeId && m.PakvietimoBusena != PakvietimoBusena.Pasibaiges).Include(m => m.RezultatoPasiulymas).FirstOrDefault();
                if (turnyroVarzybos == null)
                {
                    turnyroVarzybos = _context.TurnyroVarzybos.Where(m => m.KomandaB_ID == turnyroDalyvis.ChallongeId && m.PakvietimoBusena != PakvietimoBusena.Pasibaiges).Include(m => m.RezultatoPasiulymas).FirstOrDefault();
                }

                if (turnyroVarzybos != null) {
                    ViewModel.TurnyroVarzybos = turnyroVarzybos;
                    Aikstele pasiulymoAikstele = _context.Aiksteles.Where(m => m.AiksteleID == turnyroVarzybos.AiksteleID).FirstOrDefault();
                    ViewModel.Aikstele = pasiulymoAikstele;

                    RezultatoPasiulymas rezultatoPasiulymas = turnyroVarzybos.RezultatoPasiulymas.Where(p => p.Komanda.KomandaID == komanda.KomandaID).SingleOrDefault();
                    ViewModel.RezultatoPasiulymas = rezultatoPasiulymas;

                }
            }

            if (komanda != null && turnyroDalyvis != null) {
                ViewModel.TurnyroDalyvis = turnyroDalyvis;
            }

            if (turnyras == null)
            {
                return HttpNotFound();
            }

            return View(ViewModel);
        }

        // Get: Turnyras/End
        public IActionResult End(string turnyroID)
        {
            Turnyras turnyras = _context.Turnyras.Single(m => m.ChallongeAddress == turnyroID);
            turnyras.TurnyroBusena = TurnyroBusena.Pasibaiges;

            _context.Update(turnyras);
            _context.SaveChanges();

            return Ok();
        }

        // GET: Turnyras/Join/5
        public IActionResult Join(int id, long participantID)
        {
            Turnyras turnyras = _context.Turnyras.Include(m => m.Dalyviai).Single(m => m.TurnyrasID == id);
            var currentUser = _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
            Komanda komanda = _teamService.getUserTeam(_context, currentUser);

            turnyras.Dalyviai.Add(new TurnyroDalyvis() { KomandaID = komanda.KomandaID, TurnyrasID = turnyras.TurnyrasID, ChallongeId = participantID });

            if (turnyras.KomanduKiekis == turnyras.Dalyviai.Count)
            {
                turnyras.TurnyroBusena = TurnyroBusena.Vykstantis;
            }

            _context.Update(turnyras);
            _context.SaveChanges();
            return RedirectToAction("Details", new { id = id });
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
                    .Where(x => x.Email == User.Identity.Name)
                    .FirstOrDefault();

                if (currentUser != null)
                {
                    turnyras.TurnyroAutorius = currentUser;
                }

                await _rolesHelper.addRoles(User.Identity.Name, new List<string>() { Roles.kurejas });

                _context.Turnyras.Add(turnyras);
                _context.SaveChanges();
                return RedirectToAction("Details", new { id = turnyras.TurnyrasID });
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
