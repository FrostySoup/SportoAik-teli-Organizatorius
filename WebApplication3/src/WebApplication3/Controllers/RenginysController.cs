using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.Identity;
using Microsoft.AspNet.Authorization;
using static WebApplication3.DataHelpers.Sportas;
using WebApplication3.DataHelpers;
using System;
using WebApplication3.Helpers;

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
            return View(_context.Renginiai.Include(a => a.Aikstele).ToList());
        }

        [Authorize]
        public IActionResult IndexMano()
        {
            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();
            return View(_context.Renginiai.Where(x => x.RenginioAutoriausID == currentUser.Id).ToList());
        }

        // GET: Renginys/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Renginys renginys = _context.Renginiai
                .Include(a => a.Aikstele)
                .Single(m => m.RenginysID == id);
            if (renginys == null)
            {
                return HttpNotFound();
            }
            TupleBoolUser renginioVartotojai = RenginiuServices.checkJoin(_context, User.Identity.Name, id);
            ViewData["Join"] = renginioVartotojai.canUse;
            ViewData["Users"] = renginioVartotojai.Users;
            ViewData["UsersNumber"] = renginioVartotojai.Users.Count;
            ViewData["Email"] = _context.Users.Where(x => x.Id == renginys.RenginioAutoriausID).First().Email;
            return View(renginys);
        }

        // GET: Renginys/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["Aiksteles"] = _context.Aiksteles.Where(a => a.ArPatvirtinta == true).ToList();
            return View();
        }

        // POST: Renginys/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Renginys renginys)
        {
            if (renginys.Aikstele.AiksteleID == null)
            {
                return RedirectToAction("Create");
            }
            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();
            if (currentUser != null) {
                int saka = -1;
                if (System.Int32.TryParse(renginys.SportoSaka, out saka)){
                    renginys.SportoSaka = Sportas.Zaidimas(saka);
                }
                renginys.Aikstele = _context.Aiksteles.Where(x => x.AiksteleID == renginys.Aikstele.AiksteleID).First();
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
        public IActionResult Redaguoti_rengin(Renginys renginys)
        {
            if (ModelState.IsValid)
            {
                //int saka = -1;
                //if (System.Int32.TryParse(renginys.SportoSaka, out saka))
                //{
                //    renginys.Statusas = RenginioStatusas.Zaidimas(saka);
                //}
                Renginys rengin = _context.Renginiai.Single(m => m.RenginysID == renginys.RenginysID);
                rengin.SportoSaka = renginys.SportoSaka;
                rengin.ZaidejuKiekis = renginys.ZaidejuKiekis;
                rengin.Data = renginys.Data;
                rengin.ArPrasidejo = renginys.ArPrasidejo;
                _context.Update(rengin);
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


        [Authorize]
        // POST: Renginys/Prisijungti/5
        [ActionName("Prisijungti")]
        public IActionResult Prisijungti_prie_renginio(string id)
        {
            Renginys renginys = _context.Renginiai.Single(m => m.RenginysID == id);
            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();

            TupleBoolUser renginioVartotojai = RenginiuServices.checkJoin(_context, User.Identity.Name, id);
            bool canJoin = renginioVartotojai.canUse;
            if (canJoin) {
                if (renginys.UserRenginys == null)
                    renginys.UserRenginys = new System.Collections.Generic.List<UserRenginys>();
                renginys.UserRenginys.Add(new UserRenginys()
                {
                    RenginysId = renginys.RenginysID,
                    ApplicationUserId = currentUser.Id
                });
                _context.Renginiai.Update(renginys);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Details", new { id = id });
        }

        [Authorize]
        // POST: Renginys/Nedalyvauti/5
        [ActionName("Nedalyvauti")]
        public IActionResult Nedalyvauti(string id)
        {
            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .Include(x => x.UserRenginys)
                .FirstOrDefault();
            UserRenginys user = currentUser.UserRenginys.Where(x => x.RenginysId == id).First();
            currentUser.UserRenginys.Remove(user);
            _context.Users.Update(currentUser);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = id });
        }

    }
}
