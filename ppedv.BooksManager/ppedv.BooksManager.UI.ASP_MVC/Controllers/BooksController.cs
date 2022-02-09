using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ppedv.BooksManager.Logic;
using ppedv.BooksManager.Model;

namespace ppedv.BooksManager.UI.ASP_MVC.Controllers
{
    public class BooksController : Controller
    {
        BooksManagerService bms = new BooksManagerService(new BooksManager.Data.Ef.EfUnitOfWork());

        // GET: BooksController
        public ActionResult Index()
        {
            var books = bms.UnitOfWork.BooksRepository.Query().OrderBy(x => x.Price).ToList();
            return View(books);
        }

        // GET: BooksController/Details/5
        public ActionResult Details(int id)
        {
            return View(bms.UnitOfWork.BooksRepository.GetById(id));
        }

        // GET: BooksController/Create
        public ActionResult Create()
        {
            return View(new Book { Published = DateTime.Now, PageCount = 777, Title = "NEU" });
        }

        // POST: BooksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                bms.UnitOfWork.BooksRepository.Add(book);
                bms.UnitOfWork.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(bms.UnitOfWork.BooksRepository.GetById(id));
        }

        // POST: BooksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Book book)
        {
            try
            {
                bms.UnitOfWork.BooksRepository.Update(book);
                bms.UnitOfWork.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BooksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(bms.UnitOfWork.BooksRepository.GetById(id));
        }

        // POST: BooksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Book canNotDeleteThis)
        {
            try
            {
                var toDelete = bms.UnitOfWork.BooksRepository.GetById(id);
                bms.UnitOfWork.BooksRepository.Delete(toDelete);
                bms.UnitOfWork.SaveAll();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
