using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models.AikstelesModeliai;
using WebApplication3.Models.Identity;
using Microsoft.AspNet.Authorization;
using System.Collections.Generic;
using System;
using WebApplication3.DataHelpers;
using Microsoft.AspNet.Identity;

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
            var currentUser = _context.Users
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();
            List<Aikstele> aiksteles;

            if (User.IsInRole("administratorius"))
            {
                aiksteles = _context.Aiksteles.ToList();
            }
            else
                aiksteles = _context.Aiksteles.Where(x => x.ArPatvirtinta == true).ToList();

            return View(aiksteles);
        }

        [HttpGet("AikstelesMap")]
        public IActionResult GetAiksteles()
        {
            List<AiksteleMap> aiksteles = new List<AiksteleMap>();
            try
            {
                var dbAiksteles = _context.Aiksteles.Where(x => x.ArPatvirtinta == true).ToList();
                foreach (var aikstele in dbAiksteles)
                {
                    aiksteles.Add(new AiksteleMap(aikstele));
                }
            }
            catch (Exception)
            {
                return HttpNotFound();
            }

            return Ok(aiksteles);
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
