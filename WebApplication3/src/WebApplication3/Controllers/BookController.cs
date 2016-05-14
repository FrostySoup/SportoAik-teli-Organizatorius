using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using WebApplication3.Models;
using WebApplication3.Models.Identity;
using Microsoft.AspNet.Authorization;

namespace WebApplication3.Controllers
{
    public class BookController : Controller
    {
        private AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;    
        }

        // GET: Books
        [Authorize]
        public IActionResult Index()
        {

            var currentUser = _context.Users
                .Include(x => x.Books)
                .Where(x => x.Email == User.Identity.Name)
                .FirstOrDefault();
            //_context.Users.
   
                if (currentUser != null)
            {
               var book = currentUser.Books;
                if (book != null)
                {
                    ViewData["Book"] = book;
                }
            }
            else
            {
                return Redirect("/");
            }

            return View();
        }

        // GET: Books/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = _context.Books.Single(m => m.BookID == id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book bookAdd)
        {
            var currentUser = _context.Users.Where(x => x.Email == User.Identity.Name).FirstOrDefault();
            bookAdd.ApplicationUser = currentUser;
            string vardas = User.Identity.Name;
            if (ModelState.IsValid)
            {
                //book.UserName = vardas;  
                          
                _context.Books.Add(bookAdd);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookAdd);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = _context.Books.Single(m => m.BookID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Update(book);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Book book = _context.Books.Single(m => m.BookID == id);
            if (book == null)
            {
                return HttpNotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Book book = _context.Books.Single(m => m.BookID == id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
