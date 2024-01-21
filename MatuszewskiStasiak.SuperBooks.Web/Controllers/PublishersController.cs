using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatuszewskiStasiak.SuperBooks.DAOSQL.BO;
using MatuszewskiStasiak.SuperBooks.BLC;
using MatuszewskiStasiak.SuperBooks.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MatuszewskiStasiak.SuperBooks.Web.Controllers
{
    public class PublishersController : Controller
    {
        private readonly BLC.BLC _blc;

        public PublishersController(BLC.BLC blc)
        {
            _blc = blc;
        }

        // GET: Publishers
        public IActionResult Index(string searchName, string yearCreated)
        {
            ViewData["SearchName"] = searchName;
            IEnumerable<SelectListItem> yearsCreated = _blc.GetAllYearsCreated()
                .Select(y => new SelectListItem() { Text = y.ToString(), Value = y.ToString() })
                .Prepend(new SelectListItem() { Text = "All", Value = "" })
                .ToList();
            foreach (SelectListItem item in yearsCreated)
            {
                if (item.Value == yearCreated)
                {
                    item.Selected = true;
                    break;
                }
            }
            ViewData["YearsCreated"] = yearsCreated;
            return View(_blc.FilterPublishers(searchName, yearCreated));
        }

        // GET: Publishers/Details/5
        public IActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _blc.GetPublisher(id.Value);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // GET: Publishers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publishers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,Address,YearCreated")] PublisherCreate publisher)
        {
            if (ModelState.IsValid)
            {
                _blc.CreateNewPublisher(publisher.Name, publisher.Address, publisher.YearCreated);
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _blc.GetPublisher(id.Value);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("ID,Name,Address,YearCreated")] PublisherEdit publisher)
        {
            if (id != publisher.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {   
                _blc.EditPublisher(publisher.ID, publisher.Name, publisher.Address, publisher.YearCreated);
                return RedirectToAction(nameof(Index));
            }
            return View(publisher);
        }

        // GET: Publishers/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var publisher = _blc.GetPublisher(id.Value);
            if (publisher == null)
            {
                return NotFound();
            }

            return View(publisher);
        }

        // POST: Publishers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _blc.DeletePublisher(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
