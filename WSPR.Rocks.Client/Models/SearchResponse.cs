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
            var spots = new List<Spot>();

            foreach (var data in Data)
            {
                var spot = new Spot();

                spot.Id = UInt64.Parse(data[0].ToString());
                spot.Time = DateTime.Parse(data[1].ToString());
                spot.Band = Int32.Parse(data[2].ToString());
                spot.RxSign = data[3].ToString();
                spot.RxLatitude = float.Parse(data[4].ToString());
                spot.RxLongitude = float.Parse(data[5].ToString());
                spot.RxLocation = data[6].ToString();
                spot.TxSign = data[7].ToString();
                spot.TxLatitude = float.Parse(data[8].ToString());
                spot.TxLongitude = float.Parse(data[9].ToString());
                spot.TxLocation = data[10].ToString();
                spot.Distance = UInt32.Parse(data[11].ToString());
                spot.Azimuth = UInt32.Parse(data[12].ToString());
                spot.RxAzimuth = UInt32.Parse(data[13].ToString());
                spot.Frequency = UInt32.Parse(data[14].ToString());
                spot.Power = Int32.Parse(data[15].ToString());
                spot.SNR = Int32.Parse(data[16].ToString());
                spot.Drift = Int32.Parse(data[17].ToString());
                spot.Version = data[18].ToString();
                spot.Code = Int32.Parse(data[19].ToString());

                spots.Add(spot);
            }

            return spots;
        }
    }

    [JsonPropertyName("rows")]
    public int Rows { get; set; }

    [JsonPropertyName("rows_before_limit_at_least")]
    public int RowsBeforeLimitAtLeast { get; set; }

    [JsonPropertyName("statistics")]
    public Statistic? Statistics { get; set; }
}
