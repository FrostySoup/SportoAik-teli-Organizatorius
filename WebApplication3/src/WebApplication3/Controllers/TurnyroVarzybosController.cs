using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.Identity;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.Controllers
{
    public class TurnyroVarzybosController : Controller
    {
        private AppDbContext _context;

        public TurnyroVarzybosController(AppDbContext context)
        {
            _context = context;    
        }

        // GET: TurnyroVarzybos
        public IActionResult Index()
        {
            return View(_context.TurnyroVarzybos.ToList());
        }

        // GET: TurnyroVarzybos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TurnyroVarzybos turnyroVarzybos = _context.TurnyroVarzybos.Single(m => m.TurnyroVarzybosID == id);
            if (turnyroVarzybos == null)
            {
                return HttpNotFound();
            }

            return View(turnyroVarzybos);
        }

        // POST: TurnyroVarzybos/Reject
        [HttpPost]
        public IActionResult Reject(int varzybuID, int turnyroID)
        {
            TurnyroVarzybos turnyroVarzybos = _context.TurnyroVarzybos.Single(m => m.TurnyroVarzybosID == varzybuID);
            _context.Remove(turnyroVarzybos);
            _context.SaveChanges();


            return RedirectToAction("Details", "Turnyras", new { id = turnyroID });
        }

        // POST: TurnyroVarzybos/Confirm
        [HttpPost]
        public IActionResult Confirm(int varzybuID, int turnyroID)
        {
            TurnyroVarzybos turnyroVarzybos = _context.TurnyroVarzybos.Single(m => m.TurnyroVarzybosID == varzybuID);
            turnyroVarzybos.PakvietimoBusena = PakvietimoBusena.Patvirtintas;
            _context.Update(turnyroVarzybos);
            _context.SaveChanges();

            return RedirectToAction("Details", "Turnyras", new { id = turnyroID });
        }

        // Get: TurnyroVarzybos/End
        public IActionResult End(int varzybuID)
        {
            TurnyroVarzybos turnyroVarzybos = _context.TurnyroVarzybos.Single(m => m.TurnyroVarzybosID == varzybuID);
            turnyroVarzybos.PakvietimoBusena = PakvietimoBusena.Pasibaiges;

            _context.Update(turnyroVarzybos);
            _context.SaveChanges();

            return Ok();
        }

        // GET: TurnyroVarzybos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TurnyroVarzybos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TurnyroVarzybos turnyroVarzybos, int turnyroID)
        {
            if (ModelState.IsValid)
            {
                _context.TurnyroVarzybos.Add(turnyroVarzybos);
                _context.SaveChanges();
                return RedirectToAction("Details", "Turnyras", new { id = turnyroID });
            }
            return View(turnyroVarzybos);
        }

        // GET: TurnyroVarzybos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TurnyroVarzybos turnyroVarzybos = _context.TurnyroVarzybos.Single(m => m.TurnyroVarzybosID == id);
            if (turnyroVarzybos == null)
            {
                return HttpNotFound();
            }
            return View(turnyroVarzybos);
        }

        // POST: TurnyroVarzybos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TurnyroVarzybos turnyroVarzybos)
        {
            if (ModelState.IsValid)
            {
                _context.Update(turnyroVarzybos);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turnyroVarzybos);
        }

        // GET: TurnyroVarzybos/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TurnyroVarzybos turnyroVarzybos = _context.TurnyroVarzybos.Single(m => m.TurnyroVarzybosID == id);
            if (turnyroVarzybos == null)
            {
                return HttpNotFound();
            }

            return View(turnyroVarzybos);
        }

        // POST: TurnyroVarzybos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TurnyroVarzybos turnyroVarzybos = _context.TurnyroVarzybos.Single(m => m.TurnyroVarzybosID == id);
            _context.TurnyroVarzybos.Remove(turnyroVarzybos);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
