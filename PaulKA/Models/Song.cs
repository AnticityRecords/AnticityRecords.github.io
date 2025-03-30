public class Song
{
    public string Artist { get; set; }
    public string Album { get; set; }
    public string Title { get; set; }
    public string Duration { get; set; }
    public int? BPM { get; set; } // Change to nullable int
    public string Key { get; set; }
    public string TimeSignature { get; set; }
    public string Genre { get; set; }
    public string AudioFileName { get; set; }
}
