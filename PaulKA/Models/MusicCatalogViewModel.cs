using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaulKA.Models
{
    public class MusicCatalogViewModel
    {
        [Required(ErrorMessage = "Please select a CSV file.")]
        [Display(Name = "CSV File")]
        public IFormFile CsvFile { get; set; } = default!;

        public List<Song> Songs { get; set; } = new List<Song>();
    }

    public class Song
    {
        public string Artist { get; set; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Duration { get; set; } = string.Empty;
        public int BPM { get; set; }
        public string Key { get; set; } = string.Empty;
        public string TimeSignature { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string AudioFileName { get; set; } = string.Empty; // Added this property
    }
}
