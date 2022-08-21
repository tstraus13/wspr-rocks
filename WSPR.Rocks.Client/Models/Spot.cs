using System.Text.Json.Serialization;

namespace WSPR.Rocks.Client.Models;

public class Spot
{
    public UInt64 Id { get; set; }

    public DateTime Time { get; set; }

    public Int16 Band { get; set; }

    public string? RxSign { get; set; }

    public float RxLatitude { get; set; }

    public float RxLongitude { get; set; }

    public string? RxLocation { get; set; }

    public string? TxSign { get; set; }

    public float TxLatitude { get; set; }

    public float TxLongitude { get; set; }

    public string? TxLocation { get; set; }

    public UInt16 Distance { get; set; }

    public UInt16 Azimuth { get; set; }

    public UInt32 Frequency { get; set; }

    public Int16 Power { get; set; }

    public Int16 SNR { get; set; }

    public Int16 Drift { get; set; }

    public string? Version { get; set; }

    public Int16 Code { get; set; }
}