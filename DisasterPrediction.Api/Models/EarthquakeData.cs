using System.Text.Json.Serialization;

namespace DisasterPrediction.Api.Models;

public class EarthquakeData
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("metadata")]
    public Metadata Metadata { get; set; }

    [JsonPropertyName("features")]
    public List<Feature> Features { get; set; }
}

public class Feature
{
    [JsonPropertyName("properties")]
    public Properties Properties { get; set; }
}

public class Metadata
{
    [JsonPropertyName("generated")]
    public long Generated { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("api")]
    public string Api { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}

public class Properties
{
    [JsonPropertyName("mag")]
    public double Mag { get; set; }

    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("time")]
    public object Time { get; set; }

    [JsonPropertyName("updated")]
    public object Updated { get; set; }

    [JsonPropertyName("tz")]
    public int Tz { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("detail")]
    public string Detail { get; set; }

    [JsonPropertyName("felt")]
    public int Felt { get; set; }

    [JsonPropertyName("cdi")]
    public double Cdi { get; set; }

    [JsonPropertyName("mmi")]
    public double Mmi { get; set; }

    [JsonPropertyName("alert")]
    public string Alert { get; set; }

    [JsonPropertyName("status")]
    public string Status { get; set; }

    [JsonPropertyName("tsunami")]
    public int Tsunami { get; set; }

    [JsonPropertyName("sig")]
    public int Sig { get; set; }

    [JsonPropertyName("net")]
    public string Net { get; set; }

    [JsonPropertyName("code")]
    public string Code { get; set; }

    [JsonPropertyName("sources")]
    public string Sources { get; set; }

    [JsonPropertyName("types")]
    public string Types { get; set; }

    [JsonPropertyName("nst")]
    public int Nst { get; set; }

    [JsonPropertyName("dmin")]
    public double Dmin { get; set; }

    [JsonPropertyName("rms")]
    public double Rms { get; set; }

    [JsonPropertyName("gap")]
    public int Gap { get; set; }

    [JsonPropertyName("magType")]
    public string MagType { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }
}
