namespace ChuckNorrisJokeApp;

public interface IDataAccess
{
    public List<JokeModel> LoadJokes();
    public void SaveJokes(List<JokeModel> joke);
}