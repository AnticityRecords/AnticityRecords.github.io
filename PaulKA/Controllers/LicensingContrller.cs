using Microsoft.AspNetCore.Mvc;

namespace PaulKA.Controllers
{
    public class LicensingController : Controller
    {
        // Display Licensing Options
        public IActionResult Index(string song)
        {
            // Pass the selected song to the view using ViewBag
            ViewBag.SelectedSong = string.IsNullOrEmpty(song) ? "Unknown Song" : song;
            return View();
        }
    }
}
