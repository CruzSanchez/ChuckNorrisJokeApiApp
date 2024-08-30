using System.Text.Json.Serialization;

namespace ChuckNorrisJokeApp;


public class JokeModel
{
    [JsonPropertyName("icon_url")]
    public string IconUrl { get; set; }
    
    [JsonPropertyName("id")]
    public string Id { get; set; }
    
    [JsonPropertyName("url")]
    public string Url { get; set; }
    
    [JsonPropertyName("value")]
    public string Value { get; set; }
    
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }
    
    [JsonPropertyName("categories")]
    public List<string> Categories { get; set; }
}