using MatuszewskiStasiak.SuperBooks.Web.Models;
using MatuszewskiStasiak.SuperBooks.BLC;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MatuszewskiStasiak.SuperBooks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BLC.BLC _blc;

        public HomeController(ILogger<HomeController> logger, BLC.BLC blc)
        {
            _logger = logger;
            _blc = blc;
        }

        public IActionResult Index()
        {
            var publishers = _blc.GetPublishers();
            foreach (var p in publishers)
            {
                Console.WriteLine($"{p.ID}: {p.Name}, {p.Address}, {p.YearCreated}");
            }
            var books = _blc.GetBooks();
            foreach (var b in books)
            {
                Console.WriteLine($"{b.ID}: {b.Publisher.Name} {b.Name} ({b.YearPublished}) {b.Type}");
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
