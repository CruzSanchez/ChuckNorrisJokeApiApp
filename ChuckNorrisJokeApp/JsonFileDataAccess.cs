using System.Text.Json;

namespace ChuckNorrisJokeApp;

public class JsonFileDataAccess : IDataAccess
{
    const string JSONFILEPATH = "Jokes/Jokes.json";
    private const string DIRECTORYNAME = "Jokes";
    
    public List<JokeModel> LoadJokes()
    {
        if (!Directory.Exists(DIRECTORYNAME))
        {
            Directory.CreateDirectory(DIRECTORYNAME);            
        }
        
        if (!File.Exists(JSONFILEPATH))
        {
            File.Create(JSONFILEPATH).Close();
            
            File.Move("Jokes.json", "Jokes/Jokes.json");
        }
        
        DirectoryInfo info = new DirectoryInfo("Jokes");
        Console.WriteLine($"File: {info.FullName}, Size: {info.GetFiles().Length}, Date: {info.CreationTime}");
        
        var fileData = File.ReadAllText(JSONFILEPATH);
        
        var jokes = JsonSerializer.Deserialize<List<JokeModel>>(fileData);

        return jokes;
    }

    public void SaveJokes(List<JokeModel> jokes)
    {
        var jokeData = JsonSerializer.Serialize(jokes, new JsonSerializerOptions()
                                                    {
                                                        WriteIndented = true
                                                    });
        
        File.WriteAllText(JSONFILEPATH, jokeData);
    }
}