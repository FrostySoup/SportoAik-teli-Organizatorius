using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.Identity;
using Microsoft.AspNet.Authorization;
using static WebApplication3.DataHelpers.Sportas;
using WebApplication3.DataHelpers;

namespace WebApplication3.Controllers
{
    public class RenginysController : Controller
    {
        private AppDbContext _context;

        public RenginysController(AppDbContext context)
        {
            _context = context;    
        }

        // GET: Renginys
        public IActionResult Index()
        {
            return View(_context.Renginiai.ToList());
        }

        // GET: Renginys/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Renginys renginys = _context.Renginiai.Single(m => m.RenginysID == id);
            if (renginys == null)
            {
                return HttpNotFound();
            }

            return View(renginys);
        }

        // GET: Renginys/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Renginys/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Renginys renginys)
        {
            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();
            if (currentUser != null) {
                int saka = -1;
                if (System.Int32.TryParse(renginys.SportoSaka, out saka)){
                    renginys.SportoSaka = Sportas.Zaidimas(saka);
                }             
                renginys.RenginioAutoriausID = currentUser.Id;
                renginys.ArPrasidejo = false;
                if (ModelState.IsValid && saka >= 0)
                {
                    string temporaryID = System.Guid.NewGuid().ToString();
                    renginys.RenginysID = temporaryID;
                    _context.Renginiai.Add(renginys);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(renginys);
        }

        // GET: Renginys/Edit/5
        [Authorize]
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Renginys renginys = _context.Renginiai.Single(m => m.RenginysID == id);
            if (renginys == null)
            {
                return HttpNotFound();
            }
            return View(renginys);
        }

        // POST: Renginys/Edit/5
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Renginys renginys)
        {
            if (ModelState.IsValid)
            {
                _context.Update(renginys);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(renginys);
        }

        // GET: Renginys/Delete/5
        [ActionName("Delete")]
        [Authorize]
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Renginys renginys = _context.Renginiai.Single(m => m.RenginysID == id);
            if (renginys == null)
            {
                return HttpNotFound();
            }

            return View(renginys);
        }

        // POST: Renginys/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            Renginys renginys = _context.Renginiai.Single(m => m.RenginysID == id);
            _context.Renginiai.Remove(renginys);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
