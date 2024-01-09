using System.Text.Json.Serialization;

namespace BookStoreCore.Classes;

public class DemoConfiguration
{
    [JsonPropertyName("ssmTimeToLive")]
    public uint SsmTimeToLive { get; set; }

    [JsonPropertyName("ssmPath")]
    public string SsmPath { get; set; }

    [JsonPropertyName("secretsCacheExpiry")]
    public uint SecretsCacheExpiry { get; set; }
}
