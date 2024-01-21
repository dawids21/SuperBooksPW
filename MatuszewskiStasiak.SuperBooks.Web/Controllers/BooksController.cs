using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MatuszewskiStasiak.SuperBooks.DAOSQL.BO;
using MatuszewskiStasiak.SuperBooks.Web.Models;
using MatuszewskiStasiak.SuperBooks.Core;

namespace MatuszewskiStasiak.SuperBooks.Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly BLC.BLC _blc;

        public BooksController(BLC.BLC blc)
        {
            _blc = blc;
        }

        // GET: Books
        public IActionResult Index(string searchName, string yearPublished, string type, string publisher)
        {
            ViewData["SearchName"] = searchName;
            IEnumerable<SelectListItem> yearsPublished = _blc.GetAllYearsPublished()
                .Select(y => new SelectListItem() { Text = y.ToString(), Value = y.ToString() })
                .Prepend(new SelectListItem() { Text = "All", Value = "" })
                .ToList();
            foreach (SelectListItem item in yearsPublished)
            {
                if (item.Value == yearPublished)
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewData["YearsPublished"] = yearsPublished;
            IEnumerable<SelectListItem> types = Enum.GetValues(typeof(BookType))
                .Cast<BookType>()
                .Select(y => new SelectListItem() { Text = y.ToString(), Value = y.ToString() })
                .Prepend(new SelectListItem() { Text = "All", Value = "" })
                .ToList();
            foreach (SelectListItem item in types)
            {
                if (item.Value == type)
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewData["Types"] = types;
            IEnumerable<SelectListItem> publishers = _blc.GetBooksPublishers()
                .Select(y => new SelectListItem() { Text = y.Name, Value = y.ID.ToString() })
                .Prepend(new SelectListItem() { Text = "All", Value = "" })
                .ToList();
            foreach (SelectListItem item in publishers)
            {
                if (item.Value == publisher)
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewData["Publishers"] = publishers;
            return View(_blc.FilterBooks(searchName, yearPublished, type, publisher).Select(b => new BookDetails()
            {
                ID = b.ID,
                Name = b.Name,
                Publisher = b.Publisher.Name,
                YearPublished = b.YearPublished,
                Type = b.Type
            }));
        }

        // GET: Books/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _blc.GetBook(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            BookDetails bookDetails = new BookDetails()
            {
                ID = book.ID,
                Name = book.Name,
                Publisher = book.Publisher.Name,
                YearPublished = book.YearPublished,
                Type = book.Type
            };
            return View(bookDetails);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            var publishers = _blc.GetPublishers();
            BookCreate book = new BookCreate();
            book.Publishers = publishers.Select(p => new SelectListItem() { Text = p.Name, Value = p.ID.ToString() }).ToList();
            return View(book);
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Publisher,YearPublished,Type,Publishers")] BookCreate book)
        {
            if (ModelState.IsValid)
            {
                _blc.CreateNewBook(book.Name, book.Publisher, book.YearPublished, book.Type);
                return RedirectToAction(nameof(Index));
            }
            var publishers = _blc.GetPublishers();
            book.Publishers = publishers.Select(p => new SelectListItem() { Text = p.Name, Value = p.ID.ToString() }).ToList();
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _blc.GetBook(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            var publishers = _blc.GetPublishers();

            BookEdit bookEdit = new BookEdit()
            {
                ID = book.ID,
                Name = book.Name,
                Publisher = book.Publisher.ID,
                YearPublished = book.YearPublished,
                Type = book.Type,
                Publishers = publishers.Select(p => new SelectListItem() { Text = p.Name, Value = p.ID.ToString() }).ToList()
            };
            return View(bookEdit);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ID,Name,Publisher,YearPublished,Type,Publishers")] BookEdit book)
        {
            if (id != book.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _blc.EditBook(book.ID, book.Name, book.Publisher, book.YearPublished, book.Type);
                return RedirectToAction(nameof(Index));
            }
            var publishers = _blc.GetPublishers();
            book.Publishers = publishers.Select(p => new SelectListItem() { Text = p.Name, Value = p.ID.ToString() }).ToList();
            return View(book);
        }

        // GET: Books/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _blc.GetBook(id.Value);
            if (book == null)
            {
                return NotFound();
            }
            BookDetails bookDelete = new BookDetails()
            {
                ID = book.ID,
                Name = book.Name,
                Publisher = book.Publisher.Name,
                YearPublished = book.YearPublished,
                Type = book.Type
            };
            return View(bookDelete);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _blc.DeleteBook(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
