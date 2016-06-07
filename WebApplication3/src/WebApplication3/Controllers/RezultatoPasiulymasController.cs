using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.Identity;
using WebApplication3.Models.TurnyroModeliai;
using System.Collections.Generic;
using WebApplication3.ViewModel.RezultatoPasiulymoViewModeliai;

namespace WebApplication3.Controllers
{
    public class RezultatoPasiulymasController : Controller
    {
        private AppDbContext _context;

        public RezultatoPasiulymasController(AppDbContext context)
        {
            _context = context;    
        }

        // GET: RezultatoPasiulymas
        public IActionResult Index(int turnyroID)
        {
            List<IndexViewModel> rezultatuPasiulymai = new List<IndexViewModel>();

            Turnyras turnyras = _context.Turnyras.Where(m => m.TurnyrasID == turnyroID)
                .Include(m => m.Dalyviai)
                .ThenInclude(m => m.Komanda)
                .FirstOrDefault();

            List<TurnyroVarzybos> turnyroVarzybos = _context.TurnyroVarzybos
                .Where(v => v.TurnyrasID == turnyroID && v.RezultatoBusena == RezultatoBusena.Nepatvirtintas)
                .Include(v => v.RezultatoPasiulymas).ToList();

            if (turnyroVarzybos.Count == 0)
            {
                return RedirectToAction("Details", "Turnyras", new { id = turnyras.TurnyrasID });
            }

            foreach(var varzybos in turnyroVarzybos)
            {
                var komandaA = _context.Komanda.Single(k => k.KomandaID == varzybos.KomandaA_ID_DB);
                var komandaB = _context.Komanda.Single(k => k.KomandaID == varzybos.KomandaB_ID_DB);

                TurnyroDalyvis dalyvis = turnyras.Dalyviai.Where(t => t.Komanda == komandaA).FirstOrDefault();

                RezultatoPasiulymas komandaAPasiulymas = null;
                RezultatoPasiulymas komandaBPasiulymas = null;

                foreach (var pasiulymas in varzybos.RezultatoPasiulymas)
                {
                    if (pasiulymas.Komanda == komandaA)
                    {
                        komandaAPasiulymas = pasiulymas;
                    }
                    else
                    {
                        komandaBPasiulymas = pasiulymas;
                    }
                }

                rezultatuPasiulymai.Add(new IndexViewModel()
                {
                    Komanda_A = komandaA,
                    Komanda_B = komandaB,
                    Komanda_A_Pasiulymas = komandaAPasiulymas,
                    Komanda_B_Pasiulymas = komandaBPasiulymas,
                    Turnyras = turnyras,
                    Komanda_A_ChallongeID = dalyvis.ChallongeId,
                    TurnyroVarzybos = varzybos
                });
            }

            return View(rezultatuPasiulymai);
        }

        // GET: RezultatoPasiulymas/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RezultatoPasiulymas rezultatoPasiulymas = _context.RezultatoPasiulymas.Single(m => m.RezultatoPasiulymasID == id);
            if (rezultatoPasiulymas == null)
            {
                return HttpNotFound();
            }

            return View(rezultatoPasiulymas);
        }

        // GET: RezultatoPasiulymas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RezultatoPasiulymas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RezultatoPasiulymas rezultatoPasiulymas)
        {
            if (ModelState.IsValid)
            {
                _context.RezultatoPasiulymas.Add(rezultatoPasiulymas);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezultatoPasiulymas);
        }

        // GET: RezultatoPasiulymas/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RezultatoPasiulymas rezultatoPasiulymas = _context.RezultatoPasiulymas.Single(m => m.RezultatoPasiulymasID == id);
            if (rezultatoPasiulymas == null)
            {
                return HttpNotFound();
            }
            return View(rezultatoPasiulymas);
        }

        // POST: RezultatoPasiulymas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(RezultatoPasiulymas rezultatoPasiulymas)
        {
            if (ModelState.IsValid)
            {
                _context.Update(rezultatoPasiulymas);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezultatoPasiulymas);
        }

        // GET: RezultatoPasiulymas/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            RezultatoPasiulymas rezultatoPasiulymas = _context.RezultatoPasiulymas.Single(m => m.RezultatoPasiulymasID == id);
            if (rezultatoPasiulymas == null)
            {
                return HttpNotFound();
            }

            return View(rezultatoPasiulymas);
        }

        // POST: RezultatoPasiulymas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            RezultatoPasiulymas rezultatoPasiulymas = _context.RezultatoPasiulymas.Single(m => m.RezultatoPasiulymasID == id);
            _context.RezultatoPasiulymas.Remove(rezultatoPasiulymas);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
