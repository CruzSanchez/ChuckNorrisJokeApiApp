using System.Net.Http.Headers;
using System.Text;
using System.Text.Json; //import the library <library name> "Using Directive"

namespace ChuckNorrisJokeApp;

class Program
{
    static void Main(string[] args)
    {
        var joke = GetJokeFromApi();
        
        ConsoleLogging.PassMessageToUser(joke.Value, StatusCode.Information);

        ConsoleLogging.PassMessageToUser("Press 1 to translate to Yoda Speech", StatusCode.Information);
        ConsoleLogging.PassMessageToUser("Press 2 to translate to Sith Speech", StatusCode.Information);

        var keyPressed = Console.ReadKey(true);

        string translatedJoke = string.Empty;
        
        switch (keyPressed.Key)
        {
            case ConsoleKey.D1:
                translatedJoke = TranslateJokeToStarwarsCharacterSpeech(joke.Value, "yoda");
                ConsoleLogging.PassMessageToUser(translatedJoke, StatusCode.Success);
                break;
                
            case ConsoleKey.D2:
                translatedJoke = TranslateJokeToStarwarsCharacterSpeech(joke.Value, "sith");
                ConsoleLogging.PassMessageToUser(translatedJoke, StatusCode.Failure);
                break;
        }
    }

    private static JokeModel? GetJokeFromApi()
    {
        using (HttpClient client = new HttpClient()) // "Using Statement"
        {
            var response = client.GetStringAsync("https://api.chucknorris.io/jokes/random").Result;
        
            JokeModel joke = JsonSerializer.Deserialize<JokeModel>(response);
            return joke;
        }
    }

    private static string TranslateJokeToStarwarsCharacterSpeech(string jokeText, string starwarsCharacter)
    {
        using (HttpClient client = new HttpClient())
        {
            var response = client.GetStringAsync($"https://api.funtranslations.com/translate/{starwarsCharacter}.json?text={jokeText}").Result;
        
            Root? translatedJokeObject = JsonSerializer.Deserialize<Root>(response);

            return translatedJokeObject.Contents.Translated;
        }
    }
}


//{"categories":[],"created_at":"2020-01-05 13:42:26.766831","icon_url":"https://api.chucknorris.io/img/avatar/chuck-norris.png","id":"LVs3-Dj6R8eeolh6hEJK1g","updated_at":"2020-01-05 13:42:26.766831","url":"https://api.chucknorris.io/jokes/LVs3-Dj6R8eeolh6hEJK1g","value":"The secret to the B-2 Stealth Bomber's technology is it contains Chuck Norris's beard. Only 21 were ever built as Chuck Norris has only shaved 21 times."}
