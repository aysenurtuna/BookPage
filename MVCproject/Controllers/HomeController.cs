using MVCproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Controllers
{
    public class HomeController : Controller
    {
        BookPageEntities1 db = new BookPageEntities1();
        // GET: Home
        public ActionResult Index()
        {
            List<Books> books = db.Books.ToList();
            ViewBag.Types = db.Books.Select(i => i.Type).Distinct().ToList();
            return View(books);
        }
        public ActionResult Kategoriler(string type)
        {
            var books = db.Books.Where(i => i.Type.ToLower() == type.ToLower()).ToList();
            ViewBag.Liste = books;
            ViewBag.Types = db.Books.Select(i => i.Type).Distinct().ToList();
            return View();
        }
        public ActionResult Details(int id)
        {
            var book = db.Books.Where(i => i.ID == id).ToList();
            bool exist = db.List.Any(i => i.ID == id);
            if (exist)
            {
                bool reading = db.List.Where(i => i.ID == id).Select(i => i.IsRead).FirstOrDefault();
                ViewBag.Reading = reading;
                ViewBag.Exist = exist;
            }
            else
            {
                ViewBag.Exist = false;
            }
            ViewBag.Book = book;
            return View();
        }
        public ActionResult Search(string query)
        {
            var books = db.Books.Where(i => i.BookName.Contains(query)).ToList();
            ViewBag.Search = books;
            return View();
        } 
    }
}
