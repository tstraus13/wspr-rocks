using System.Text.Json.Serialization;

namespace WSPR.Rocks.Client.Models;

public class SearchResponse
{
    [JsonPropertyName("meta")]
    public List<Meta>? Metadata { get; set; }

    [JsonPropertyName("data")]
    public object[][]? Data {get; set;}

    public List<Spot>? Spots
    { 
        get
        {
            return Data.Select(o => new Spot
            {
                Id = UInt64.Parse(o[0].ToString()),
                Time = DateTime.Parse(o[1].ToString()),
                Band = Int16.Parse(o[2].ToString()),
                RxSign = o[3].ToString(),
                RxLatitude = float.Parse(o[4].ToString()),
                RxLongitude = float.Parse(o[5].ToString()),
                RxLocation = o[6].ToString(),
                TxSign = o[7].ToString(),
                TxLatitude = float.Parse(o[8].ToString()),
                TxLongitude = float.Parse(o[9].ToString()),
                TxLocation = o[10].ToString(),
                Distance = UInt16.Parse(o[11].ToString()),
                Azimuth = UInt16.Parse(o[12].ToString()),
                Frequency = UInt32.Parse(o[13].ToString()),
                Power = Int16.Parse(o[14].ToString()),
                SNR = Int16.Parse(o[15].ToString()),
                Drift = Int16.Parse(o[16].ToString()),
                Version = o[17].ToString(),
                Code = Int16.Parse(o[18].ToString())
            }).ToList();
        }
    }

    [JsonPropertyName("rows")]
    public int Rows { get; set; }

    [JsonPropertyName("rows_before_limit_at_least")]
    public int RowsBeforeLimitAtLeast { get; set; }

    [JsonPropertyName("statistics")]
    public Statistic? Statistics { get; set; }
}
