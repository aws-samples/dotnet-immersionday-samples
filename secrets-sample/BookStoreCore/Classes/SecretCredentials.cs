using System.Text.Json.Serialization;

namespace BookStoreCore.Classes;

public class SecretCredentials
{
    [JsonPropertyName("superSecretValue")]
    public string SuperSecretValue { get; set; }
    
    [JsonPropertyName("superSecretLocation")]
    public string SuperSecretLocation { get; set; }
    
    [JsonPropertyName("superSecretAPIKey")]
    public string SuperSecretAPIKey { get; set; }
}