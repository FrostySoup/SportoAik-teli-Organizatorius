using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.Identity;
using Microsoft.AspNet.Authorization;

namespace WebApplication3.Controllers
{
    public class AikstelesController : Controller
    {
        private AppDbContext _context;

        public AikstelesController(AppDbContext context)
        {
            _context = context;    
        }

        // GET: Aiksteles
        public IActionResult Index()
        {
            return View(_context.Aiksteles.ToList());
        }

        // GET: Aiksteles/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Aikstele aikstele = _context.Aiksteles.Single(m => m.AiksteleID == id);
            if (aikstele == null)
            {
                return HttpNotFound();
            }

            return View(aikstele);
        }

        // GET: Aiksteles/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aiksteles/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Aikstele aikstele)
        {
            if (ModelState.IsValid)
            {
                string temporaryID = System.Guid.NewGuid().ToString();
                aikstele.AiksteleID = temporaryID;
                _context.Aiksteles.Add(aikstele);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aikstele);
        }

        // GET: Aiksteles/Edit/5
        [Authorize]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Aikstele aikstele = _context.Aiksteles.Single(m => m.AiksteleID == id);
            if (aikstele == null)
            {
                return HttpNotFound();
            }
            return View(aikstele);
        }

        // POST: Aiksteles/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aikstele aikstele)
        {
            if (ModelState.IsValid)
            {
                _context.Update(aikstele);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aikstele);
        }

        // GET: Aiksteles/Delete/5
        [Authorize]
        [ActionName("Delete")]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Aikstele aikstele = _context.Aiksteles.Single(m => m.AiksteleID == id);
            if (aikstele == null)
            {
                return HttpNotFound();
            }

            return View(aikstele);
        }

        // POST: Aiksteles/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            Aikstele aikstele = _context.Aiksteles.Single(m => m.AiksteleID == id);
            _context.Aiksteles.Remove(aikstele);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
