using System.Text.Json.Serialization;

namespace WSPR.Rocks.Client.Models;

public class Spot
{
    public ulong Id { get; set; }

    public DateTime Time { get; set; }

    public int Band { get; set; }

    public string? RxSign { get; set; }

    public float RxLatitude { get; set; }

    public float RxLongitude { get; set; }

    public string? RxLocation { get; set; }

    public string? TxSign { get; set; }

    public float TxLatitude { get; set; }

    public float TxLongitude { get; set; }

    public string? TxLocation { get; set; }

    public uint Distance { get; set; }

    public uint Azimuth { get; set; }

    public uint RxAzimuth { get; set; }

    public uint Frequency { get; set; }

    public int Power { get; set; }

    public int SNR { get; set; }

    public int Drift { get; set; }

    public string? Version { get; set; }

    public int Code { get; set; }
}