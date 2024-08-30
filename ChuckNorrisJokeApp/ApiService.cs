using System.Text.Json;

namespace ChuckNorrisJokeApp;

public class ApiService
{
    public static JokeModel? GetChuckNorrisJoke()
    {
        using (HttpClient client = new HttpClient()) // "Using Statement"
        {
            var response = client.GetStringAsync("https://api.chucknorris.io/jokes/random?category=movie").Result;
        
            JokeModel joke = JsonSerializer.Deserialize<JokeModel>(response);
            return joke;
        }
    }

    public static string TranslateJokeToStarwarsCharacterSpeech(string jokeText, string starwarsCharacter)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = client.GetStringAsync($"https://api.funtranslations.com/translate/{starwarsCharacter}.json?text={jokeText}").Result;
        
            Root? translatedJokeObject = JsonSerializer.Deserialize<Root>(response);

            return translatedJokeObject.Contents.Translated;
        }
    }
}