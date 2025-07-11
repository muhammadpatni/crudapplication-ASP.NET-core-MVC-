using crudapplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace crudapplication.Controllers
{
    public class crudController : Controller
    {
        public IActionResult Showbooks()
        {
            List<Books> Books = Crud.getallbook();
            return View(Books);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult create(Books books)
        {
            try
            {
                Crud.addnewbook(books);
                return RedirectToAction("Showbooks");
            }
            catch
            {
                return View();
            }
        }


        public IActionResult Details(string? isbn)
        {
            Books book = Crud.getbookbyisbn(isbn);
            return View(book);
        }

        public IActionResult Delete(string? isbn)
        {
            Books book = Crud.getbookbyisbn(isbn);
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Books book)
        {
            try
            {
                Crud.deletebook(book.isbn);
                return RedirectToAction("Showbooks");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(string? isbn)
        {
            Books book = Crud.getbookbyisbn(isbn);
            return View(book);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Books book)
        {
            try
            {
                Crud.UpdateBook(book);
                return RedirectToAction("Showbooks");
            }
            catch
            {
                return View();
            }
        }

    }
}
