using System.Text.Json.Serialization;
using static WSPR.Rocks.Client.Models.Hours;

namespace WSPR.Rocks.Client.Models;

public class SearchRequest
{
    public bool Parms { get; set; } = true;

    public bool Balloons { get; set; } = false;

    public string RxCall { get; set; } = "";

    public string TxCall { get; set; } = "";

    public int Count { get; set; } = 500;

    public string Mode { get; set; } = "All";

    public string Band { get; set; } = Bands.All;

    public string Hours { get; set; } = One;

    public bool Unique { get; set; } = false;

    // TODO: Add Advanced Search if needed
    public readonly string Advanced = "";

    public bool VersionSearch { get; set; } = false;
}