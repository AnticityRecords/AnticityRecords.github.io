using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class AdminToolsController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> UploadMusicCatalog(IFormFile csvFile)
        {
            if (csvFile == null || csvFile.Length == 0)
                return BadRequest("No file uploaded.");

            var filePath = Path.Combine("wwwroot/uploads", csvFile.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await csvFile.CopyToAsync(stream);
            }

            // Process the CSV file as needed
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UploadSong(IFormFile songFile)
        {
            if (songFile == null || songFile.Length == 0)
                return BadRequest("No file uploaded.");

            var filePath = Path.Combine("wwwroot/uploads", songFile.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await songFile.CopyToAsync(stream);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UploadAndConvertVideo(IFormFile videoFile)
        {
            if (videoFile == null || videoFile.Length == 0)
                return BadRequest("No file uploaded.");

            var filePath = Path.Combine("wwwroot/uploads", videoFile.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await videoFile.CopyToAsync(stream);
            }

            // Add video conversion logic here if needed

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ViewContract(string id)
        {
            var contractPath = Path.Combine("wwwroot/contracts", $"{id}.pdf"); // Example path
            if (!System.IO.File.Exists(contractPath))
                return NotFound();

            var fileBytes = System.IO.File.ReadAllBytes(contractPath);
            return File(fileBytes, "application/pdf");
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Example contracts list
            ViewBag.Contracts = GetContracts();

            return View();
        }

        private List<Contract> GetContracts()
        {
            // Retrieve contracts from a service or database
            // For now, returning a sample list
            return new List<Contract>
            {
                new Contract { Id = "1", Name = "Contract 1" },
                new Contract { Id = "2", Name = "Contract 2" }
            };
        }
    }

    public class Contract
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
