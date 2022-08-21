using System.Text.Json.Serialization;

namespace WSPR.Rocks.Client.Models;

public class Statistic
{
    [JsonPropertyName("elapsed")]
    public decimal Elapsed { get; set; }

    [JsonPropertyName("rows_read")]
    public int RowsRead { get; set; }

    [JsonPropertyName("bytes_read")]
    public int BytesRead { get; set; }
}