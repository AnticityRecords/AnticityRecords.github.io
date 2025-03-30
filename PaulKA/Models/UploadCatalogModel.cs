// File: PaulKA/Models/UploadCatalogModel.cs
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PaulKA.Models
{
    public class UploadCatalogModel : PageModel
    {
        [BindProperty]
        public IFormFile? CsvFile { get; set; }

        public string? SuccessMessage { get; set; }

        public void OnPost()
        {
            if (CsvFile != null)
            {
                // Process the uploaded file
                SuccessMessage = "File uploaded successfully.";
            }
        }
    }
}
