using System.Text.Json.Serialization;

namespace WSPR.Rocks.Client.Models;

public class Meta
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}