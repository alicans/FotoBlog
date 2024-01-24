using FotoBlog.Data;
using FotoBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FotoBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UygulamaDBContext _db;

        public HomeController(ILogger<HomeController> logger, UygulamaDBContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.Gonderiler.OrderByDescending(x => x.Id).ToList());
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
