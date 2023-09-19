using MVCproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCproject.Controllers
{
    public class ListeController : Controller
    {
        BookPageEntities1 db = new BookPageEntities1();
        // GET: Litse
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Okuduklarim()
        {
            var books = db.List.Where(i => i.IsRead == true).ToList();
            if (books.Count == 0)
            {
                ViewBag.Text = "Listenizde hiç kitap yok!";
                return View("Alert");
            }
            else
            {
                ViewBag.Okuduklarim = books;
                return View();
            } 
        }
        public ActionResult Okunacaklar()
        {
            var books = db.List.Where(i => i.IsRead == false).ToList();
            if (books.Count == 0)
            {
                ViewBag.Text = "Listenizde hiç kitap yok!";
                return View("Alert");
            }
            else
            {
                ViewBag.Okunacaklar = books;
                return View();
            }
        }
        public ActionResult Add(int id, bool reading)
        {
            var book = db.Books.Where(i => i.ID == id).FirstOrDefault();
            var control = db.List.Any(i => i.ID == id);
            if (control)
            {
                ViewBag.Text = "Kitap zaten listenizde ekli!";
                return View("Alert");
            }
            else
            {
                List list = new List();
                list.BookName = book.BookName;
                list.Author = book.Author;
                list.Page = (int)book.Page;
                list.Type = book.Type;
                list.IsRead = reading;
                db.List.Add(list);
                db.SaveChanges();
                return View();
            }
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {

            var list = db.List.Where(i => i.ID == id).FirstOrDefault();
            db.List.Remove(list);
            var sonuc = db.SaveChanges();

            if (sonuc >= 0)
            {

                return Json(new { hasError = false, Result = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { hasError = true, Result = false }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Read(int id)
        {
            var list = db.List.Where(i => i.ID == id).FirstOrDefault();
            list.IsRead = true;
            var sonuc = db.SaveChanges();

            if (sonuc >= 0)
            {

                return Json(new { hasError = false, Result = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { hasError = true, Result = false }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ReadFalse()
        {
            var books = db.List.Where(x => x.IsRead == false).ToList();
            if(books.Count == 0)
            {
                ViewBag.Text = "Listenizde hiç kitap yok!";
                return View("Alert");
            }
            else
            {
                 ViewBag.Okunacaklar = books;
                 return View();
            }
        }
        public ActionResult ReadTrue()
        {
            var books = db.List.Where(x => x.IsRead == true).ToList();
            if (books.Count == 0)
            {
                ViewBag.Text = "Listenizde hiç kitap yok!";
                return View("Alert");
            }
            else
            {
                ViewBag.Okuduklarim = books;
                return View();
            }
        }
    }
}