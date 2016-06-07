using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.Identity;
using WebApplication3.Models.TurnyroModeliai;

namespace WebApplication3.Controllers
{
    public class TurnyroVarzybuKomentarasController : Controller
    {
        private AppDbContext _context;

        public TurnyroVarzybuKomentarasController(AppDbContext context)
        {
            _context = context;    
        }

        // GET: TurnyroVarzybuKomentaras
        public IActionResult Index()
        {
            return View(_context.TurnyroVarzybuKomentaras.ToList());
        }

        // GET: TurnyroVarzybuKomentaras/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TurnyroVarzybuKomentaras turnyroVarzybuKomentaras = _context.TurnyroVarzybuKomentaras.Single(m => m.TurnyroVarzybuKomentarasID == id);
            if (turnyroVarzybuKomentaras == null)
            {
                return HttpNotFound();
            }

            return View(turnyroVarzybuKomentaras);
        }

        // GET: TurnyroVarzybuKomentaras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TurnyroVarzybuKomentaras/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TurnyroVarzybuKomentaras turnyroVarzybuKomentaras)
        {
            if (ModelState.IsValid)
            {
                _context.TurnyroVarzybuKomentaras.Add(turnyroVarzybuKomentaras);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turnyroVarzybuKomentaras);
        }

        // GET: TurnyroVarzybuKomentaras/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TurnyroVarzybuKomentaras turnyroVarzybuKomentaras = _context.TurnyroVarzybuKomentaras.Single(m => m.TurnyroVarzybuKomentarasID == id);
            if (turnyroVarzybuKomentaras == null)
            {
                return HttpNotFound();
            }
            return View(turnyroVarzybuKomentaras);
        }

        // POST: TurnyroVarzybuKomentaras/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TurnyroVarzybuKomentaras turnyroVarzybuKomentaras)
        {
            if (ModelState.IsValid)
            {
                _context.Update(turnyroVarzybuKomentaras);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turnyroVarzybuKomentaras);
        }

        // GET: TurnyroVarzybuKomentaras/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            TurnyroVarzybuKomentaras turnyroVarzybuKomentaras = _context.TurnyroVarzybuKomentaras.Single(m => m.TurnyroVarzybuKomentarasID == id);
            if (turnyroVarzybuKomentaras == null)
            {
                return HttpNotFound();
            }

            return View(turnyroVarzybuKomentaras);
        }

        // POST: TurnyroVarzybuKomentaras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            TurnyroVarzybuKomentaras turnyroVarzybuKomentaras = _context.TurnyroVarzybuKomentaras.Single(m => m.TurnyroVarzybuKomentarasID == id);
            _context.TurnyroVarzybuKomentaras.Remove(turnyroVarzybuKomentaras);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
