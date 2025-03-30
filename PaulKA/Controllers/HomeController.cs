using Microsoft.AspNetCore.Mvc;
using PaulKA.Models;

namespace PaulKA.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult MusicCatalog()
        {
            var model = new MusicCatalogViewModel();
            // Optionally, populate the model with data
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Licensing()
        {
            return View();
        }
    }
}
