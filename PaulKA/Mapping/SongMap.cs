using System.Globalization;
using CsvHelper.Configuration;

public sealed class SongMap : ClassMap<Song>
{
    public SongMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
        Map(m => m.BPM)
            .Name("BPM")
            .TypeConverterOption.NullValues("") // Treat empty fields as null
            .Default(-1); // Default value if needed
    }
}
