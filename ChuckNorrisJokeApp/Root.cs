using System.Text.Json.Serialization;

namespace ChuckNorrisJokeApp;

public class Root
{
    [JsonPropertyName("contents")]
    public Contents Contents { get; set; }
}